// See https://aka.ms/new-console-template for more information

//this program stores two user input strings, a and b
Console.WriteLine("What kind of thing are we talking about?");
string a = Console.ReadLine(); //this is the thing we're adding cool adjectives to
Console.WriteLine("How would you describe it? Big? Azure? Tattered?");
string b = Console.ReadLine(); ; //this is the chief adjective defined by the user

/* it would be better practice to combine these two separate strings since we want
 * the 'b' 'a' of Doom 3000!
 * even better would probably be arranging our printed variables in alphabetical order
 * or even better yet, something more descriptive like
 * userNoun for a
 * userAdjective for b
 */

string c = "of Doom";
string d = "3000";
Console.WriteLine("The " + b + " " + a + " " + c + " " + d + "!");
