using System;

class TestMyPolynomial
{
    static void Main(string[] args)
    {
        double[] coeffs1 = {12, -5, 6, 7};
        double[] coeffs2 = {1, 5};

        MyPolynomial poly1 = new MyPolynomial(coeffs1);
        MyPolynomial poly2 = new MyPolynomial(coeffs2);

        Console.WriteLine("Polynomial 1: " + poly1.ToString());
        Console.WriteLine("Degree of Polynomial 1: " + poly1.GetDegree());
        Console.WriteLine("Polynomial 2: " + poly2.ToString());
        Console.WriteLine("Degree of Polynomial 2: " + poly2.GetDegree());

        double x = 2.0;
        Console.WriteLine("Polynomial 1 evaluated at x = " + x + ": " + poly1.Evaluate(x));
        Console.WriteLine("Polynomial 2 evaluated at x = " + x + ": " + poly2.Evaluate(x));

        MyPolynomial polyAdd1 = new MyPolynomial(coeffs1);
        MyPolynomial polyAdd2 = new MyPolynomial(coeffs2);

        polyAdd1.Add(polyAdd2);
        Console.WriteLine("Polynomial 1 + Polynomial 2: " + polyAdd1.ToString());

        MyPolynomial polyMult1 = new MyPolynomial(coeffs1);
        MyPolynomial polyMult2 = new MyPolynomial(coeffs2);

        polyMult1.Multiply(polyMult2);
        Console.WriteLine("Polynomial 1 * Polynomial 2: " + polyMult1.ToString());

    }
}