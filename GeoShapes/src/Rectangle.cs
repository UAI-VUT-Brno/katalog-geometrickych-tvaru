namespace GeoShapes.src;

public class Rectangle : IShape
{
    public string Name { get; }
    public double Width { get; }
    public double Height { get; }

    public Rectangle(string name, double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Rozměry musí být kladné.");

        Name = name;
        Width = width;
        Height = height;
    }

    public double Area() => Width * Height;

    public double Perimeter() => 2 * (Width + Height);
}
