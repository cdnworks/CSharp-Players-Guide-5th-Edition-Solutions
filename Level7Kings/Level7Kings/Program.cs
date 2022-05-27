// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter number of estates");
int estates = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("enter number of duchies");
int duchies = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("enter number of provinces");
int provinces = Convert.ToInt32(Console.ReadLine());

int points = (estates * 1) + (duchies * 3) + (provinces * 6);
Console.WriteLine("you got " + points);
