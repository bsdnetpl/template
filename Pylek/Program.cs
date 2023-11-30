using System;
using System.Collections.Generic;

// Interfejs opisujący obiekt "pyłka"
public interface IFlyweight
{
    void Operation();
}

// Konkretny obiekt "pyłka"
public class ConcreteFlyweight : IFlyweight
{
    private string _intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        _intrinsicState = intrinsicState;
    }

    public void Operation()
    {
        Console.WriteLine($"ConcreteFlyweight: {_intrinsicState}");
    }
}

// Fabryka obiektów "pyłka"
public class FlyweightFactory
{
    private Dictionary<string, IFlyweight> _flyweights = new Dictionary<string, IFlyweight>();

    public IFlyweight GetFlyweight(string key)
    {
        if (_flyweights.ContainsKey(key))
        {
            return _flyweights[key];
        }
        else
        {
            IFlyweight flyweight = new ConcreteFlyweight(key);
            _flyweights.Add(key, flyweight);
            return flyweight;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        FlyweightFactory factory = new FlyweightFactory();

        IFlyweight flyweight1 = factory.GetFlyweight("Shared");
        flyweight1.Operation(); // Współdzielony obiekt "pyłka"

        IFlyweight flyweight2 = factory.GetFlyweight("Another");
        flyweight2.Operation(); // Inny współdzielony obiekt "pyłka"

        IFlyweight flyweight3 = factory.GetFlyweight("Shared");
        flyweight3.Operation(); // Ponownie współdzielony obiekt "pyłka"

        Console.ReadKey();
    }
}
