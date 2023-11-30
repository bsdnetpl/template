using System;

// Interfejs rzeczywistego obiektu
public interface IRealObject
{
    void PerformAction();
}

// Rzeczywisty obiekt
public class RealObject : IRealObject
{
    public void PerformAction()
    {
        Console.WriteLine("RealObject performing action...");
    }
}

// Proxy - obiekt pełnomocnika
public class Proxy : IRealObject
{
    private RealObject realObject;

    public void PerformAction()
    {
        if (realObject == null)
        {
            realObject = new RealObject();
        }

        Console.WriteLine("Proxy checks something before delegating to RealObject.");
        realObject.PerformAction();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Użycie pełnomocnika
        IRealObject proxy = new Proxy();
        proxy.PerformAction();

        Console.ReadKey();
    }
}
