/*This program is a modified version of the level 25 program Packing inventory
 * here we will be doing the folling things:
 * 
 * Override the existing ToString method (from the object base class) on *all* inventory
 * subclass items to give them a name. 
 * For example, new Rope().ToString() should return "Rope"
 * 
 * Override ToString on the Pack class to display the contents of the pack.
 * For example, if a pack contains water, rope, and two arrows:
 * calling new Pack().ToString should return 
 * Water Rope Arrow Arrow
 * 
 * Before the user chooses the next item to add, display the pack's current contents with
 * the new ToString method
 * 
 */

//main

//make a new pack and prompt a user to add items to it
//read back the remaining weight, volume and item space.

Pack pack = new Pack(10, 20, 20);

while (true)
{
    int choice = 0;
    Console.Clear();
    Console.WriteLine($"The pack has {pack.CurrentItems} items out of a maximum of {pack.ItemCapacity}");
    Console.WriteLine($"The pack weighs {pack.CurrentWeight} out of a maximum of {pack.WeightCapacity}");
    Console.WriteLine($"The pack's volume is {pack.CurrentVolume} out of a maximum of {pack.VolumeCapacity}");
    Console.WriteLine(pack.ToString() + "\n\n");

    Console.WriteLine($"What item would you like to add?");
    Console.WriteLine($"1. An Arrow (w: 0.1 v: 0.05)");
    Console.WriteLine($"2. A Bow    (w: 1   v: 4)");
    Console.WriteLine($"3. A Rope   (w: 1   v: 1.5)");
    Console.WriteLine($"4. Canteen  (w: 2   v: 3)");
    Console.WriteLine($"5. Ration   (w: 1   v: 0.5)");
    Console.WriteLine($"6. A Sword  (w: 5   v: 3)");

    //capture user input
    while (true)
    {
        Console.WriteLine($"Enter a choice (1-6)");
        choice = Convert.ToInt32(Console.ReadLine());
        if (choice < 1 || choice > 6)
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
    public override string ToString() => "Arrow";
}

public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }
    public override string ToString() => "Bow";
}

public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }
    public override string ToString() => "Rope";
}

public class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }
    public override string ToString() => "Water";
}

public class Food : InventoryItem
{
    public Food() : base(1f, 0.5f) { }
    public override string ToString() => "Food";
}

public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
    public override string ToString() => "Sword";
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
        for (int i = 0; i < Items.Length; i++)
        {
            //check for an open space and if it can fit.
            if (Items[i] == null && WeightCapacity >= (CurrentWeight + item.Weight) && VolumeCapacity >= (CurrentVolume + item.Volume))
            {
                Items[i] = item;
                CurrentWeight = CurrentWeight + item.Weight;
                CurrentVolume = CurrentVolume + item.Volume;
                CurrentItems++;
                return true;
            }
        }
        //no space in the bag
        return false;
    }

    //pack ToString override
    public override string ToString()
    {
        string packDisplay = "Pack contains: ";
        foreach(InventoryItem item in Items)
        {
            if(item != null)
            packDisplay = packDisplay + item.ToString() + " ";
        }
        return packDisplay;
    }
}