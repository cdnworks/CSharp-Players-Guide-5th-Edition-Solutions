/*
 * Some nerds in a village often use the Random class but they strugle with it's limited capabilities. They want you
 * to make Random a bit better.
 * 
 * Random.NextDouble() only returns values between 0 and 1. They often need to be able to produce random double value
 * between 0 and another number, such as 0 to 10.
 * 
 * They need to randomly choose from one of several strings, such as "up", "down", "left" and "right".
 * with each having an equal probability of being chosen.
 * 
 * They need to do a coin toss, randomly picking a bool, and usually want it to be a fair coin toss (50/50)
 * but occasionally want unequal probabilities. For example, a 75% chance of true and a 25% chance of false.
 * 
 * 
 * Objectives:
 * Create a new static class to add extension methods for Random.
 * 
 * As described above, add a NextDouble extension method that gives a maximum value for a randomly generated double.
 * 
 * Add a NextString extention method for Random that allows you to pass in any number of string values (using params string[])
 * and randomly pick one of them
 * 
 * Add a CoinFlip method that randomly picks a bool value. It should have an optional parameter that indicates the frequency
 * of heads coming up, which should default to 0.5 or 50% of the time.
 * 
 * Answer the following: in your opinnion would it be better to make a derived AdvancedRandom class that adds these methods or
 * use extension methods and why?
 * 
 * 
 */

Random random = new Random();

Console.WriteLine(random.NextDouble(5.8));
Console.WriteLine(random.NextString("left", "right", "forward", "back"));
Console.WriteLine(random.CoinFlip());
Console.WriteLine(random.CoinFlip(0.75));






public static class RandomExtensions
{
    public static double NextDouble(this Random random, double max)
    {
        return random.NextDouble() * max;
    }

    public static string NextString(this Random random, params string[] words)
    {
        return words[random.Next(words.Length)];
    }

    public static bool CoinFlip(this Random random, double probabilityOfHeads = 0.5)
    {
        return (random.NextDouble() < probabilityOfHeads);
    }
}

