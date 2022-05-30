/* This is a modified version of my extended implementation of Level 32, this time, the programs types are distributed across multiple files
 * and utilize a namespace. Furthermore, I've rewritten the program.cs file (this file) to include the legacy boiler plate entrypoint.
 *  
 */

namespace DuelingTraditions;


// ================== MAIN ===================


public class Program
{
    public static void Main(string[] args)
    {
        DisplayIntroduction();
        FountainOfObjectsGame newGame = GenerateGame();
        newGame.Run();


    }

    // ================== METHODS FOR MAIN ===================
    private static void DisplayIntroduction()
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

    private static FountainOfObjectsGame GenerateGame()
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


}