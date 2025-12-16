using GeoShapes.src;
using Xunit;

namespace GeoShapes.Tests;

public class CatalogJsonTests
{
    private const string FileName = "catalog.json";

    [Fact]
    public void SaveAndLoad_WithRealShape_CreatesAndDeletesJson()
    {
        // ARRANGE (příprava)
        if (File.Exists(FileName))
            File.Delete(FileName);

        var catalog = new Catalog();
        catalog.Add(new Circle("C", 1));

        // ACT (akce)
        var loaded = new Catalog();
        loaded.Load();

        // ASSERT (ověření)
        Assert.Single(loaded.GetAll());

        // CLEANUP (úklid)
        if (File.Exists(FileName))
            File.Delete(FileName);
    }
}