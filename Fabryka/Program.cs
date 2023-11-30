using System;

// Interfejs produktu
public interface IProduct
{
    void Info();
}

// Konkretne implementacje produktu
public class ConcreteProductA : IProduct
{
    public void Info()
    {
        Console.WriteLine("This is ConcreteProductA.");
    }
}

public class ConcreteProductB : IProduct
{
    public void Info()
    {
        Console.WriteLine("This is ConcreteProductB.");
    }
}

// Fabryka abstrakcyjna
public interface IFactory
{
    IProduct CreateProduct();
}

// Konkretne fabryki tworzące konkretne produkty
public class ConcreteFactoryA : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteFactoryB : IFactory
{
    public IProduct CreateProduct()
    {
        return new ConcreteProductB();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Utworzenie fabryki A
        IFactory factoryA = new ConcreteFactoryA();
        // Utworzenie produktu z fabryki A
        IProduct productA = factoryA.CreateProduct();
        productA.Info();

        // Utworzenie fabryki B
        IFactory factoryB = new ConcreteFactoryB();
        // Utworzenie produktu z fabryki B
        IProduct productB = factoryB.CreateProduct();
        productB.Info();

        Console.ReadKey();
    }
}
