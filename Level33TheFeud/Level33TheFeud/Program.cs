/* This program is an exercise in using namespaces and resolving type conflicts.
 * 
 * Objectives
 * Create a Sheep class in the IField namespace (fully qualified name of IField.Sheep)
 * Create a pig class in IField namespace (fully qualified name of IField.Pig)
 * Create a Cow class in the McDroid namespace (fully qualified name of McDroid.Cow)
 * Create a pig class in the McDroid namespace (fully qualified name of McDroid.Pig)
 * 
 * for the main method, add using directives for both IFieldand McDroid namespaces. Make new instances
 * of all four classes.There are no conflicts with Sheep and Cow, so make sure you can create
 * new instances of these with new Sheep() and new Cow(). Resolve the conflicting Pig classes with either
 * an alias or fully qualified names.
 * 
 */


using IField;
using McDroid;

//aliases for the conflicting Pig classes
using IPig = IField.Pig;
using McPig = McDroid.Pig;



Sheep sheep = new Sheep();
IPig pig1 = new IPig(); //aliased IField pig
IField.Pig iFieldPig = new IField.Pig(); //fully qualified IField pig

Cow cow = new Cow();
McPig pig2 = new McPig(); //aliased McDroid pig
McDroid.Pig mcDroidPig = new McDroid.Pig(); //fully qualified McDroid pig




sheep.Noise();
pig1.Noise();
iFieldPig.Noise();


cow.Noise();
pig2.Noise();
mcDroidPig.Noise();








//=================== TYPE DEFS ===========================

namespace IField
{
    public class Sheep
    {
        //do sheep things
        public void Noise()
        {
            Console.WriteLine("Baaa");
        }
    }

    public class Pig
    {
        //do pig things
        public void Noise()
        {
            //makes a different noise than a McDroid pig
            Console.WriteLine("iOink");
        }
    }

}

namespace McDroid
{
    public class Cow
    {
        //do cow things
        public void Noise()
        {
            Console.WriteLine("Moo");
        }
    }

    public class Pig
    {
        //do pig things
        public void Noise()
        {
            //makes a differnt noise than a IField pig
            Console.WriteLine("McOink");
        }
    }

}