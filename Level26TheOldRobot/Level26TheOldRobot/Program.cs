/* Given the Robot class, make an abstract RobotCommand class that only contains an abstract Run command
 * then, make derived classes that extend RobotCommand that move it in each of the four cardinal direactions
 * and power it on and off.
 * 
 * Objectives: 
 * Create a RobotCommand class with a public and abstract void Run(Robot robot) method.
 * (The given Robot class should run after making that)
 * 
 * Make OnCommand and OffCommand classes that inherit from RobotCommand and turn the robot on or off by
 * overriding the Run method.
 * 
 * Make a NorthCommand, SouthCommand, WestCommand, EastCommand classes that move the robot 1 unit in the respective
 * cartesian directions. Ensure these commands only work if the robot's IsPowered property is true.
 * 
 * Make your main method able to colelct the three commands from the console window. Generate new RobotCommand objects based
 * on the text entered by the user. After filling the robot's command set with these new RobotCommand objects,
 * use the Run method to execute them.
 * 
 * Note: The strategy for making the commands that update other objects might be useful in 
 * larger challenges later in the book
 * 
 */




//main

Robot robot = new Robot();


while (true)
{
    Console.WriteLine("The robot takes up to 3 commands, one at a time.");
    for(int i = 0; i < robot.Commands.Length; i++)
    {
        Console.WriteLine("Enter a command: 'on', 'off', 'north', 'east', 'south', 'west' \n");
        string? input = Console.ReadLine();

        //unexpected input predictably breaks this
        RobotCommand newCommand = input switch
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
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}


public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}


public class OnCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = true;
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot) => robot.IsPowered = false;
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.Y++; }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.Y--; }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.X++; }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot) { if (robot.IsPowered) robot.X--; }
}