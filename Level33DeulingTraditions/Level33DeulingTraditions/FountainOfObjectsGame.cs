namespace DuelingTraditions;


//gamestate stuff
// this contains the current game states of the player's position and checks if the fountain has been activated.
// this also calcuates the win condition of the game.
// however more importantly this controls user commands and their results.
public class FountainOfObjectsGame
{
    //properties
    public Map Map { get; }
    public Player Player { get; }
    public bool IsFountainOn { get; set; } = false;

    //win condition
    private bool HasWon => (CurrentRoom == RoomType.Entrance && IsFountainOn);

    //get the current room type the player is in
    private RoomType CurrentRoom => Map.GetRoomTypeAtLocation(Player.Location);

    //collections of senses to be used. Iterate through each sense and use it if the CanSense function is true
    private ISense[] _senses;

    //collection of monsters to be used.
    public Monster[] Monsters { get; }



    //constructor
    public FountainOfObjectsGame(Map map, Player player, Monster[] monsters)
    {
        Map = map;
        Player = player;
        Monsters = monsters;

        //collection of senses, add additional senses here
        _senses = new ISense[]
        {
            new SenseEntrance(),
            new SenseFountain(),
            new SensePit(),
            new SenseMaelstrom(),
            new SenseAmarok()
        };
    }


    //game state handler
    public void Run()
    {
        //create a new DateTime object to start a timer.
        DateTime startTime = DateTime.Now;

        while (!HasWon && Player.IsAlive)
        {
            //do game stuff
            DisplayStatus();
            ICommand command = GetCommand();
            command.Execute(this);

            //player entered a pit room. This is resolved *after* moving or being moved. So a maelstrom cant kill you by throwing you into a pit or an amarok
            //unless you like, bumped into a wall or something (so you stay in the same space).
            if (CurrentRoom == RoomType.Pit)
            {
                Player.KillPlayer("You fell into a bottomless pit!");
            }

            //check through the list of monsters to see if they're in the same room as the player.
            //if they are and they're alive, activate the monster
            foreach (Monster monster in Monsters)
            {
                if (monster.Location == Player.Location && monster.IsAlive) monster.Activate(this);
            }
        }

        //player wins
        if (HasWon)
        {
            //calculate game time, report win to player
            TimeSpan gameTime = DateTime.Now - startTime;
            TextHelper.WriteLine(ConsoleColor.Magenta, "The Fountain of Objects has been restored and you escaped with your life!");
            TextHelper.WriteLine(ConsoleColor.Magenta, "You have won!");
            TextHelper.WriteLine(ConsoleColor.Magenta, $"Game Time: {gameTime}");
        }

        //player dies
        else
        {
            //calculate game time, report loss to player
            TimeSpan gameTime = DateTime.Now - startTime;
            TextHelper.WriteLine(ConsoleColor.Red, "You Died.");
            TextHelper.WriteLine(ConsoleColor.Red, $"Killed by: {Player.CauseOfDeath}");
            TextHelper.WriteLine(ConsoleColor.Red, "Game Over");
            TextHelper.WriteLine(ConsoleColor.Magenta, $"Game Time: {gameTime}");
        }



    }



    //display readout for the player
    public void DisplayStatus()
    {
        TextHelper.WriteLine(ConsoleColor.White, "===================================================================================");
        TextHelper.WriteLine(ConsoleColor.White, $"You are in the room at (Row {Player.Location.Row}, Column {Player.Location.Column})");
        TextHelper.WriteLine(ConsoleColor.White, $"Arrows: {Player.ArrowCount}");
        foreach (ISense sense in _senses)
        {
            if (sense.CanSense(this)) sense.ReportSense(this);
        }
    }

    //get command from player, use Execute() on a variable given value from this method to apply it in the game state method
    private ICommand GetCommand()
    {
        //collect user input and based on their input create an appropriate new ICommand object
        while (true)
        {
            TextHelper.WriteLine(ConsoleColor.White, "What would you like to do?");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? input = Console.ReadLine();

            //match input to ICommand
            if (input == "move north") return new MoveCommand(Direction.North);
            if (input == "move east") return new MoveCommand(Direction.East);
            if (input == "move south") return new MoveCommand(Direction.South);
            if (input == "move west") return new MoveCommand(Direction.West);

            if (input == "fire north") return new FireBowCommand(Direction.North);
            if (input == "fire east") return new FireBowCommand(Direction.East);
            if (input == "fire south") return new FireBowCommand(Direction.South);
            if (input == "fire west") return new FireBowCommand(Direction.West);

            if (input == "toggle fountain") return new ToggleFountainCommand();

            if (input == "help") return new HelpCommand();


            //any other input should be ignored, and reported to the player
            else
            {
                TextHelper.WriteLine(ConsoleColor.Red, $"Sorry, {input} isnt a valid command. Enter 'help' (without quotes) to see a list of commands.");
            }
        }
    }





}
