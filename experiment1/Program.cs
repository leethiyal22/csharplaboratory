using System;

class Student
{
    static void Main()
    {
        string name;
        int age;
        double mark1, mark2, mark3, average;

        Console.Write("Enter student name: ");
        name = Console.ReadLine();

        Console.Write("Enter age: ");
        age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter mark in Subject 1: ");
        mark1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter mark in Subject 2: ");
        mark2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter mark in Subject 3: ");
        mark3 = Convert.ToDouble(Console.ReadLine());

        average = (mark1 + mark2 + mark3) / 3;

        Console.WriteLine("\n--- Student Details ---");
        Console.WriteLine("Name    : " + name);
        Console.WriteLine("Age     : " + age);
        Console.WriteLine("Average : " + average);

        if (average >= 50)
            Console.WriteLine("Result  : PASS");
        else
            Console.WriteLine("Result  : FAIL");
    }
}