using GeoShapes.src;

namespace GeoShapes.Tests.Fakes;

public class FakeShape : IShape
{
    public string Name { get; }
    private readonly double _area;

    public FakeShape(string name, double area)
    {
        Name = name;
        _area = area;
    }

    public double Area() => _area;

    public double Perimeter() => 0;
}
