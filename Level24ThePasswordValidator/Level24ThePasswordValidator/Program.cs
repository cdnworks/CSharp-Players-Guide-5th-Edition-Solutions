// See https://aka.ms/new-console-template for more information

//this program contains a PasswordValidator class that, unsurprisingly, validates a given password.

//the password rules expected by the validator are as follows:
//Passwords must be at least 6 letters long, and no more than 13 letters long
//Passwords must contain at least one uppercase letter, one lowercase letter, and one number
//Passwords CANNOT contain a capital 'T' or an ampersand '&' just because.

//the PasswordValidator class can be given a password and determine if it is valid via the rules above.
//the main method should loop forever, asking for a password and reporting if it is valid or not, using an instance of the PasswordValidator class.


//main
while (true)
{
    Console.WriteLine("Enter a password: ");
    PasswordValidator pv = new PasswordValidator(Convert.ToString(Console.ReadLine()));
    Console.WriteLine($"Is Password Valid?: {pv.IsValid}");
}



public class PasswordValidator
{
    //we dont need to retrieve this password ever.
    private string _password;

    //constructor
    public PasswordValidator(string password)
    {
        _password = password;
    }

    //validation property
    //this will call a number of internal methods, each evaluating the password against the prescribed rules
    //if all methods return true, the password is valid. Otherwise, it is invalid.
    //a more computationally effective implementation would combine each method so we dont have to iterate over it a bunch of times
    //however the password is small, so it shouldnt be too much of a loss.
    //I could be way off base here, and the author will smash them all together
    //but I am trying to follow their advice and encapsulate as many verbs as possible

    //alternatively for performance (though I dunno if it does this)
    //Evaluating each method one at a time might save on performance?
    //I dont know if it'll fail the if statement immediately (early) if one of the method calls returns false.
    public bool IsValid
    {
        get
        {
            //valiate
            if (CheckLength(_password) && CheckForUpper(_password) && CheckForLower(_password) && CheckForNumber(_password) && CheckForForbidden(_password)) return true;
            //if validation fails, return false
            return false;
        }

    }


    //validation methods, each used in the IsValid property
    private bool CheckLength(string password)
    {
        if (password.Length >= 6 && password.Length <= 13) return true;
        return false;
    }
    private bool CheckForUpper(string password)
    {
        foreach (char letter in password)
        {
            if (Char.IsUpper(letter)) return true;
        }
        return false;
    }
    private bool CheckForLower(string password)
    {
        foreach (char letter in password)
        {
            if (Char.IsLower(letter)) return true;
        }
        return false;
    }
    private bool CheckForNumber(string password)
    {
        foreach (char letter in password)
        {
            if (Char.IsDigit(letter)) return true;
        }
        return false;
    }

    //the logic here is flipped. We DO NOT WANT the forbidden characters, be careful using it in .IsValid
    private bool CheckForForbidden(string password)
    {
        foreach (char letter in password)
        {
            if (letter == 'T' || letter == '&') return false;
        }
        return true;

    }






}