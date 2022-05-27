/* This program is a modification of the Level 26 progrom, Old Robot.
 * Here, I will be reworking the abstract RobotCommand base class into an interface, called IRobotCommand.
 * 
 * Objectives
 * Change RobotCommand class to IRobotCommand interface
 * remove the unnecessary public and abstract keywords from the Run method.
 * Change the Robot class to implement IRobotCommand instead of RobotCommand
 * make all commands implement the new interface instead
 * 
* 
*/




//main

Robot robot = new Robot();


while (true)
{
    Console.WriteLine("The robot takes up to 3 commands, one at a time.");
    for (int i = 0; i < robot.Commands.Length; i++)
    {
        Console.WriteLine("Enter a command: 'on', 'off', 'north', 'east', 'south', 'west' \n");
        string? input = Console.ReadLine();

        //unexpected input predictably breaks this
        IRobotCommand newCommand = input switch
        {
            "on" => new OnCommand(),
            "off" => new OffCommand(),
            "north" => new NorthCommand(),
            "east" => new EastCommand(),
            "south" => new SouthCommand(),
            "west" => new WestCommand()
        };
        robot.Commands[i] = newCommand;
    }

    Console.WriteLine();

    robot.Run();

}








public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
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