using GeoShapes.src;

namespace GeoShapes.src;

public class UserInterface
{
    private readonly Catalog _catalog;

    public UserInterface(Catalog catalog)
    {
        _catalog = catalog;
    }

    public void Run()
    {
        Console.WriteLine("Vítejte v katalogu s názvem GeoShapes! Zvolte číslo:");

        while (true)
        {
            ShowMenu();
            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        AddCircle();
                        break;
                    case "2":
                        AddRectangle();
                        break;
                    case "3":
                        AddTriangle();
                        break;
                    case "4":
                        ListShapes();
                        break;
                    case "5":
                        CompareShapes();
                        break;
                        case "6":
                         DeleteShape();
                         break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Neplatná volba.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba: {ex.Message}");
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("1 - Přidat kruh");
        Console.WriteLine("2 - Přidat obdélník");
        Console.WriteLine("3 - Přidat trojúhelník");
        Console.WriteLine("4 - Vypsat tvary");
        Console.WriteLine("5 - Porovnat dva tvary");
        Console.WriteLine("6 - Smazat tvar");
        Console.WriteLine("0 - Konec");
        Console.Write("Volba: ");
    }

    private void AddCircle()
    {
        Console.Write("Název: ");
        string name = Console.ReadLine()!;
        Console.Write("Poloměr: ");
        double r = double.Parse(Console.ReadLine()!);

        _catalog.Add(new Circle(name, r));
        Console.WriteLine("Kruh přidán.");
    }

    private void AddRectangle()
    {
        Console.Write("Název: ");
        string name = Console.ReadLine()!;
        Console.Write("Šířka: ");
        double w = double.Parse(Console.ReadLine()!);
        Console.Write("Výška: ");
        double h = double.Parse(Console.ReadLine()!);

        _catalog.Add(new Rectangle(name, w, h));
        Console.WriteLine("Obdélník přidán.");
    }

    private void AddTriangle()
    {
        Console.Write("Název: ");
        string name = Console.ReadLine()!;
        Console.Write("Strana A: ");
        double a = double.Parse(Console.ReadLine()!);
        Console.Write("Strana B: ");
        double b = double.Parse(Console.ReadLine()!);
        Console.Write("Strana C: ");
        double c = double.Parse(Console.ReadLine()!);

        _catalog.Add(new Triangle(name, a, b, c));
        Console.WriteLine("Trojúhelník přidán.");
    }

    private void ListShapes()
    {
        if (!_catalog.GetAll().Any())
        {
            Console.WriteLine("Katalog je prázdný.");
            return;
        }

        foreach (var s in _catalog.GetAll())
        {
            Console.WriteLine(
                $"{s.Name} | Plocha: {s.Area():0.00} | Obvod: {s.Perimeter():0.00}"
            );
        }
    }

    private void CompareShapes()
    {
        Console.Write("Název prvního tvaru: ");
        string name1 = Console.ReadLine()!;
        Console.Write("Název druhého tvaru: ");
        string name2 = Console.ReadLine()!;

        var s1 = _catalog.Find(name1);
        var s2 = _catalog.Find(name2);

        if (s1 == null || s2 == null)
        {
            Console.WriteLine("Tvar nenalezen.");
            return;
        }

        int result = _catalog.CompareByArea(s1, s2);

        if (result > 0)
            Console.WriteLine($"{s1.Name} má větší plochu.");
        else if (result < 0)
            Console.WriteLine($"{s2.Name} má větší plochu.");
        else
            Console.WriteLine("Tvary mají stejnou plochu.");
    }private void DeleteShape()
    {
    Console.Write("Název tvaru ke smazání: ");
    string name = Console.ReadLine()!;

    if (_catalog.Remove(name))
        Console.WriteLine("Tvar smazán.");
    else
        Console.WriteLine("Tvar nenalezen.");
    }

}
