using System;
using System.Collections.Generic;

// Interfejs obserwatora, który definiuje metodę wywoływaną przez podmiot
public interface IObserver
{
    void Update(string message);
}

// Interfejs podmiotu, który zarządza obserwatorami
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Konkretny obserwator implementujący interfejs IObserver
public class ConcreteObserver : IObserver
{
    private string _observerName;

    public ConcreteObserver(string observerName)
    {
        _observerName = observerName;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{_observerName} received message: {message}");
    }
}

// Konkretny podmiot implementujący interfejs ISubject
public class ConcreteSubject : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _message;

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_message);
        }
    }

    public void SendMessage(string message)
    {
        _message = message;
        Console.WriteLine($"Subject sent message: {_message}");
        NotifyObservers();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tworzenie obiektów podmiotu i obserwatorów
        ConcreteSubject subject = new ConcreteSubject();
        ConcreteObserver observer1 = new ConcreteObserver("Observer 1");
        ConcreteObserver observer2 = new ConcreteObserver("Observer 2");

        // Rejestracja obserwatorów u podmiotu
        subject.RegisterObserver(observer1);
        subject.RegisterObserver(observer2);

        // Wysłanie wiadomości przez podmiot, która powiadomi zarejestrowanych obserwatorów
        subject.SendMessage("Hello, observers!");

        Console.ReadKey();
    }
}
