using System;

class CarProgram
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

class Car
{
    private int fuelEfficieny;
    private int fuelL;
    private int milesDriven;

    public Car(int fuelEfficieny, int fuelL)
    {
        this.fuelEfficieny = fuelEfficieny;
        this.fuelL = 0;
        this.milesDriven = 0;
    }

    public int getFuel()
    {
        return this.fuelL;
    }

    public int getTotalMiles()
    {
        return this.milesDriven;
    }

    public void setTotalMiles(int milesDriven)
    {
        this.milesDriven = milesDriven;
    }
    public void printFuelCost()
    {
        Console.WriteLine("The cost of fuel is: " + this.fuelL * 1.385);
    }
    public void addFuel()
    {
        
    }
    public void calcCost()
    {
        
    }
    public void convertToLitres()
    {
        
    }
    public void drive()
    {
        
    }
}
