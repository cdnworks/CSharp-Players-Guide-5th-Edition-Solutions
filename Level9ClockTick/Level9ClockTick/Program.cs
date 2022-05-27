// See https://aka.ms/new-console-template for more information


//take an input
//print tick if even, tock if odd
Console.WriteLine("enter number");
int num = Convert.ToInt32(Console.ReadLine());

if (num % 2 == 0)
    Console.WriteLine("tick");
else
    Console.WriteLine("tock");
