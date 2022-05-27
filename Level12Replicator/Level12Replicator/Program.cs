// See https://aka.ms/new-console-template for more information

/*
 * initialize an array with 5 elements
 * take user inputs to fill the array with int values
 * create a new array with 5 elements
 * copy the original array into the new array
 * print both arrays for verification
 */



Console.Title = "Replicator of D'to";

int[] originalArr = new int[5];

//fill array
for (int i = 0; i < originalArr.Length; i++)
{
    Console.WriteLine("Enter a whole number: ");
    originalArr[i] = Convert.ToInt32(Console.ReadLine());
}

//create new array and copy
int[] copyArr = new int[5];
for(int i = 0; i < copyArr.Length; i++)
    copyArr[i] = originalArr[i];

//display arrays
for(int i = 0; i < originalArr.Length; i++)
    Console.WriteLine($"Element {i} Value: ORIGINAL: {originalArr[i]} COPY: {copyArr[i]}");




