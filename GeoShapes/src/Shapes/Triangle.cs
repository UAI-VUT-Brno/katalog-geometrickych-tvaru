namespace GeoShapes.src;

public class Triangle : IShape
{
    public string Name { get; }
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public Triangle(string name, double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("Strany musí být kladné.");

        if (a + b <= c || a + c <= b || b + c <= a)
            throw new ArgumentException("Neplatný trojúhelník.");

        Name = name;
        A = a;
        B = b;
        C = c;
    }

    public double Perimeter() => A + B + C;

    public double Area()
    {
        double s = Perimeter() / 2;
        return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
    }
}
