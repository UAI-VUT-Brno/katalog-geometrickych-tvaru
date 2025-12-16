using GeoShapes.src;
using Xunit;

namespace GeoShapes.Tests;

public class CircleTests
{
    [Fact]
    public void Area_IsCorrect()
    {
        var circle = new Circle("c", 1);
        Assert.Equal(Math.PI, circle.Area(), 5);
    }

    [Fact]
    public void NegativeRadius_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() =>
            new Circle("bad", -1));
    }
}
