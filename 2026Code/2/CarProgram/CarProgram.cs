using System;

class CarProgram
{
    static void Main(string[] args)
    {
        Car car1 = new Car(30);
        car1.addFuel(30);

        Console.WriteLine("Fuel added(L): " + car1.getFuel()
        + "\nMiles Driven: " + car1.getTotalMiles() + "\n");

        Console.WriteLine("Car driving 8 miles...");
        car1.drive(8);

        Console.WriteLine("Fuel (L): " + car1.getFuel()
        + "\nMiles Driven: " + car1.getTotalMiles() + "\n");

        Console.WriteLine("Car driving 25 miles...");
        car1.drive(25);

        Console.WriteLine("Fuel (L): " + car1.getFuel()
        + "\nMiles Driven: " + car1.getTotalMiles() + "\n");

        Console.WriteLine("Car driving 13 miles...");
        car1.drive(13);

        Console.WriteLine("Fuel (L): " + car1.getFuel()
        + "\nMiles Driven: " + car1.getTotalMiles() + "\n");
    }
}
