using System;

// Istniejący interfejs, z którym klient współpracuje
public interface ITarget
{
    void Request();
}

// Klasa, która jest obiektem, z którym klient nie może współpracować bezpośrednio
public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Specific request from Adaptee.");
    }
}

// Adapter implementujący interfejs oczekiwany przez klienta i korzystający z Adaptee
public class Adapter : ITarget
{
    private Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        // Wywołanie metody Adaptee z konkretnego klienta
        _adaptee.SpecificRequest();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie instancji Adaptee
        Adaptee adaptee = new Adaptee();

        // Utworzenie adaptera i przekazanie mu instancji Adaptee
        ITarget adapter = new Adapter(adaptee);

        // Wywołanie metody oczekiwanej przez klienta, która zostanie przekierowana do Adaptee
        adapter.Request();

        Console.ReadKey();
    }
}
