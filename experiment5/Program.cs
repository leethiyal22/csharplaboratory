using System;
using System.Threading;

class ThreadDemo
{
    public void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Number Thread: " + i);
            Thread.Sleep(500);
        }
    }

    public void PrintLetters()
    {
        for (char ch = 'A'; ch <= 'E'; ch++)
        {
            Console.WriteLine("Letter Thread: " + ch);
            Thread.Sleep(500);
        }
    }
}

class Program
{
    static void Main()
    {
        ThreadDemo demo = new ThreadDemo();

        Thread thread1 = new Thread(demo.PrintNumbers);
        Thread thread2 = new Thread(demo.PrintLetters);

        Console.WriteLine("Starting threads...\n");

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("\nBoth threads have completed.");
    }
}