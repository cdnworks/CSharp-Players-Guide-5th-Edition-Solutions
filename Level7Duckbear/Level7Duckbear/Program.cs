// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter  number of eggs.");
int eggs = Convert.ToInt32(Console.ReadLine());
int sisters = eggs / 4;
int duckbear = eggs % 4;
Console.WriteLine("sisters get " + sisters + " eggs.");
Console.WriteLine("duckbear gets " + duckbear + " eggs.");
Console.WriteLine("it must eat the eggs.");
