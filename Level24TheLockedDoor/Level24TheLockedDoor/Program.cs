// See https://aka.ms/new-console-template for more information

//this program contains a door class, that simulates a door object that has:
//a locking mechanism that requires a unique numeric code to unlock.

//the door has a number of properties, describing it's operation
//An Open door can always be closed.
//a closed and unlocked door can always be opened
//a closed and unlocked door may always locked
//a locked door can be unlocked with the correct passcode.
//a locked door cannot be opened until unlocked

//furthermore the problem statement expects the following
//when a door object is created, it MUST be given an initial passcode.
//you should be able to change the passcode by supplying the current code and a new one.
//the code should only change if the correct current code is given.

//objectives:
//define a door class that can keep track of if it is locked, open or closed
//make it so we can perform the four transitions defined above with METHODS
//build a constructor that requires a starting numeric passcode.
//build a METHOD that allows the passcode to change by supplying the current passcode and a new one.
//The main method asks the user for a starting passcode, then creates a new Door instance.
//then the user may attempt the four transitions (open <-> closed <-> locked).



//main
Console.WriteLine("enter a numerical passcode for the door: ");
int passcode = Convert.ToInt32(Console.ReadLine());
Door door = new Door(passcode);


//after the door is made, let the user play with it
while(true)
{
    Console.WriteLine($"The door is {door.State}. What would you like to do to the door?");
    Console.WriteLine("You may try to 'open', 'close', 'lock' or 'unlock' the door. Furthermore you may 'reset' the door's passcode");
    string action = Console.ReadLine();

    switch (action)
    {
        case "open":
            {
                door.OpenDoor();
                break;
            }
        case "close":
            {
                door.CloseDoor();
                break;
            }
        case "lock":
            {
                Console.WriteLine("Enter the passcode: ");
                int pass = Convert.ToInt32(Console.ReadLine());
                door.LockDoor(pass);
                break;
            }
        case "unlock":
            {
                Console.WriteLine("Enter the passcode: ");
                int pass = Convert.ToInt32(Console.ReadLine());
                door.UnlockDoor(pass);
                break;
            }
        case "reset":
            {
                Console.WriteLine("Enter the passcode: ");
                int oldPass = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your new numeric passcode: ");
                int newPass = Convert.ToInt32(Console.ReadLine());
                door.MakeNewPasscode(oldPass, newPass);
                break;
            }
        default:
            {
                Console.WriteLine("Unknown command. Try entering 'open', 'close', 'lock', 'unlock' or 'reset'.");
                break;
            }
    }
}








public class Door
{

    private DoorState _doorState;
    private int _passcode;

    //constructor, defaults door to locked state
    public Door (int passcode)
    {
        _passcode = passcode;
        _doorState = DoorState.Locked;
    }

    //door operations
    public void OpenDoor()
    {
        if (_doorState == DoorState.Closed) _doorState = DoorState.Open;
    }
    public void CloseDoor()
    {
        if (_doorState == DoorState.Open) _doorState = DoorState.Closed;
    }
    public void LockDoor(int passcode)
    {
        if (_doorState == DoorState.Closed && passcode == _passcode) _doorState = DoorState.Locked;

    }
    public void UnlockDoor(int passcode)
    {
        if (_doorState == DoorState.Locked && passcode == _passcode) _doorState = DoorState.Closed;
    }

    //passcode reassignment
    public void MakeNewPasscode(int currentPasscode, int newPasscode)
    {
        if(currentPasscode == _passcode) _passcode = newPasscode;
    }

    //door status
    public DoorState State
    {
        get
        {
            return _doorState;
        }
    }

}






//enum definitions for the door
public enum DoorState { Open, Closed, Locked }