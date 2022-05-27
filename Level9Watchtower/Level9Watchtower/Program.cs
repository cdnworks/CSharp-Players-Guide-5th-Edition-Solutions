// See https://aka.ms/new-console-template for more information

//given a 9 x 9 grid, and two coordinates x, and y
//determine the cardinal direction of the given coordinates from the center
//such that x > 0 is east, x < 0 is west
// and y > 0 is north, y < 0 is south

//take two inputs, figure out relative position, display position

Console.Write("X Coordinate: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.Write("Y Coordinate: ");
int y = Convert.ToInt32(Console.ReadLine());

//x > 0 cases (eastern areas)
if (x > 0 && y > 0) Console.WriteLine("NORTH EAST");
if (x > 0 && y == 0) Console.WriteLine("EAST");
if (x > 0 && y < 0) Console.WriteLine("SOUTH EAST");

//x == 0 cases (central areas)
if (x == 0 && y > 0) Console.WriteLine("NORTH");
if (x == 0 && y == 0) Console.WriteLine("THE ENEMY IS HERE");
if (x == 0 && y < 0) Console.WriteLine("SOUTH");

//x < 0 cases (western areas)
if (x < 0 && y > 0) Console.WriteLine("NORTH WEST");
if (x < 0 && y == 0) Console.WriteLine("WEST");
if (x < 0 && y < 0) Console.WriteLine("SOUTH WEST");


