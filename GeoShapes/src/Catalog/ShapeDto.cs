namespace GeoShapes.src;

public class ShapeDto
{
    public string Type { get; set; } = "";
    public string Name { get; set; } = "";

    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public static ShapeDto FromShape(IShape shape)
    {
        return shape switch
        {
            Circle c => new ShapeDto
            {
                Type = "Circle",
                Name = c.Name,
                A = c.Radius
            },
            Rectangle r => new ShapeDto
            {
                Type = "Rectangle",
                Name = r.Name,
                A = r.Width,
                B = r.Height
            },
            Triangle t => new ShapeDto
            {
                Type = "Triangle",
                Name = t.Name,
                A = t.A,
                B = t.B,
                C = t.C
            },
            _ => throw new InvalidOperationException("Neznámý tvar")
        };
    }

    public IShape ToShape()
    {
        return Type switch
        {
            "Circle" => new Circle(Name, A),
            "Rectangle" => new Rectangle(Name, A, B),
            "Triangle" => new Triangle(Name, A, B, C),
            _ => throw new InvalidOperationException("Neznámý typ tvaru")
        };
    }
}
