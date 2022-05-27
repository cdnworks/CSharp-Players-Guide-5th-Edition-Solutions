// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//this is a simple state machine with 3 states
//open, closed and locked. Each state contains one entry and one exit
//i.e.  open -> closed -> locked
//      open <- closed <- locked


//initialize the chest enum as locked, since the prompt said its locked
Chest chestState = Chest.Locked;

//this program just runs forever
while(true)
{
    Console.WriteLine($"The chest is {chestState}. What would you like to do?");
    Console.WriteLine("You may 'unlock', 'lock', 'open', or 'close' the chest.");
    string command = Console.ReadLine();

    if (chestState == Chest.Locked && command == "unlock") chestState = Chest.Closed;
    if (chestState == Chest.Closed && command == "open") chestState = Chest.Open;
    if (chestState == Chest.Closed && command == "lock") chestState = Chest.Locked;
    if (chestState == Chest.Open && command == "close") chestState = Chest.Closed;
}







//enum definition for the chest states
enum Chest { Open, Closed, Locked }
