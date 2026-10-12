using System;

// Single Inheritance
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animal eats food.");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog barks.");
    }
}

// Multilevel Inheritance
class Vehicle
{
    public void Start()
    {
        Console.WriteLine("Vehicle starts.");
    }
}

class Car : Vehicle
{
    public void Drive()
    {
        Console.WriteLine("Car is driving.");
    }
}

class SportsCar : Car
{
    public void Speed()
    {
        Console.WriteLine("Sports car runs at high speed.");
    }
}

// Multiple Inheritance using Interfaces
interface IPrinter
{
    void Print();
}

interface IScanner
{
    void Scan();
}

class Machine : IPrinter, IScanner
{
    public void Print()
    {
        Console.WriteLine("Machine is printing.");
    }

    public void Scan()
    {
        Console.WriteLine("Machine is scanning.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Single Inheritance ---");
        Dog dog = new Dog();
        dog.Eat();
        dog.Bark();

        Console.WriteLine("\n--- Multilevel Inheritance ---");
        SportsCar sportsCar = new SportsCar();
        sportsCar.Start();
        sportsCar.Drive();
        sportsCar.Speed();

        Console.WriteLine("\n--- Multiple Inheritance using Interfaces ---");
        Machine machine = new Machine();
        machine.Print();
        machine.Scan();
    }
}