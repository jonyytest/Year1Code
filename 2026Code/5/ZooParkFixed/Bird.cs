class Bird : Animal
{
    private String species;
    private double wingspan;
    public Bird(String name, String diet, String location, double weight, int age, String colour, String species, double wingspan) : base(name, diet, location, weight, age, colour)
    {
        this.species = species;
        this.wingspan = wingspan;
    }
    public virtual void fly()
    {
        Console.WriteLine("A bird flies");
    }
}