using System;
using System.Collections.Generic;

// Interfejs komponentu, który definiuje operacje dla zarówno pojedynczych obiektów, jak i grupy obiektów
public interface IComponent
{
    void DisplayInfo();
}

// Implementacja konkretnego komponentu (Liść)
public class Leaf : IComponent
{
    private readonly string _name;

    public Leaf(string name)
    {
        _name = name;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Leaf: {_name}");
    }
}

// Implementacja kompozytu, który może zawierać zarówno pojedyncze obiekty jak i grupy obiektów
public class Composite : IComponent
{
    private readonly List<IComponent> _children = new List<IComponent>();

    public void Add(IComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IComponent component)
    {
        _children.Remove(component);
    }

    public void DisplayInfo()
    {
        foreach (var child in _children)
        {
            child.DisplayInfo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie liści
        Leaf leaf1 = new Leaf("Leaf 1");
        Leaf leaf2 = new Leaf("Leaf 2");
        Leaf leaf3 = new Leaf("Leaf 3");

        // Tworzenie kompozytu i dodawanie liści do kompozytu
        Composite composite = new Composite();
        composite.Add(leaf1);
        composite.Add(leaf2);

        // Wyświetlanie informacji o kompozycie (w tym liściach)
        Console.WriteLine("Displaying information about the composite:");
        composite.DisplayInfo();

        Console.WriteLine("\nAdding Leaf 3 to Composite:");
        composite.Add(leaf3);
        composite.DisplayInfo();

        Console.ReadKey();
    }
}
