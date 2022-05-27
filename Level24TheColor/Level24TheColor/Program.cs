// See https://aka.ms/new-console-template for more information

//this program contains a class called Color that represents a given color.
//The color consists of three parts or channels, Red, Green and Blue.
//each channel has an intensity from 0 to 255, where 0 is completely 'off' and 255 is completely 'on'
//each channel is ordered (R,G,B)
//we are to also include commonly used colors with the associated channel ratios:
//White (255,255,255)
//Black (0,0,0)
//Red (255,0,0)
//Orange (255,165,0)
//Yellow (255,255,0)
//Green (0,128,0)
//Blue (0,0,255)
//Purple (128,0,128)

//the main method is for demonstration, containing a few Color typed variables, and then they can display the RGB channel values.

Color color1 = new Color(55, 55, 55);
Color color2 = new Color(-1, 260, 5);
Color red = Color.Red;

Console.WriteLine($"color 1 values: R:{color1.R} G:{color1.G} B:{color1.B}");
Console.WriteLine($"color 2 values: R:{color2.R} G:{color2.G} B:{color2.B}");
Console.WriteLine($"red values: R:{red.R} G:{red.G} B:{red.B}");



public class Color
{
    //the color class should contain 3 properties, each representing a 0-255 value (could be a byte, but I went with int and clamped the values)
    //color channels should be accessable and settable to modify the color per the user's wishes
    //eight static methods should be implemented to create the common colors listed above

    //default color is black
    private int _r = 0;
    private int _g = 0;
    private int _b = 0;

    //Channel properties
    //red channel
    public int R
    {
        get
        {
            return _r;
        }
        set
        {
            //define clamps for the input color value. the range is 0 to 255
            if(value < 0) _r = 0;
            else if (value > 255) _r = 255;
            else _r = value;
        }
    }

    //green channel
    public int G
    {
        get
        {
            return _g;
        }
        set
        {
            //define clamps for the input color value. the range is 0 to 255
            if (value < 0) _g = 0;
            else if (value > 255) _g = 255;
            else _g = value;
        }
    }

    //blue channel
    public int B
    {
        get
        {
            return _b;
        }
        set
        {
            //define clamps for the input color value. the range is 0 to 255
            if (value < 0) _b = 0;
            else if (value > 255) _b = 255;
            else _b = value;
        }
    }
    
    //constructor
    public Color (int r, int g, int b)
    {
        R = r;
        G = g;
        B = b;
    }

    //Static properties:
    public static Color White   { get; } = new Color(255,255,255);
    public static Color Black   { get; } = new Color(0,0,0);
    public static Color Red     { get; } = new Color(255,0,0);
    public static Color Orange  { get; } = new Color(255, 165, 0);
    public static Color Yellow  { get; } = new Color(255, 255, 0);
    public static Color Green   { get; } = new Color(0, 128, 0);
    public static Color Blue    { get; } = new Color(0, 0, 255);
    public static Color Purple  { get; } = new Color(128, 0, 128);


}
