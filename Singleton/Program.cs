public class Singleton
{
    // Prywatne pole przechowujące instancję Singletona
    private static Singleton _instance;

    // Prywatny konstruktor, aby uniemożliwić bezpośrednie tworzenie obiektów Singletona
    private Singleton() { }

    // Metoda do uzyskania instancji Singletona
    public static Singleton GetInstance()
    {
        // Tworzenie instancji tylko, gdy nie została jeszcze utworzona
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }

    // Metoda wypisująca informację, że Singleton został utworzony
    public void ShowMessage()
    {
        Console.WriteLine("Singleton instance created.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Pobranie instancji Singletona za pomocą metody GetInstance()
        Singleton singleton1 = Singleton.GetInstance();

        // Wywołanie metody na instancji Singletona
        singleton1.ShowMessage();

        // Sprawdzenie czy kolejne wywołanie zwraca tę samą instancję
        Singleton singleton2 = Singleton.GetInstance();
        bool areSameInstances = singleton1 == singleton2;
        Console.WriteLine($"Are both instances same? {areSameInstances}");

        Console.ReadKey();
    }
}
