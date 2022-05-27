//this program contains a record called Sword that holds material, gemstone, length and crossguard width properties.
//
// the materials can be: wood, bronze, iron, steel and rare binarium
//
// gemstones can be emerald, amber, sapphire, diamond, no gemstone or rare bitstone
//
// materials and gemstones must be created as enumerations
//
// the main program creates a basic sword instance made out of iron and no gemstone, then two varioations on the basic
// sword must be made using with expressions (as this sword is a record)
//
// display all three sword instances with code like Console.WriteLine(original)


//main
Sword original = new Sword(Material.iron, Gemstone.none, 100, 15);
Sword custom1 = original with { Material = Material.steel, Gemstone = Gemstone.amber };
Sword custom2 = original with { Gemstone = Gemstone.bitstone, Length = 200, GuardWidth = 20};


Console.WriteLine(original);
Console.WriteLine(custom1);
Console.WriteLine(custom2);



//sword record
public record Sword (Material Material, Gemstone Gemstone, float Length, float GuardWidth);


//enum definitions
public enum Material { wood, bronze, iron, steel, binarium}
public enum Gemstone { emerald, amber, sapphire, diamond, none, bitstone}