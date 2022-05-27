//this program contains a number of classes to emulate the functionality of a Pack that holds items.
//the pack has 3 fundemental limitations. The total number of items it can hold, the weight it can carry and the volume it can hold.
//Items that go into the pack have a weight and a volume, as you'd expect.
//but we must not overload a pack by adding too many items, too much weight or too much volume. Cant put 10 pounds of Nope in a 5 pound sack.

//there are many item types we might add to this inventory, each with their own class in the inventory system
//in no particular order:
//An Arrow has a weight of 0.1 and a volume of 0.05
//A bow has a weight of 1 and a volume of 4
//rope has a weight of 1 and a volume of 1.5
//a water ration has a weight of 2 and a volume of 3
//food rations have a weight of 1 and a volume of 0.5
//a sword has a weight of 5 and a volume of 3

//Objectives
//Create an InventoryItem base class that represents any of the other item types.
//this class must represent the items weight and volume which it needs at creation time (there must be a parameterized constructor)
//
//create derived classes for each of the types of items above. Each class should pass the correct weight and volume to the base class constructor
//but should be creatable themselves with a PARAMETERLESS constructor
//
//Create a Pack class that can store an array of items. The total number of items,
//the maximum weight and the maximum volume of the pack are provided at creation time and cannot be changed after.
//
//Make a public bool Add(InventoryItem item) method in the Pack class that allows you to add items
//of any type to the pack's contents. The method should fail (return fase, not edit the contents of Pack)
//if adding the item would cause it to exceed the pack's item, weight or volumetric limit.
//add properties to Pack that let it report back the current Item Count, Weight, Volume and the maximum limits of each.
//
//create a proigram that creates a new pack and allows the user to add or attempt to add items from a menu.





//main

//make a new pack and prompt a user to add items to it
//read back the remaining weight, volume and item space.

Pack pack = new Pack(10, 20, 20);

while(true)
{
    int choice = 0;
    Console.Clear();
    Console.WriteLine($"The pack has {pack.CurrentItems} items out of a maximum of {pack.ItemCapacity}");
    Console.WriteLine($"The pack weighs {pack.CurrentWeight} out of a maximum of {pack.WeightCapacity}");
    Console.WriteLine($"The pack's volume is {pack.CurrentVolume} out of a maximum of {pack.VolumeCapacity}\n\n");

    Console.WriteLine($"What item would you like to add?");
    Console.WriteLine($"1. An Arrow (w: 0.1 v: 0.05)");
    Console.WriteLine($"2. A Bow    (w: 1   v: 4)");
    Console.WriteLine($"3. A Rope   (w: 1   v: 1.5)");
    Console.WriteLine($"4. Canteen  (w: 2   v: 3)");
    Console.WriteLine($"5. Ration   (w: 1   v: 0.5)");
    Console.WriteLine($"6. A Sword  (w: 5   v: 3)");

    //capture user input
    while(true)
    {
        Console.WriteLine($"Enter a choice (1-6)");
        choice = Convert.ToInt32(Console.ReadLine());
        if(choice < 1 || choice > 6)
        {
            Console.WriteLine("Invalid Choice.");
        }
        else
        {
            break;
        }
    }

    //try adding the choice
    switch (choice) 
    {
        case 1:
            pack.AddItem(new Arrow());
            break;
        case 2:
            pack.AddItem(new Bow());
            break;
        case 3:
            pack.AddItem(new Rope());
            break;
        case 4:
            pack.AddItem(new Water());
            break;
        case 5:
            pack.AddItem(new Food());
            break;
        case 6:
            Sword sword = new Sword();
            pack.AddItem(sword);
            break;
        default:
            Console.WriteLine("Whoops!");
            break;


    }
}





//An Arrow has a weight of 0.1 and a volume of 0.05
//A bow has a weight of 1 and a volume of 4
//rope has a weight of 1 and a volume of 1.5
//a water ration has a weight of 2 and a volume of 3
//food rations have a weight of 1 and a volume of 0.5
//a sword has a weight of 5 and a volume of 3







//InventoryItem class
public class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }

    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

//InventoryItem Derived classes
public class Arrow : InventoryItem
{
    public Arrow() : base(0.1f, 0.5f) { }
}

public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }
}

public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }
}

public class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }
}

public class Food : InventoryItem
{
    public Food() : base(1f, 0.5f) { }
}

public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
}


//Pack class
public class Pack
{
    public int ItemCapacity { get; }
    public float WeightCapacity { get; }
    public float VolumeCapacity { get; }
    public int CurrentItems { get; private set; }
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }
    //collection of items will be stored in this array, and new items are only added by the add item method
    public InventoryItem[] Items { get; private set; }

    //let the user define how big the pack is, initialize the other properties to 0.
    public Pack(int itemCap, float weightCap, float volumeCap)
    {
        ItemCapacity = itemCap;
        WeightCapacity = weightCap;
        VolumeCapacity = volumeCap;
        CurrentItems = 0;
        CurrentWeight = 0;
        CurrentVolume = 0;
        Items = new InventoryItem[ItemCapacity];
    }

    //add item method
    public bool AddItem(InventoryItem item)
    {
        //check the Items array if it has any open(null) space
        //if so, check if the added item's weight and volume can fit in the pack.
        //if so add the item to the array, return true
        //if not, return false
        for(int i = 0; i < Items.Length; i++)
        {
            //check for an open space and if it can fit.
            if(Items[i] == null && WeightCapacity >= (CurrentWeight+item.Weight) && VolumeCapacity >= (CurrentVolume + item.Volume))
            {
                Items[i] = item;
                CurrentWeight = CurrentWeight+item.Weight;
                CurrentVolume = CurrentVolume+item.Volume;
                CurrentItems++;
                return true;
            }
        }
        //no space in the bag
        return false;
    }
}