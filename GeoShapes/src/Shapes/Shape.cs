namespace GeoShapes.src;

public interface IShape
{
    string Name { get; }
    double Area();
    double Perimeter();
}