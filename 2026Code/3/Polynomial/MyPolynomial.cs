class MyPolynomial
{
    private double[] _coeffs;
    public MyPolynomial(double[] coeffs)
    {
        _coeffs = new double[coeffs.Length];
        Array.Copy(coeffs, _coeffs, coeffs.Length);
    }
    
    public int GetDegree()
    {
        return _coeffs.Length - 1;
    }

    public String ToString()
    {
        String result = "";
        for (int i = _coeffs.Length - 1; i >= 0; i--)
        {
            if (_coeffs[i] != 0)
            {
                if (result.Length > 0 && _coeffs[i] > 0)
                {
                    result += "+";
                }
                result += _coeffs[i].ToString();
                if (i > 0)
                {
                    result += "x";
                    if (i > 1)
                    {
                        result += "^" + i.ToString();
                    }
                }
            }
        }
        if (result == "")
        {
            result = "0";
        }
        return result;
    }

    public double Evaluate(double x)
    {
        double result = 0.0;
        double powerX = 1.0;
        for (int i = 0; i < _coeffs.Length; i++)
        {
            result += _coeffs[i] * powerX;
            powerX *= x;
        }
        return result;
    }

    public MyPolynomial Add(MyPolynomial another)
    {
        int maxLength;
        if (this._coeffs.Length > another._coeffs.Length)
        {
            maxLength = this._coeffs.Length;
        }
        else
        {
            maxLength = another._coeffs.Length;
        }
        double[] tempCoeffs = new double[maxLength];
        for (int i = 0; i < maxLength; i++)
        {
            double myNumber = 0;
            double anotherNumber = 0;
            if (i < this._coeffs.Length)
            {
                myNumber = this._coeffs[i];
            }
            if (i < another._coeffs.Length)
            {
                anotherNumber = another._coeffs[i];
            }
            tempCoeffs[i] = myNumber + anotherNumber;
        }
        this._coeffs = tempCoeffs;
        return this;
    }

    public MyPolynomial Multiply(MyPolynomial other)
    {
        int newLength = this._coeffs.Length + other._coeffs.Length - 1;
        double[] tempCoeffs = new double[newLength];
        for (int i = 0; i < this._coeffs.Length; i++)
        {
            for (int j = 0; j < other._coeffs.Length; j++)
            {
                tempCoeffs[i + j] += this._coeffs[i] * other._coeffs[j];
            }
        }
        this._coeffs = tempCoeffs;
        return this;
    }

}