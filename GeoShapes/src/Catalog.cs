using System.Text.Json;

namespace GeoShapes.src;

public class Catalog
{
    private readonly List<IShape> _shapes = new();

    private const string FileName = "catalog.json";

    public void Add(IShape shape)
    {
        _shapes.Add(shape);
        Save();
    }

    public bool Remove(string name)
    {
        var shape = Find(name);
        if (shape == null)
            return false;

        _shapes.Remove(shape);
        Save();
        return true;
    }

    public IShape? Find(string name)
    {
        return _shapes.FirstOrDefault(s => s.Name == name);
    }

    public IReadOnlyList<IShape> GetAll() => _shapes;

    public int CompareByArea(IShape a, IShape b)
    {
        return a.Area().CompareTo(b.Area());
    }

    // ===== JSON =====

    public void Save()
    {
        var dto = _shapes.Select(s => ShapeDto.FromShape(s)).ToList();

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        File.WriteAllText(FileName, JsonSerializer.Serialize(dto, options));
    }

    public void Load()
    {
        if (!File.Exists(FileName))
            return;

        var json = File.ReadAllText(FileName);
        var dtoList = JsonSerializer.Deserialize<List<ShapeDto>>(json);

        _shapes.Clear();

        if (dtoList == null)
            return;

        foreach (var dto in dtoList)
        {
            _shapes.Add(dto.ToShape());
        }
    }
}
