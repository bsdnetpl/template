using System;

// Abstrakcja
public abstract class Abstraction
{
    protected IBridge bridge;

    public Abstraction(IBridge bridge)
    {
        this.bridge = bridge;
    }

    public abstract void Operation();
}

// Implementacja
public interface IBridge
{
    void OperationImplementation();
}

// Konkretna implementacja
public class ConcreteImplementationA : IBridge
{
    public void OperationImplementation()
    {
        Console.WriteLine("ConcreteImplementationA");
    }
}

public class ConcreteImplementationB : IBridge
{
    public void OperationImplementation()
    {
        Console.WriteLine("ConcreteImplementationB");
    }
}

// Konkretna abstrakcja
public class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(IBridge bridge) : base(bridge)
    {
    }

    public override void Operation()
    {
        Console.Write("RefinedAbstraction: ");
        bridge.OperationImplementation();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Abstraction abstraction;

        // Użycie pierwszej implementacji
        abstraction = new RefinedAbstraction(new ConcreteImplementationA());
        abstraction.Operation();

        // Użycie drugiej implementacji
        abstraction = new RefinedAbstraction(new ConcreteImplementationB());
        abstraction.Operation();

        Console.ReadKey();
    }
}
