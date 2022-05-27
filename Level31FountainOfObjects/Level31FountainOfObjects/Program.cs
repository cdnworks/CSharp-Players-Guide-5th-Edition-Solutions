/* this program is a game where you the player move along a series of rooms in a 4x4 grid (possibly larger)
 * where the goal is to encounter the fountain of objects, and turn the fountain on. There is a catch however
 * the rooms are shrouded in a magical darkness that cannot be dispelled, so you must navigate by smell and hearing alone
 * after turning the fountain on, you must make your way back to the exit.
 * However, the dungeon may have rooms with pits, monsters or other traps!
 * 
 * Objectives:
 * 
 *  ============================== BASE GAME ==============================
 *  
 * The world consists of a grid of rooms where each room can be referenced by its row and column.
 * North is up, east is right, south is down, and west is left.
 * 
 * The game flow goes like this: The player is told what they can sense in the dark
 * Then the player gets a chance to perform some action by typing it in.
 * Their chosen action is resolved (the player moves, turns the fountain on or off, other state changes,
 * checking if the player won or not meaning they died, etc) Then the loop repeats.
 * 
 * Most rooms by default are empty and there is nothing to sense
 * 
 * the player is in one of the rooms and can move between them by typing commands like 'move north'
 * the player should not be allowed to move past the ends of the map.
 * 
 * the room at column 0, row 0 is the entrance. The player should start here on a new game. The player can sense the light
 * comming from the outside world at this space ("You see light in this room coming from outside the cavern. This is the entrance.")
 * 
 * the room at column 2, row 0 is the fountain room. Containing the fountain of objects itself.
 * the fountain can be either turned on or off. The player can hear the fountain but hears different things depending on
 * the state of the fountain. (on or off) ("You hear water dripping in this room. The Fountain of Objects is here!")
 * ("You hear the rushing waters from the Fountain of Objects. It has been reacctivated!")
 * The fountain is off initially. when the player is in this room, the player can type "enable fountain" to turn it on.
 * if the player isnt in the fountain room and tries to "enable fountain", it should fail and alert the player that it failed.
 * 
 * the player wins if the fountain is reactivated and they make it back to the entrance. basically, the win condition is if the fountain is on
 * and the player is at ( 0, 0 )
 * 
 * use different colors to display the different types of text in the console window. For example,
 * Narrative items (intro, ending, etc) may be magenta. Descriptive text (what the player senses) in white, input from the user in cyan
 * text describing the entrace light in yellow, messages about the fountain in blue
 * 
 * HINT: use 2d arrays, found in level 12.
 * HINT, pick out problems one at a time. (use classes)
 * 
 *  =======================================================================
 * 
 */



// ================== MAIN ===================
FountainOfObjectsGame newGame = StarterGame();
newGame.Run();






// ================== METHODS FOR MAIN ===================
FountainOfObjectsGame StarterGame()
{
    Location startLocation = new Location(0, 0);
    Location fountainLocation = new Location(0, 2);
    Map map = new Map(4, 4);
    Player player = new Player(startLocation);
    map.SetRoomTypeAtLocation(startLocation, RoomType.Entrance);
    map.SetRoomTypeAtLocation(fountainLocation, RoomType.FountainRoom);

    FountainOfObjectsGame game = new FountainOfObjectsGame(map, player);
    return game;
}





// =============== TYPE DEFS ================

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



    //constructor
    public FountainOfObjectsGame(Map map, Player player)
    {
        Map = map;
        Player = player;

        //collection of senses, add additional senses here
        _senses = new ISense[]
        {
            new SenseEntrance(),
            new SenseFountain()
        };
    }


    //game state handler
    public void Run()
    {
        while (!HasWon && Player.IsAlive)
        {
            //do game stuff
            DisplayStatus();
            ICommand command = GetCommand();
            command.Execute(this);
        }

        //player wins
        if(HasWon)
        {
            TextHelper.WriteLine(ConsoleColor.Magenta, "The Fountain of Objects has been restored and you escaped with your life!");
            TextHelper.WriteLine(ConsoleColor.Magenta, "You have won!");
        }

        //player dies
        else
        {
            TextHelper.WriteLine(ConsoleColor.Red, "You Died.");
            TextHelper.WriteLine(ConsoleColor.Red, $"Killed by: {Player.CauseOfDeath}");
            TextHelper.WriteLine(ConsoleColor.Red, "Game Over");
        }



    }



    //display readout for the player
    public void DisplayStatus()
    {
        TextHelper.WriteLine(ConsoleColor.White, "===================================================================================");
        TextHelper.WriteLine(ConsoleColor.White, $"You are in the room at (Row {Player.Location.Row}, Column {Player.Location.Column})");
        foreach (ISense sense in _senses)
        {
            if(sense.CanSense(this)) sense.ReportSense(this);
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
            if (input == "toggle fountain") return new ToggleFountainCommand();


            //any other input should be ignored, and reported to the player
            else
            {
                TextHelper.WriteLine(ConsoleColor.Red, $"Sorry, {input} isnt a valid command. Try 'move (cardinal direction)' or 'toggle fountain'");
            }
        }
    }





}






//the map is a grid of rooms (a 2 dimensional array of RoomTypes) The constructor should allow for entering custom dimensions
//and sets all rooms to empty by default upon construction
public class Map
{
    private RoomType[,] _map;
    public int Rows { get; }
    public int Columns { get; }

    public Map (int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _map = new RoomType[rows, columns];

        //generate an empty map on construction
        for(int i=0; i<_map.GetLength(0); i++)
            for(int j=0; j<_map.GetLength(1); j++)
            {
                _map[i, j] = RoomType.Empty;
            }
    }

    //checks the boundary of the map. Useful for preventing the user or other entities from moving outside of the map area.
    public bool IsInbounds(Location location)
    {
        if (location.Row < 0 || location.Column < 0) return false;
        if (location.Row >= _map.GetLength(0) || location.Column >= _map.GetLength(1)) return false;
        return true;
    }

    //allow custom placement for rooms, as well as building the map on construction
    //ideally, when the game is started, the program will place an entrance and an exit.
    public void SetRoomTypeAtLocation(Location location, RoomType roomType) => _map[location.Row, location.Column] = roomType;
    //retrieve the room type at the location
    public RoomType GetRoomTypeAtLocation(Location location) => _map[location.Row, location.Column];


}

//player class contains status about the player and initializes the location of the player on construction
public class Player
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; }

    //if the player dies, hold a string explaining what killed them. Initially, this string is empty.
    public string CauseOfDeath { get; set; }

    public Player(Location startLocation)
    {
        //upon construction, the player starts at a specified starting location
        Location = startLocation;
        IsAlive = true;
        CauseOfDeath = "";
    }

    //method for killing the player and setting the cause of death in the event the player dies
    public void KillPlayer(string causeOfDeath)
    {
        IsAlive = false;
        CauseOfDeath = causeOfDeath;
    }
}


//interface for player commands
public interface ICommand
{
    //performs the command and executes it on the gamestate
    public void Execute(FountainOfObjectsGame game);
}


//takes in a direction from the game state controller, FountainOfObjectsGame
// then applies a transform to the player's position 
public class MoveCommand : ICommand
{
    public Direction Direction { get; }

    public MoveCommand(Direction direction)
    {
        Direction = direction;
    }

    //adjusts player location by 1 room depending on the user's selected direction.
    public void Execute(FountainOfObjectsGame game)
    {
        Location currentLocation = game.Player.Location;
        Location newLocation = Direction switch
        {
            //this orientation places (0,0) in the south western corner of the grid.
            Direction.North => new Location(currentLocation.Row + 1, currentLocation.Column),
            Direction.South => new Location(currentLocation.Row - 1, currentLocation.Column),
            Direction.East => new Location(currentLocation.Row, currentLocation.Column + 1),
            Direction.West => new Location(currentLocation.Row, currentLocation.Column - 1)
        };

        //check if the move is legal, if it is, move the player, if not, alert the player and dont move them
        if (game.Map.IsInbounds(newLocation)) game.Player.Location = newLocation;
        else TextHelper.WriteLine(ConsoleColor.Red, "There's a wall in that direction! Try going a different direction.");
    }
}

//changes the on or off state of the fountain of objects
public class ToggleFountainCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        //check if the player is in the fountain room
        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.FountainRoom)
        {
            //change fountain state
            if (game.IsFountainOn) game.IsFountainOn = false;
            else game.IsFountainOn = true;
        }
        else TextHelper.WriteLine(ConsoleColor.Red, "The fountain isn't here, there was no effect.");
    }
}


//interface for what the player can 'sense' at a given location
// it is assumed that CanSense will be called, and if it is true, then ReportSense will be called.
public interface ISense
{
    //the various senses should determine if... well they can be sensed.
    public bool CanSense(FountainOfObjectsGame game);
    //if the sense in question can be experienced, then report that sense to the player!
    public void ReportSense(FountainOfObjectsGame game);
}


//Represents the player seeing the light from the outside world via the entrance.
public class SenseEntrance : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.Entrance) return true;
        else return false;
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        TextHelper.WriteLine(ConsoleColor.Yellow, "You see the soft light of the sun through the tunnel here. It is the cave entrance.");
    }
}

//Represents the player hearing the water of the fountain. The message changes depending on if the fountain is on or not.
public class SenseFountain : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        if (game.Map.GetRoomTypeAtLocation(game.Player.Location) == RoomType.FountainRoom) return true;
        else return false;
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        if (game.IsFountainOn) TextHelper.WriteLine(ConsoleColor.DarkCyan, "The sound of rushing water fills the room. The Fountain has been reactivated!!");
        else TextHelper.WriteLine(ConsoleColor.DarkCyan, "You hear the faint dripping of water. The Fountain is here!!");
    }
}




//TextHelper writes custom color text when needed
public static class TextHelper
{
    public static void WriteLine(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Write(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.White;
    }
}



//Records and Enums
public record Location (int Row, int Column);

public enum RoomType { Entrance, FountainRoom, Empty, OutOfBounds}
public enum Direction { North, East, South, West};