class Overloading
{
    public static void methodToBeOverloaded(String name)
    {
        Console.WriteLine("Name: " + name);
    }

    public static void methodToBeOverloaded(String name, int age)
    {
        Console.WriteLine("Name: " + name + "\nAge" + age);
    }

    public static void Main(string[] args)
    {
        methodToBeOverloaded("John");
        methodToBeOverloaded("John", 30);
    }
}