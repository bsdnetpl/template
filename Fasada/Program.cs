using System;

// Złożony system z wieloma klasami
class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("Subsystem A: Operation A");
    }
}

class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("Subsystem B: Operation B");
    }
}

class SubsystemC
{
    public void OperationC()
    {
        Console.WriteLine("Subsystem C: Operation C");
    }
}

// Fasada - dostarcza prosty interfejs do złożonego systemu
class Facade
{
    private SubsystemA _subsystemA;
    private SubsystemB _subsystemB;
    private SubsystemC _subsystemC;

    public Facade()
    {
        _subsystemA = new SubsystemA();
        _subsystemB = new SubsystemB();
        _subsystemC = new SubsystemC();
    }

    // Metody fasady wykorzystujące metody złożonego systemu
    public void Operation1()
    {
        Console.WriteLine("\nOperation 1 ---- ");
        _subsystemA.OperationA();
        _subsystemB.OperationB();
    }

    public void Operation2()
    {
        Console.WriteLine("\nOperation 2 ---- ");
        _subsystemB.OperationB();
        _subsystemC.OperationC();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Utworzenie fasady
        Facade facade = new Facade();

        // Użycie fasady, która wywołuje metody złożonego systemu w odpowiedniej kolejności
        facade.Operation1();
        facade.Operation2();

        Console.ReadKey();
    }
}
