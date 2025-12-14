using GeoShapes.src;
using Xunit;

public class IShapeTests
{
    [Fact]
    public void Circle_Area_IsCorrect()
    {
        var c = new Circle("kruh", 1);
        Assert.True(c.Area() > 3);
    }
}
