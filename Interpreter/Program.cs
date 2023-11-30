using System;
using System.Collections.Generic;

// Kontekst - zawiera dane do interpretacji
public class Context
{
    private Dictionary<string, int> _variables = new Dictionary<string, int>();

    public int GetVariableValue(string variableName)
    {
        if (_variables.ContainsKey(variableName))
            return _variables[variableName];
        return 0;
    }

    public void SetVariableValue(string variableName, int value)
    {
        if (_variables.ContainsKey(variableName))
            _variables[variableName] = value;
        else
            _variables.Add(variableName, value);
    }
}

// Interfejs wyrażenia
public interface IExpression
{
    int Interpret(Context context);
}

// Konkretny terminal wyrażenia
public class NumberExpression : IExpression
{
    private int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret(Context context)
    {
        return _number;
    }
}

// Konkretny nieterminal wyrażenia
public class VariableExpression : IExpression
{
    private string _variableName;

    public VariableExpression(string variableName)
    {
        _variableName = variableName;
    }

    public int Interpret(Context context)
    {
        return context.GetVariableValue(_variableName);
    }
}

// Konkretny nieterminal wyrażenia
public class AdditionExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public AdditionExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context)
    {
        return _left.Interpret(context) + _right.Interpret(context);
    }
}

// Konkretny nieterminal wyrażenia
public class SubtractionExpression : IExpression
{
    private IExpression _left;
    private IExpression _right;

    public SubtractionExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }

    public int Interpret(Context context)
    {
        return _left.Interpret(context) - _right.Interpret(context);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Context context = new Context();
        context.SetVariableValue("x", 10);
        context.SetVariableValue("y", 5);
        context.SetVariableValue("z", 3);

        // Interpretacja wyrażenia "x + y - z"
        IExpression expression = new SubtractionExpression(
            new AdditionExpression(new VariableExpression("x"), new VariableExpression("y")),
            new VariableExpression("z")
        );

        int result = expression.Interpret(context);
        Console.WriteLine("Result: " + result);

        Console.ReadKey();
    }
}
