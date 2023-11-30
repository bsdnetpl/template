using System;

// Klasa reprezentująca produkt, który chcemy zbudować
class Product
{
    public string PartA { get; set; }
    public string PartB { get; set; }
    public string PartC { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"PartA: {PartA}");
        Console.WriteLine($"PartB: {PartB}");
        Console.WriteLine($"PartC: {PartC}");
    }
}

// Interfejs budowniczego określający kroki do konstrukcji produktu
interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Product GetResult();
}

// Konkretny budowniczy implementujący interfejs IBuilder
class ConcreteBuilder : IBuilder
{
    private Product _product = new Product();

    public void BuildPartA()
    {
        _product.PartA = "Part A built";
    }

    public void BuildPartB()
    {
        _product.PartB = "Part B built";
    }

    public void BuildPartC()
    {
        _product.PartC = "Part C built";
    }

    public Product GetResult()
    {
        return _product;
    }
}

// Klasa dyrektora, która zarządza procesem konstruowania produktu
class Director
{
    private IBuilder _builder;

    public Director(IBuilder builder)
    {
        _builder = builder;
    }

    public void Construct()
    {
        _builder.BuildPartA();
        _builder.BuildPartB();
        _builder.BuildPartC();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie konkretnego budowniczego
        IBuilder builder = new ConcreteBuilder();

        // Tworzenie dyrektora
        Director director = new Director(builder);

        // Wykonanie procesu konstrukcji produktu
        director.Construct();

        // Pobranie gotowego produktu z budowniczego
        Product product = builder.GetResult();

        // Wyświetlenie informacji o produkcie
        product.ShowInfo();

        Console.ReadKey();
    }
}
