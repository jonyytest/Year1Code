using System;

class MobileProgram
{
    static void Main(string[] args)
    {
        Mobile jinMobile = new Mobile("Monthly", "Samsung Galaxy S9", "07712223344");

        Console.WriteLine("Account Type: " + jinMobile.getAccType() 
        + "\nMobile Number: " + jinMobile.getNumber() 
        + "\nDevice: " + jinMobile.getDevice()
        + "\nBalance: " + jinMobile.getBalance());

        Console.WriteLine();
        jinMobile.addCredit(10.00);
        jinMobile.makeCall(5);
        jinMobile.sendText(2);
        Console.ReadLine();


        jinMobile.setAccType("PAYG");
        jinMobile.setDevice("iPhone 6S");
        jinMobile.setNumber("07713334466");
        jinMobile.setBalance(15.50);

        Console.WriteLine();
        Console.WriteLine("Account Type: " + jinMobile.getAccType() 
        + "\nMobile Number: " + jinMobile.getNumber() 
        + "\nDevice: " + jinMobile.getDevice()
        + "\nBalance: " + jinMobile.getBalance());

        Console.WriteLine();
        jinMobile.addCredit(10.00);
        jinMobile.makeCall(5);
        jinMobile.sendText(2);
        Console.ReadLine();

        Mobile anaMobile = new Mobile("PAYG", "iPhone 16", "07776112822");

        Console.WriteLine("Account Type: " + anaMobile.getAccType() 
        + "\nMobile Number: " + anaMobile.getNumber() 
        + "\nDevice: " + anaMobile.getDevice()
        + "\nBalance: " + anaMobile.getBalance());

        Console.WriteLine();
        anaMobile.addCredit(20.00);
        anaMobile.makeCall(10);
        anaMobile.sendText(5);
        Console.ReadLine();
    }

}

