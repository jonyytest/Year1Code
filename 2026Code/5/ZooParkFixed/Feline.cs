class Feline : Animal
{
    private String species;

    public Feline(String name, String diet, String location, double weight, int age, String colour, String species) : base(name, diet, location, weight, age, colour)
    {
        this.species = species;
    }
}