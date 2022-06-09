/* This program demonstrates basic Task usage for asynchronous work
 * 
 * Objectives:
 * Make the method int RandomlyRecreate(string word)
 * It should take the string's length and generate an equal number of random characters. It is okay to assume
 * all words only use lowercase letters. One way to randomly generate a lowercase letter is (char)('a' + random.Next(26))
 * This method should loop until it randomly generates the target word, counting the required attempts.
 * The return value is the number of attempts
 * 
 * Make the method Task<int> RandomlyRecreateAsync(string word) that schedules the above method to run asynchronously (Task.Run is an option)
 * 
 * Have your main method ask the user for a word. Run the RandomlyRecreateAsync method and await its result and display it.
 * NoteL Be careful about long words! For me, a five-letter word took several seconds, and my math indicates a 10 letter word may take 
 * nearly two years.
 * 
 * Use DateTime.Now before and after the async task runs to measure the wall clock time it took. Display the time elapsed.
 * 
 */


// Main
Console.Write("enter a word: ");
string? inputWord = Console.ReadLine();

DateTime startTime = DateTime.Now;
int attempts = await RandomlyRecreateAsync(inputWord);
TimeSpan runTime = DateTime.Now - startTime;


Console.WriteLine($"Took {attempts} attempts to recreate '{inputWord}'");
Console.WriteLine($"Run time: {runTime}");

// Methods

int RandomlyRecreate(string? word)
{
    // null check
    if (word == null) return 0;

    int attempts = 0;
    string randomWord = null;
    Random random = new Random();


    while(true)
    {
        //generate a word from random characters, of the same length as the input word
        for(int i = 0; i < word.Length; i++)
        {
            randomWord += (char)('a' + random.Next(26));
        }

        attempts++;

        //we are assuming the input word is already lowercase when this comparison is made
        if (randomWord == word) break;
        else randomWord = null; //reset the generated word if it's not a match
    }

    return attempts;

}




Task<int> RandomlyRecreateAsync(string? word)
{
    return Task.Run(() => RandomlyRecreate(word));
}
