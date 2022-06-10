/* This program is a demonstration of the ExpandoObject class
 * 
 * Objectives:
 * Create a new dynamic variable, holding a reference to an ExpandoObject.
 * 
 * Give the dynamic object an ID property who's type is int and assign each 'robot' a new number.
 * 
 * Ask the user if they want to name the robot, and if they do, collect it and store it in a Name property.
 * 
 * Ask if they want to provide a size for the robot. If so, collect a width and height from the user
 * and store those in Width and Height properties.
 * 
 * Ask if they want to choose a color for the robot. If so, store their choice in a Color property.
 * 
 * Display all existing properties for the robot to the console window using the following code:
 * foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
 *      Console.WriteLine($"{property.Key}: {property.Value}");
 * 
 * Loop repeatedly to allow the user to design and build multiple robots.
 */

using System.Dynamic;


// Main
int nextID = 1;

while(true)
{
    dynamic robot = new ExpandoObject();
    robot.ID = nextID;
    nextID++;

    Console.WriteLine("Do you want to name the robot?");
    if (Console.ReadLine() == "yes") 
    {
        Console.Write("Enter it's name: ");
        robot.Name = Console.ReadLine();
    }

    Console.WriteLine("Do you want a specific height for the robot?");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("Enter it's height: ");
        robot.Height = Convert.ToSingle(Console.ReadLine());
    }

    Console.WriteLine("Do you want a specific width for the robot?");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("Enter it's width: ");
        robot.Width = Convert.ToSingle(Console.ReadLine());
    }

    Console.WriteLine("Do you want a specific color for the robot?");
    if (Console.ReadLine() == "yes")
    {
        Console.Write("Enter it's color: ");
        robot.Color = Console.ReadLine();
    }


    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
        Console.WriteLine($"{property.Key}: {property.Value}");

}



