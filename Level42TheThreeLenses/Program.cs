/* This program demonstrates some basic LINQ usage, specifically LINQ to Objects, rather than working with a SQL database.
 * 
 * Given an array of positive numbers: [1,9,2,8,3,7,4,6,5]
 * make a new collection from this data where:
 * 
 * All the odd numbers are filtered out, and only the even should be considered.
 * 
 * The numbers are in order.
 * 
 * The numbers are doubled.
 * 
 * Meaning, the odd/even filter should result in 2,8,4,6
 * The ordering should result in 2,4,6,8
 * The doubling step should result in 4,8,12,16
 * 
 * Objectives:
 * Write a method that takes an int[] as an input and produce an IEnumerable<int>
 * (it can be a list or an array if you want that meets all three of the conditions above using only procedural
 * code. Meaning if statements, switches and loops. (Hint: the static Array.Sort method might be useful)
 * 
 * Write a method that will take an int[] as input and produce an IEnumerable<int> that meets the above conditions
 * using a keyword-based query expression (from x, where x, select x, etc)
 * 
 * Write a method that will take an int[] as input and produce an IEnumerable<int> that meets the three above conditions
 * using a method call based query expression (x.Select(n => n+1), x.Where(n => n < 0), etc).
 * 
 * Run all three methods and display the results to make sure they work.
 */


// Main

int[] baseArray = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };


Console.WriteLine("Base array: ");
PrintCollection(baseArray);

Console.WriteLine();

Console.WriteLine("Procedural Code result: ");
PrintCollection(ProceduralWork(baseArray));

Console.WriteLine();

Console.WriteLine("Keyword Code result: ");
PrintCollection(KeywordWork(baseArray));

Console.WriteLine();

Console.WriteLine("Method Call Query result: ");
PrintCollection(MethodQueryWork(baseArray));

// Methods

IEnumerable<int> ProceduralWork(int[] inputArray)
{
    //though we know how big the array we're working with will be after picking out the even elements
    //we may not know with some other array. Building a new temporary List will let us collect the items we want out of the source array
    List<int> evenFilteredList = new List<int>();

    foreach (int number in inputArray)
        if(number % 2 == 0) 
            evenFilteredList.Add(number);

    //dump the list to a new array, and sort it. We could sort the list but this works too.
    int[] filteredArray = evenFilteredList.ToArray();
    Array.Sort(filteredArray);

    //double the array's contents
    for (int i = 0; i < filteredArray.Length; i++)
        filteredArray[i] *= 2;

    return filteredArray;
}


IEnumerable<int> KeywordWork(int[] inputArray)
{
    var result = from n in inputArray
                  where n % 2 == 0
                  orderby n
                  select n * 2;

    return result;
}


IEnumerable<int> MethodQueryWork(int[] inputArray)
{
    return inputArray
        .Where(n => n % 2 == 0)
        .OrderBy(n => n)
        .Select(n => n * 2);
}



void PrintCollection(IEnumerable<int> collection)
{
    foreach(int i in collection)
        Console.Write($"{i}, ");
}