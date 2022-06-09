/* This program demonstrates some basic uses of the Thread namespace and concurrency techniques.
 * 
 * Objectives:
 * Make a RecentNumbers class that holds at least the two most recent numbers.
 * 
 * Make a method that loops forever, generating random numbers from 0 to 9 once a second. (Hint: Thread.Sleep can help)
 * 
 * Write the numbers to the console window, put the generated numbers in a RecentNumbers object, and update it as new numbers are generated.
 * 
 * Make a thread that runs the above method.
 * 
 * Wait for the user to push a key in a second loop (on the main thread or another new thread)
 * When the user presses a key, check if the last two numbers are the same, if they are,
 * tell the user that they correctly identified the repeat. If they are not, indicate they got it wrong
 * 
 * Use lock statements to ensure that only one thread accesses the shared data at a time.
 * 
 */


// Main
RecentNumbers recentNumbers = new RecentNumbers() { NewestNumber = -1, OldestNumber = -2}; // initialize the numbers to something impossible to generate so we dont create a false positive duplicate
Thread numberGenerationThread = new Thread(GenerateNumbers);
numberGenerationThread.Start(recentNumbers);

while(true)
{
    Console.ReadKey(false);

    bool isSame;

    //access recentNumbers to check if the numbers are the same. Use a lock
    lock(recentNumbers)
    {
        isSame = recentNumbers.NewestNumber == recentNumbers.OldestNumber;
    }

    if(isSame)
    {
        Console.WriteLine("Duplicate number found! How lucky!");
    }
    else
    {
        Console.WriteLine("No duplicate found.");
    }



}



// Methods
void GenerateNumbers(object? o)
{
    // this method is ordinarily dangerous to run as it will just loop forever, however in a separate thread
    // it can continue generating new numbers as the main thread finishes it's own work

    //null input/bad type check
    if (o == null || o is not RecentNumbers) return;
    
    //convert the passed in object back to a RecentNumbers object, for use with a lock statement
    RecentNumbers recentNumbers = (RecentNumbers)o;
    Random random = new Random();
    
    while(true)
    {
        // generate a new number from 0 to 9, then shuffle RecentNumbers values, then wait 1 second. Repeat.
        //lock access to recent numbers until it's been updated correctly
        int number = random.Next(10);

        lock(recentNumbers)
        {
            recentNumbers.OldestNumber = recentNumbers.NewestNumber;
            recentNumbers.NewestNumber = number;
        }

        Console.WriteLine(number);
        Thread.Sleep(1000);


    }
}


// Type defs

public class RecentNumbers
{
    public int OldestNumber { get; set; }
    public int NewestNumber { get; set; }
}