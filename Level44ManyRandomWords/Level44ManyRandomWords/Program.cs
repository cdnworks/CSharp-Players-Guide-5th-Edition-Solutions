/* This program is an extension of my level 44 implementation of Asynchronous Random words; that demonstrates basic Task usage for asynchronous work
 * this extension allows the main thread to keep taking user inputs for new words while 
 * 
 * Objectives:
 * Modify your program from the previous challenge to allow the main thread to keep waiting for the user to enter more words.
 * For every new word entered, create and run a task to compute the attempt count and the time elapsed and display the result,
 * but then let that run asynchronously while you wait for the next word. You can generate many words in parallel this way.
 * Hint: moving the elapsed time and output logic to another async method may make this easier
 * 
 */


// Main

while (true)
{
    Console.Write("enter a word: ");
    string? inputWord = Console.ReadLine();
    TakeWord(inputWord);
}




// Methods

int RandomlyRecreate(string? word)
{
    // null check
    if (word == null) return 0;

    int attempts = 0;
    string randomWord = null;
    Random random = new Random();


    while (true)
    {
        //generate a word from random characters, of the same length as the input word
        for (int i = 0; i < word.Length; i++)
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


async Task TakeWord(string? inputWord)
{
    DateTime startTime = DateTime.Now;
    int attempts = await RandomlyRecreateAsync(inputWord);
    TimeSpan runTime = DateTime.Now - startTime;
    Console.WriteLine($"Took {attempts} attempts to recreate '{inputWord}'");
    Console.WriteLine($"Run time: {runTime}");
}
