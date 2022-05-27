// See https://aka.ms/new-console-template for more information

/* given an array
 * find the smallest number
 * find the average among all the numbers
 * use foreach loops.
 */

//find the smallest element
int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
int currentSmallest = int.MaxValue;

foreach(int num in array)
    if(num < currentSmallest) 
        currentSmallest = num;

Console.WriteLine($"Smallest number in the array is {currentSmallest}");


//find the average among all elements
int sum = 0;

foreach (int num in array) sum += num;
float average = (float)sum / (float)array.Length;

Console.WriteLine($"The average of the array is {average}");

