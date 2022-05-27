/* this program contains a generic ColoredItem class that associates a color with a given item
 * 
 * objectives
 * put the three class definitions into a new project
 * 
 * define a generic class to represent a colored item. It must have properties for the item itself (generic in type)
 * and a ConsoleColor associated with it
 * 
 * add a void Display() method to the colored item type that changes the console's foreground color to the item's color
 * and displays the item in that color. (use ToString() on the item to get a text representation)
 * 
 * in the main method create a new colored item containing a blue sword, a red bow and a green axe
 * 
 * display all three items to see each item displayed in it's color
 */


//main
ColoredItem<Sword> blueSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Cyan);
ColoredItem<Bow> redBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> greenAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

Console.WriteLine("Wow look at these colors");

blueSword.Display();
redBow.Display();
greenAxe.Display();

Console.WriteLine("Wow look at these colors");




//class defs

public class Sword { public override string ToString() => "Sword"; }
public class Bow { public override string ToString() => "Bow"; }
public class Axe { public override string ToString() => "Axe"; }



public class ColoredItem<T>
{
    public T Item { get; }
    public ConsoleColor Color { get; }

    public ColoredItem(T item, ConsoleColor color)
    {
        Item = item;
        Color = color;
    }




    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item.ToString());
        Console.ForegroundColor = ConsoleColor.White;
    }
}

