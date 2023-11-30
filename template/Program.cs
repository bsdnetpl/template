using System;

// Komponent bazowy - interfejs komponentu
public interface ICar
{
    string GetDescription();
    double GetCost();
}

// Konkretna implementacja komponentu
public class BasicCar : ICar
{
    public string GetDescription()
    {
        return "Basic Car";
    }

    public double GetCost()
    {
        return 20000.0;
    }
}

// Abstrakcyjny dekorator
public abstract class CarDecorator : ICar
{
    protected ICar _car;

    public CarDecorator(ICar car)
    {
        _car = car;
    }

    public virtual string GetDescription()
    {
        return _car.GetDescription();
    }

    public virtual double GetCost()
    {
        return _car.GetCost();
    }
}

// Konkretny dekorator dodający nową funkcjonalność
public class SportsPackage : CarDecorator
{
    public SportsPackage(ICar car) : base(car)
    {
    }

    public override string GetDescription()
    {
        return $"{_car.GetDescription()}, Sports Package";
    }

    public override double GetCost()
    {
        return _car.GetCost() + 5000.0;
    }
}

// Inny konkretny dekorator
public class LuxuryPackage : CarDecorator
{
    public LuxuryPackage(ICar car) : base(car)
    {
    }

    public override string GetDescription()
    {
        return $"{_car.GetDescription()}, Luxury Package";
    }

    public override double GetCost()
    {
        return _car.GetCost() + 10000.0;
    }
}

class Program
{
    Task
    static void Main(string[] args)
    {
        // Tworzenie podstawowego obiektu samochodu
        ICar basicCar = new BasicCar();
        Console.WriteLine("Basic Car:");
        Console.WriteLine($"Description: {basicCar.GetDescription()}");
        Console.WriteLine($"Cost: ${basicCar.GetCost()}");

        // Dekorowanie samochodu za pomocą pakietu sportowego
        ICar sportsCar = new SportsPackage(basicCar);
        Console.WriteLine("\nCar with Sports Package:");
        Console.WriteLine($"Description: {sportsCar.GetDescription()}");
        Console.WriteLine($"Cost: ${sportsCar.GetCost()}");

        // Dekorowanie samochodu za pomocą pakietu luksusowego
        ICar luxuryCar = new LuxuryPackage(sportsCar);
        Console.WriteLine("\nCar with Luxury Package:");
        Console.WriteLine($"Description: {luxuryCar.GetDescription()}");
        Console.WriteLine($"Cost: ${luxuryCar.GetCost()}");

        Console.ReadKey();
    }
}
