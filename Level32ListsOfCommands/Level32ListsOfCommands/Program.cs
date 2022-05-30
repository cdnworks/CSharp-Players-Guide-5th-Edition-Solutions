/* This is a modified version of my implementation of Level 27's robot program.
 * Here I have changed the robot commands collection from a fixed array to a List<T>
 * that will continue adding commands until the user issues a 'stop' command.
 * 
* 
*/




//main

Robot robot = new Robot();


while (true)
{
    Console.WriteLine("The robot takes commands, completing one command at a time.");
    while(true)
    {
        Console.WriteLine("Enter a command: 'on', 'off', 'north', 'east', 'south', 'west' \n Type 'stop' to end your list of commands. \n");
        string? input = Console.ReadLine();

        if (input == "on") robot.Commands.Add(new OnCommand());
        if (input == "off") robot.Commands.Add(new OffCommand());
        if (input == "north") robot.Commands.Add(new NorthCommand());
        if (input == "east") robot.Commands.Add(new EastCommand());
        if (input == "south") robot.Commands.Add(new SouthCommand());
        if (input == "west") robot.Commands.Add(new WestCommand());
        if (input == "stop") break;
    }

    Console.WriteLine();

    robot.Run();

    //clear the commands after running
    robot.Commands.Clear();

}








public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand?> Commands { get; } = new List<IRobotCommand?>();
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}


public interface IRobotCommand
{
    public void Run(Robot robot);
}


public class OnCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = true;
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot) => robot.IsPowered = false;
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}
public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
}
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}
public class WestCommand : IRobotCommand
{
    public void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}