// See https://aka.ms/new-console-template for more information

//given an imaginary and infinite cartesian grid of numbered rows and columns and a point on this grid,
//find the four cardinally adjacent intersections surrounding a given point
//display these coordinates in a different color
//change the title of the console
//play a beep when the results are displayed

Console.Title = "Defense of Consolas";


Console.Write("Enter Target Row: ");
int tRow = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter Target Column: ");
int tCol = Convert.ToInt32(Console.ReadLine());


//Id like to store these coordinates as a list but to keep it simple
//though more wordy, Im just gonna evaluate the expressions as I print
Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;

Console.WriteLine("NORTH DEPLOYMENT: ROW " + (tRow + 1) + " COL " + tCol);
Console.WriteLine("EAST DEPLOYMENT: ROW " + tRow + " COL " + (tCol + 1));
Console.WriteLine("SOUTH DEPLOYMENT: ROW " + (tRow - 1) + " COL " + tCol);
Console.WriteLine("WEST DEPLOYMENT: ROW " + tRow + " COL " + (tCol -  1));
Console.Beep();
