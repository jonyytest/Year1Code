class Wolf : Animal
{
    public Wolf(String name, String diet, String location, double weight, int age, String colour) : base(name, diet, location, weight, age, colour)
    {
    }

    public override void eat()
    {
        Console.WriteLine("I can eat 10lbs of meat");
    }
    public override void trick  ()
    {
        Console.WriteLine("I can fetch a ball");
    }
}