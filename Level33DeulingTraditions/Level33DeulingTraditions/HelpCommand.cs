namespace DuelingTraditions;


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
