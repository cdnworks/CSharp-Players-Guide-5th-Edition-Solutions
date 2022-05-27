// See https://aka.ms/new-console-template for more information

//this program contains a Point class to store a point in two dimensions.
//Each point is represented by an x and y coordinate, following cartesian conventions.
//the main method will be for demonstration purposes.


Point point1 = new Point(2, 3);
Point point2 = new Point(-4, 0);
Point point3 = new Point();

Console.WriteLine($"({point1.Xcoordinate},{point1.Ycoordinate})");
Console.WriteLine($"({point2.Xcoordinate},{point2.Ycoordinate})");
Console.WriteLine($"({point3.Xcoordinate},{point3.Ycoordinate})");






public class Point
{
    public float Xcoordinate { get; }
    public float Ycoordinate { get; }

    //constructors
    public Point ()
    {
        //default constructor, builds a point at the origin (0,0)
        Xcoordinate = 0;
        Ycoordinate = 0;
    }

    public Point (float x, float y)
    {
        //custom point constructor
        Xcoordinate = x;
        Ycoordinate = y;
    }



}
