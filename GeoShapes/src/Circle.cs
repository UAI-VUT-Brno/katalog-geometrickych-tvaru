namespace GeoShapes.src;

public class Circle : IShape
{
    public string Name { get; }
    public double Radius { get; }

    public Circle(string name, double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Poloměr musí být kladný.");

        Name = name;
        Radius = radius;
    }

    public double Area() => Math.PI * Radius * Radius;

    public double Perimeter() => 2 * Math.PI * Radius;
}
