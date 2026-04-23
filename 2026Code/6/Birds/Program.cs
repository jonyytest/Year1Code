using System;

class Program
{
    static void Main(string[] refs)
    {
        Duck duck1 = new Duck();
        duck1.name = "Daffy";
        duck1.size = 15;
        duck1.kind = "Mallard";

        Duck duck2 = new Duck();
        duck2.name = "Donald";
        duck2.size = 20;
        duck2.kind = "Decoy";

        List<Duck> ducksToAdd = new List<Duck>()
        {
            duck1,
            duck2,
        };
        IEnumerable<Bird> upcastDucks = ducksToAdd;

        List<Bird> birds = new List<Bird>();
        birds.Add(new Bird() { name = "Feather "});
        birds.Add(new Bird() { name = "Polly "});

        birds.AddRange(upcastDucks);

        foreach (Bird bird in birds)
        {
            Console.WriteLine(bird);
        }
    }
}