using System;

class ZooPark
{
    public static void Main()
    {
        Tiger tonyTiger = new Tiger("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White", "Siberian", "White");
        Wolf williamWolf = new Wolf("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
        Eagle edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black", "Harpy", 98.5);
        Lion lennyLion = new Lion("Lenny the Lion", "Meat", "Savannah", 190, 12, "Golden", "African");
        Penguin pennyPenguin = new Penguin("Penny the Penguin", "Fish", "Antarctica", 15, 8, "Black and White", "Antartic", 25.4);
        Animal baseAnimal = new Animal("Animal Name", "Animal Diet", "Animal Location", 0.0, 0, "Animal Colour");

        baseAnimal.eat();
        baseAnimal.sleep();
        baseAnimal.makeNoise();
        baseAnimal.trick();
        Console.ReadLine();

        tonyTiger.eat();
        tonyTiger.sleep();
        tonyTiger.makeNoise();
        tonyTiger.trick();
        Console.ReadLine();

        williamWolf.eat();
        williamWolf.sleep();
        williamWolf.makeNoise();
        williamWolf.trick();
        Console.ReadLine();

        edgarEagle.eat();
        edgarEagle.sleep();
        edgarEagle.makeNoise();
        edgarEagle.trick();
        edgarEagle.fly();
        edgarEagle.layEgg();
        Console.ReadLine();

        lennyLion.eat();
        lennyLion.sleep();
        lennyLion.makeNoise();
        lennyLion.trick();
        Console.ReadLine();

        pennyPenguin.eat();
        pennyPenguin.sleep();
        pennyPenguin.makeNoise();
        pennyPenguin.trick();
        Console.ReadLine();
    }

}