/* This is a modified version of my extended implementation of Level 31. This time, I added a timer feature that tracks how long the game lasted
 * and then displays it to the player when they win or lose.
 *  
 */



// ================== MAIN ===================
DisplayIntroduction();
FountainOfObjectsGame newGame = GenerateGame();
newGame.Run();






// ================== METHODS FOR MAIN ===================
void DisplayIntroduction()
{
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "You have entered the Cavern of Objects, a maze of rooms filled with dangerous");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "pits and monsters in search of the legendary Fountain of Objects.");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "Light is only visible in the entrance room, and no other light is seen within");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "the depths of the cavern.");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "You must navigate the cavern with your other senses.\n\n");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "Your goal is to find the Fountain of Objects, activate it and return to the entrance!\n\n");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "Look out for pits, you will feel a breeze if a pit is in an adjacent room. Entering");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "a room with a pit will surely cause you to fall; killing you.");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "Monsters infest the caverns, Maelstroms are sentient wind storms that will push");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "you away, deeper into the cavern if you stumble upon one. You will be able to hear");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "them from adjacent rooms.");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "There are also deadly Amaroks, fearsome undead beasts that devour any living thing");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "in their immediate reach. (Un)Thankfully, you can smell them from adjacent rooms.\n");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "You carry with you a bow and quiver of arrows to vanquish the monsters in the cavern.");
    TextHelper.WriteLine(ConsoleColor.DarkYellow, "You may shoot them into adjacent rooms, but be warned: you carry a limited number of arrows.\n\n");
}

FountainOfObjectsGame GenerateGame()
{
    //prompt the user, and collect user input for map size.
    TextHelper.WriteLine(ConsoleColor.Magenta, "How large do you want the cavern to be on this attempt?");


    while (true)
    {
        TextHelper.WriteLine(ConsoleColor.Magenta, "You may enter: 'small', 'medium', or 'large'");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string? input = Console.ReadLine();

        //generate the map size, player location, monsters and thier locations, the fountain location, and pit location
        if (input == "small")
        {
            Map map = new Map(4, 4);
            Location startLocation = new Location(0, 0);
            Monster[] monsters = new Monster[]
            {
                new Maelstrom(new Location(1,1)),
                new Amarok(new Location(3,3))
            };
            map.SetRoomTypeAtLocation(startLocation, RoomType.Entrance);
            map.SetRoomTypeAtLocation(new Location(0, 2), RoomType.FountainRoom);
            map.SetRoomTypeAtLocation(new Location(3, 0), RoomType.Pit);
            //after building the map size and placing objects accordingly, return the new game instance
            return new FountainOfObjectsGame(map, new Player(startLocation), monsters);
        }
        if (input == "medium")
        {
            Map map = new Map(6, 6);
            Location startLocation = new Location(0, 0);
            Monster[] monsters = new Monster[]
            {
                new Maelstrom(new Location(2,0)),
                new Amarok(new Location(5,4))
            };
            map.SetRoomTypeAtLocation(startLocation, RoomType.Entrance);
            map.SetRoomTypeAtLocation(new Location(2, 2), RoomType.FountainRoom);
            map.SetRoomTypeAtLocation(new Location(2, 0), RoomType.Pit);
            //after building the map size and placing objects accordingly, return the new game instance
            return new FountainOfObjectsGame(map, new Player(startLocation), monsters);
        };
        if (input == "large")
        {
            Map map = new Map(8, 8);
            Location startLocation = new Location(0, 0);
            Monster[] monsters = new Monster[]
            {
                new Maelstrom(new Location(2,0)),
                new Amarok(new Location(7,3))
            };
            map.SetRoomTypeAtLocation(startLocation, RoomType.Entrance);
            map.SetRoomTypeAtLocation(new Location(4, 4), RoomType.FountainRoom);
            map.SetRoomTypeAtLocation(new Location(3, 4), RoomType.Pit);
            //after building the map size and placing objects accordingly, return the new game instance
            return new FountainOfObjectsGame(map, new Player(startLocation), monsters);
        };
        TextHelper.WriteLine(ConsoleColor.Magenta, $"{input} isn't a valid game size.");
    }


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






//the map is a grid of rooms (a 2 dimensional array of RoomTypes) The constructor should allow for entering custom dimensions
//and sets all rooms to empty by default upon construction
public class Map
{
    private RoomType[,] _map;
    public int Rows { get; }
    public int Columns { get; }

    public Map(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _map = new RoomType[rows, columns];

        //generate an empty map on construction
        for (int i = 0; i < _map.GetLength(0); i++)
            for (int j = 0; j < _map.GetLength(1); j++)
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


    //checks adjacent (from position) tiles for the passed in room type. For sensing pit rooms or something else.
    public bool IsRoomAdjacent(RoomType roomType, Location location)
    {
        //is this the dreadded code smell?
        // I also dislike the 8 direction adjacent system and restricted it down to four (north, east, south and west) for better gameplay
        if (GetRoomTypeAtLocation(new Location(location.Row - 1, location.Column)) == roomType) return true;
        //if (GetRoomTypeAtLocation(new Location(location.Row - 1 , location.Column - 1)) == roomType) return true;
        //if (GetRoomTypeAtLocation(new Location(location.Row - 1 , location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row + 1, location.Column)) == roomType) return true;
        //if (GetRoomTypeAtLocation(new Location(location.Row + 1 , location.Column - 1)) == roomType) return true;
        //if (GetRoomTypeAtLocation(new Location(location.Row + 1 , location.Column + 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column - 1)) == roomType) return true;
        if (GetRoomTypeAtLocation(new Location(location.Row, location.Column + 1)) == roomType) return true;
        return false;
    }


    //allow custom placement for rooms, as well as building the map on construction
    //ideally, when the game is started, the program will place an entrance and an exit.
    public void SetRoomTypeAtLocation(Location location, RoomType roomType) => _map[location.Row, location.Column] = roomType;
    //retrieve the room type at the location, if it is in bounds. If it is out of bounds, return the OOB room type.
    public RoomType GetRoomTypeAtLocation(Location location) => IsInbounds(location) ? _map[location.Row, location.Column] : RoomType.OutOfBounds;


}

//player class contains status about the player and initializes the location of the player on construction
public class Player
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; }

    public int ArrowCount { get; set; } = 5;

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




//abstract class for monsters so they may be put into a collection in the game handler logic
public abstract class Monster
{
    public Location Location { get; set; }
    public bool IsAlive { get; set; } = true;

    public Monster(Location spawnLocation) => Location = spawnLocation;

    //use the Activate method to do what the monster is built to do to the player when they are in the same room.
    public abstract void Activate(FountainOfObjectsGame game);
}

//class for the Maelstrom monster, contains status about it and initializes it's location on construction
public class Maelstrom : Monster
{
    public Maelstrom(Location spawnLocation) : base(spawnLocation) { }

    //the maelstrom blows the player away and moves away. Clamp the positions if they will cause the monster or player to go OOB
    public override void Activate(FountainOfObjectsGame game)
    {
        //generate two new locations, one for the player and one for the maelstrom, and clamp them, and update their positions in the game.
        //the player moves 1 space north, two east; the maelstrom moves 1 space south, two west
        TextHelper.WriteLine(ConsoleColor.Red, "You have been swept away by the gale of a Maelstrom!!");
        game.Player.Location = ClampedLocation(new Location(game.Player.Location.Row + 1, game.Player.Location.Column + 2), game.Map);
        Location = ClampedLocation(new Location(Location.Row - 1, Location.Column - 2), game.Map);
    }

    //clamp the location based on the map size if neccessary
    private Location ClampedLocation(Location moveLocation, Map map)
    {
        int clampedRow = moveLocation.Row;
        int clampedColumn = moveLocation.Column;
        //check if the move location is in bounds, if not, clamp it to the nearest in bounds space.
        if (moveLocation.Row < 0) clampedRow = 0;
        if (moveLocation.Row >= map.Rows) clampedRow = map.Rows - 1;
        if (moveLocation.Column < 0) clampedColumn = 0;
        if (moveLocation.Column >= map.Columns) clampedColumn = map.Columns - 1;
        return new Location(clampedRow, clampedColumn);
    }

}


public class Amarok : Monster
{
    public Amarok(Location spawnLocation) : base(spawnLocation) { }

    //amaroks simply kill the player if they collide.
    public override void Activate(FountainOfObjectsGame game)
    {
        game.Player.KillPlayer("You were eaten by an Amarok!");
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

    public MoveCommand(Direction direction) => Direction = direction;

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

//lets the player fire an arrow in the chosen direction.
public class FireBowCommand : ICommand
{
    Direction Direction { get; }
    public FireBowCommand(Direction direction) => Direction = direction;

    public void Execute(FountainOfObjectsGame game)
    {
        //check if the player has arrows to fire
        //check if there is a monster in the adjacent tile in the specified direction.
        //if there is, kill it. If there isnt a monster there, let the player know nothing happened.
        //reduce the player's arrow count by 1.
        if (game.Player.ArrowCount == 0)
        {
            TextHelper.WriteLine(ConsoleColor.Red, "You have no arrows to fire!");
            return;
        }

        Location firedLocation = Direction switch
        {
            Direction.North => new Location(game.Player.Location.Row + 1, game.Player.Location.Column),
            Direction.South => new Location(game.Player.Location.Row - 1, game.Player.Location.Column),
            Direction.East => new Location(game.Player.Location.Row, game.Player.Location.Column + 1),
            Direction.West => new Location(game.Player.Location.Row, game.Player.Location.Column - 1)
        };

        bool didArrowHit = false;
        //check the monster collection to see if there's a monster in location the arrow was fired into
        foreach (Monster monster in game.Monsters)
        {
            if (monster.Location == firedLocation)
            {
                monster.IsAlive = false;
                didArrowHit = true;
            }
        }

        if (didArrowHit) TextHelper.WriteLine(ConsoleColor.Green, "Your arrow hit something in the distance!");
        else TextHelper.WriteLine(ConsoleColor.Red, "You hear the echo of your arrow clattering off the stone in the distance...");

        game.Player.ArrowCount--;

    }
}


//help command, displays commands with brief explainations.
public class HelpCommand : ICommand
{
    public void Execute(FountainOfObjectsGame game)
    {
        Console.WriteLine("");
        TextHelper.WriteLine(ConsoleColor.Gray, "help");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Displays this help information.");
        TextHelper.WriteLine(ConsoleColor.Gray, "toggle fountain");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Toggles the Fountain of Objects on or off if you are in the fountain room, or does nothing if you are not.");
        TextHelper.WriteLine(ConsoleColor.Gray, "move north");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Moves to the room directly north of the current room, as long as there are no walls.");
        TextHelper.WriteLine(ConsoleColor.Gray, "move south");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Moves to the room directly south of the current room, as long as there are no walls.");
        TextHelper.WriteLine(ConsoleColor.Gray, "move east");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Moves to the room directly east of the current room, as long as there are no walls.");
        TextHelper.WriteLine(ConsoleColor.Gray, "move west");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Moves to the room directly west of the current room, as long as there are no walls.");
        TextHelper.WriteLine(ConsoleColor.Gray, "fire north");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Fires an arrow from your bow to the room directly north of where you are. Consumes an arrow.");
        TextHelper.WriteLine(ConsoleColor.Gray, "fire south");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Fires an arrow from your bow to the room directly south of where you are. Consumes an arrow.");
        TextHelper.WriteLine(ConsoleColor.Gray, "fire east");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Fires an arrow from your bow to the room directly east of where you are. Consumes an arrow.");
        TextHelper.WriteLine(ConsoleColor.Gray, "fire west");
        TextHelper.WriteLine(ConsoleColor.Gray, "    Fires an arrow from your bow to the room directly west of where you are. Consumes an arrow.");
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


//represents the player feeling a draft from a nearby pit.
public class SensePit : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        return game.Map.IsRoomAdjacent(RoomType.Pit, game.Player.Location);
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        TextHelper.WriteLine(ConsoleColor.DarkGray, "You feel a sudden draft around you, beware, there must be a deadly pit nearby...");
    }
}


//represents the player sensing a nearby Maelstrom
public class SenseMaelstrom : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        //cycle through the game's list of monsters, check for maelstroms, and check if they are alive. if they are, calculate adjacency 
        //then display the sense if the maelstrom is adjacent.
        foreach (Monster monster in game.Monsters)
        {
            if (monster is Maelstrom && monster.IsAlive)
            {
                //look to see if the monster is 1 space away by finding the difference in the two's positions
                int rowDifference = Math.Abs(game.Player.Location.Row - monster.Location.Row);
                int columnDifference = Math.Abs(game.Player.Location.Column - monster.Location.Column);
                if (rowDifference <= 1 && columnDifference <= 1) return true;
            }
        }
        return false;
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        TextHelper.WriteLine(ConsoleColor.DarkRed, "You hear the growling and groaning of a maelstrom nearby...");
    }
}


//represents the player smelling an Amarok
public class SenseAmarok : ISense
{
    public bool CanSense(FountainOfObjectsGame game)
    {
        //cycle through the game's list of monsters, check for maelstroms, and check if they are alive. if they are, calculate adjacency 
        //then display the sense if the maelstrom is adjacent.
        foreach (Monster monster in game.Monsters)
        {
            if (monster is Amarok && monster.IsAlive)
            {
                //look to see if the monster is 1 space away by finding the difference in the two's positions
                int rowDifference = Math.Abs(game.Player.Location.Row - monster.Location.Row);
                int columnDifference = Math.Abs(game.Player.Location.Column - monster.Location.Column);
                if (rowDifference <= 1 && columnDifference <= 1) return true;
            }
        }
        return false;
    }

    public void ReportSense(FountainOfObjectsGame game)
    {
        TextHelper.WriteLine(ConsoleColor.DarkRed, "You smell the rotten stench of an amarok nearby...");
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
public record Location(int Row, int Column);

public enum RoomType { Entrance, FountainRoom, Empty, OutOfBounds, Pit }
public enum Direction { North, East, South, West };