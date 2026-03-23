class Car
{
    private const double FUEL_PRICE = 1.385;
    
    private double fuelEfficiency; // mpg
    private double fuelL;         // current litres in tank
    private double milesDriven;    // total miles

    public Car(double fuelEfficiency)
    {
        this.fuelEfficiency = fuelEfficiency;
        this.fuelL = 0;        
        this.milesDriven = 0;   
    }

    public double getFuel()
    {
        return this.fuelL;
    }

    public double getTotalMiles()
    {
        return this.milesDriven;
    }

    public void setTotalMiles(double miles) 
    {
        this.milesDriven += miles;
    }

    public void addFuel(double amount)
    {
        this.fuelL += amount;
        Console.WriteLine("Fuel price: " + calcCost(amount).ToString("C"));
    }

    public double calcCost(double litres)
    {
        return litres * FUEL_PRICE;
    }

    public double convertToLitres(double gallons)
    {
        return gallons * 4.546;
    }

    public void drive(double miles)
    {
        setTotalMiles(miles);
        double fuelUsed = (convertToLitres((miles / fuelEfficiency)));
        fuelL -= fuelUsed;
        Console.WriteLine("Cost of Journey: " + calcCost(fuelUsed).ToString("C"));
    }
}