using System;

public class ClassA
{
    // Changed from private to protected so ClassB can access it
    protected int i = 10;

    public int Sum(int j)
    {
        return i + j;
    }

    public int Product(int j)
    {
        return i * j;
    }

    public virtual double Division(int j) 
    {
        return i / j;
    }
} 

public class ClassB : ClassA
{
    public override double Division(int j)
    {
        return (double)i / j;
    }

    public void PrintResults(int j)
    {
        Console.WriteLine("i: {0}", i);
        Console.WriteLine("Sum(j): {0}", Sum(j));
        Console.WriteLine("Product(j): {0}", Product(j));
        Console.WriteLine("Division(j): {0}", Division(j));
    }
}

public class Program
{
    public static void Main()
    {
        ClassA a = new ClassA();
        ClassB b = new ClassB();

        Console.WriteLine("Sum by class A: {0}", a.Sum(3));  // Can now be used because method is public
        
        Console.WriteLine("Product by class A: {0}", a.Product(3));
        Console.WriteLine("Division by class A: {0}", a.Division(3));

        Console.WriteLine("Sum by class B: {0}", b.Sum(3)); 
        
        Console.WriteLine("Product by class B: {0}", b.Product(3));
        Console.WriteLine("Division by class B: {0}", b.Division(3));

        b.PrintResults(3);
    }
}
