using GeoShapes.src;
using GeoShapes.Tests.Fakes;
using Xunit;

public class CatalogTests
{
    [Fact]
    public void CompareByArea_Works()
    {
        var cat = new Catalog();

        var a = new FakeShape("A", 10);
        var b = new FakeShape("B", 20);

        Assert.True(cat.CompareByArea(a, b) < 0);
    }
}
