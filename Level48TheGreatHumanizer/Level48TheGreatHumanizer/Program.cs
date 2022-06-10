/* This program utilizes NuGet to retrieve a NuGet package called Humanizer, that makes C#'s built in DateTime class more readable.
 * 
 * Objectives:
 * Display the given raw Date time:
 * Console.WriteLine($"When is the event? {DateTime.UtcNow.AddHours(30)}");
 * 
 * Add the NuGet package Humanizer.Core to this project. The package provides many extension methods that make it easy
 * to display things in more human-readable formats.
 * 
 * Call the new DateTime extension method Humanizer() provided by this library to get a better format. You will also need
 * to add a using Humanizer; directive to call this.
 * 
 * Run the program with a few different hour offsets (for example, DateTime.UtcNow.AddHours(2.5) and
 * DateTime.UtcNow.AddHours(50)) to see if it correctly displays a human readable message.
 */

using Humanizer;

// Main

//normal DateTime display
Console.WriteLine($"When is the event? {DateTime.UtcNow.AddHours(30)}");

//Humanized DateTime display
Console.WriteLine($"When is the event? {(DateTime.UtcNow.AddHours(30).Humanize())}");

// Different hour offsets
Console.WriteLine($"When is the event? {(DateTime.UtcNow.AddHours(5.7).Humanize())}");
Console.WriteLine($"When is the event? {(DateTime.UtcNow.AddHours(50).Humanize())}");