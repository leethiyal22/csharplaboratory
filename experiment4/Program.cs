using System;

class Number
{
    public int value;

    public Number(int value)
    {
        this.value = value;
    }

    // Unary operator overloading
    public static Number operator -(Number n)
    {
        return new Number(-n.value);
    }

    // Binary operator overloading
    public static Number operator +(Number n1, Number n2)
    {
        return new Number(n1.value + n2.value);
    }

    public void Display()
    {
        Console.WriteLine("Value: " + value);
    }
}

class Program
{
    static void Main()
    {
        Number num1 = new Number(10);
        Number num2 = new Number(20);

        Console.WriteLine("--- Unary Operator Overloading ---");
        Console.WriteLine("Original value:");
        num1.Display();

        Number negative = -num1;

        Console.WriteLine("After applying unary - operator:");
        negative.Display();

        Console.WriteLine("\n--- Binary Operator Overloading ---");

        Number result = num1 + num2;

        Console.WriteLine("First number : " + num1.value);
        Console.WriteLine("Second number: " + num2.value);
        Console.WriteLine("After addition:");
        result.Display();
    }
}