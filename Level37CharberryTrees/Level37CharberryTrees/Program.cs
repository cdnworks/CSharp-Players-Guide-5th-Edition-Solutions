/* This is a demonstration of events and event handling.
 * 
 * Objectives:
 * Make a new project that includes the given code
 * 
 * Add a Ripened event to the CharberryTree class that is raised when the tree ripens.
 * 
 * Make a Notifier class that knows about the tree (Hint: perhaps pass it in
 * as a constructor parameter) and subscribes to its Ripened event. Attach a handler that displays something like
 * "A charberry fruit has ripened" to the console window
 * 
 * Make a Harvester class that knows about the tree (Hint: like the notifier,
 * this could be passed as a constructor parameter) and subscribes to its Ripened event.
 * Attach a handler that sets the tree's Ripe property back to false.
 * 
 * Update your main method to create a tree, notifier, and harvester, and get them to work together
 * to grow, notify and harvest forever.
 * 
 */


// Main 
CharberryTree tree = new CharberryTree();
Notifier notifier = new Notifier(tree);
Harvester harvester = new Harvester(tree);

while (true)
{
    tree.MaybeGrow();
}





// Type Defs

public class Notifier
{
    // unlike the Harvester class, the Notifier class doesnt do any operations on the tree, and doesnt need to hold a backing field for it.
    public Notifier(CharberryTree tree)
    {
        //subscribe to the CharberryTree's Ripened event
        tree.Ripened += OnRipened;
    }

    private void OnRipened()
    {
        //report the tree's Ripe state is now true
        Console.WriteLine("A charberry fruit has ripened.");
    }
}


public class Harvester
{
    // in order to perform operations on the tree object, we need to have a backing field to hold the reference to it.
    private CharberryTree _tree;
    private int _harvestCount;
    public Harvester(CharberryTree tree)
    {
        //subscribe to the CharberryTree's Ripened event
        _tree = tree;
        _tree.Ripened += OnRipened;
    }

    private void OnRipened()
    {
        //revert the tree's Ripe state to false
        _tree.Ripe = false;
        //add to the harvest count and report the number of harvests
        _harvestCount++;
        Console.WriteLine($"Total harvests: {_harvestCount}");
    }
}


public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }
    //Event
    public event Action? Ripened;

    public void MaybeGrow()
    {
        //Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            //fire the event when the tree ripens
            Ripened?.Invoke();
        }
    }
}