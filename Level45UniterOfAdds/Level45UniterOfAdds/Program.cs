/* This program contains a simple use of the dynamic keyword
 * 
 * public static class Adds 
 * {
 *      public static int Add(int a, int b) => a + b;
 *      public static double Add(double a, double b) => a + b;
 *      public static string Add(string a, string b) => a + b;
 *      public static DateTime Add(DateTime a, TimeSpan b) => a + b;
 * }
 * 
 * 
 * Objectives:
 * Make a single Add method that can replace all four of the above methods using dynamic
 * 
 * Add code to your main method to call the new method with two ints, two doubles, two strings and a DateTime and TimeSpan,
 * and display the results.
 * 
 */


// Main
Console.WriteLine(Add(1,2));
Console.WriteLine(Add(1.5,3.55));
Console.WriteLine(Add("dong","ding"));
Console.WriteLine(Add(DateTime.Now,TimeSpan.FromHours(1)));



// Methods

dynamic Add(dynamic a, dynamic b) => a + b;