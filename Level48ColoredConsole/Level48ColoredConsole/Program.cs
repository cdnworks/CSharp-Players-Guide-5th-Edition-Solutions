/* This program utilizes a second project containing a helper class called ColoredConsole
 * 
 */

using ColorConsole;

// Main

string name = ColoredConsole.Prompt("What is your name?");
ColoredConsole.WriteLine("Hello " + name, ConsoleColor.Green);