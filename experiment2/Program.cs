using System;

class Rectangle
{
    public double length;
    public double breadth;

    public void CalculateArea()
    {
        double area = length * breadth;
        Console.WriteLine("Area      : " + area);
    }

    public void CalculatePerimeter()
    {
        double perimeter = 2 * (length + breadth);
        Console.WriteLine("Perimeter : " + perimeter);
    }
}

class Program
{
    static void Main()
    {
        Rectangle rectangle = new Rectangle();

        Console.Write("Enter the length: ");
        rectangle.length = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the breadth: ");
        rectangle.breadth = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\n--- Rectangle Details ---");
        Console.WriteLine("Length    : " + rectangle.length);
        Console.WriteLine("Breadth   : " + rectangle.breadth);

        rectangle.CalculateArea();
        rectangle.CalculatePerimeter();
    }
}