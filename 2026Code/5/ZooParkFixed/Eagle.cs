class Eagle : Bird
{

    public Eagle(String name, String diet, String location, double weight, int age, String colour, String species, double wingspan) : base(name, diet, location, weight, age, colour, species, wingspan)
    {
    }
    
    public void layEgg()
    {
        Console.WriteLine("I can lay an egg");
    }
    public override void makeNoise()
    {
        Console.WriteLine("SCREEEECH!");
    }

    public override void eat()
    {
        Console.WriteLine("I can eat 1lb of fish");
    }

    public override void trick()
    {
        Console.WriteLine("I can do a barrel roll");
    }
    
    public override void fly()
    {
        Console.WriteLine("I can fly with my large wingspan");
    }

}