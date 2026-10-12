using System;

class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public Employee(string name, double salary)
    {
        Name = name;
        Salary = salary;
    }
}

class SalaryManager
{
    // Declare a delegate
    public delegate void SalaryHandler(Employee employee);

    // Declare an event
    public event SalaryHandler SalaryUpdated;

    public void UpdateSalary(Employee employee, double increment)
    {
        employee.Salary += increment;

        Console.WriteLine("\nSalary Updated Successfully!");
        Console.WriteLine("Employee Name : " + employee.Name);
        Console.WriteLine("New Salary    : " + employee.Salary);

        // Raise the event
        SalaryUpdated?.Invoke(employee);
    }
}

class Program
{
    // Event handler method
    static void DisplayNotification(Employee employee)
    {
        Console.WriteLine("Notification: Salary of " + employee.Name +
                          " has been updated.");
    }

    static void Main()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine();

        Console.Write("Enter current salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter salary increment: ");
        double increment = Convert.ToDouble(Console.ReadLine());

        Employee employee = new Employee(name, salary);

        SalaryManager manager = new SalaryManager();

        // Subscribe to the event
        manager.SalaryUpdated += DisplayNotification;

        Console.WriteLine("\n--- Employee Details ---");
        Console.WriteLine("Name         : " + employee.Name);
        Console.WriteLine("Current Salary: " + employee.Salary);

        manager.UpdateSalary(employee, increment);
    }
}