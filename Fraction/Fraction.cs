namespace Fraction;

public record struct Fraction(long Numerator, long Denominator)
{
    // Actually could be private. Maybe.
    // TODO: Make shortening more effective!!!
    public void Shorten()
    {
        for (int i = (int)Math.Pow(Numerator, 0.5); i > 1; i--)
            if (Numerator % i == 0 && Denominator % i == 0)
            {
                Numerator /= i;
                Denominator /= i;
            }
    }
    
    public void MustBeReal()
    {
        if (Denominator == 0)
            throw new DivideByZeroException("The denominator is 0!");
    }

    #region Parsing
    
    public override string ToString()
    {
        MustBeReal();
        return ((double) Numerator / (double) Denominator).ToString();
    }

    public long ToLong()
    {
        MustBeReal();
        return Numerator / Denominator;
    }

    public double ToDouble()
    {
        MustBeReal();
        return (double) Numerator / (double) Denominator;
    }
    
    public static Fraction Parse(long a)
    {
        return new Fraction(a, 1);
    }

    public static Fraction Parse(double a, long precision=100000)
    {
        Fraction theNearest = new(0, 1);
        
        if (a > 0)
        {
            Fraction result = new(1, 1);
            while (result.ToDouble() != a && result.Numerator < precision && result.Denominator < precision)
            {
                if (a > result.ToDouble())
                    result.Numerator += 1;
                else
                    result.Denominator += 1;
                if (Math.Abs(theNearest.ToDouble() - a) > Math.Abs(result.ToDouble() - a))
                    theNearest = result;
            }
        }
        
        else if (a < 0)
        {
            Fraction result = new(-1, 1);
            while (result.ToDouble() != a && -result.Numerator < precision && result.Denominator < precision)
            {
                if (a < result.ToDouble())
                    result.Numerator -= 1;
                else
                    result.Denominator += 1;
                if (Math.Abs(theNearest.ToDouble() - a) > Math.Abs(result.ToDouble() - a))
                    theNearest = result;
            }
        }
        
        return theNearest;
    }
    
    #endregion

    #region Operators

    #region Operator+
    public static Fraction operator +(Fraction a, Fraction b)
    {
        Fraction result = new(
            a.Numerator * b.Denominator + b.Numerator * a.Denominator,
            a.Denominator * b.Denominator);
        result.Shorten();
        return result;
    }
    
    public static Fraction operator +(Fraction a, long b)
    {
        return a with {Numerator = a.Numerator + b * a.Denominator};
    }
    
    public static Fraction operator +(long b, Fraction a)
    {
        return a with {Numerator = a.Numerator + b * a.Denominator};
    }
    #endregion
    
    #region Operator-
    public static Fraction operator -(Fraction a, Fraction b)
    {
        Fraction result = new(
            a.Numerator * b.Denominator - b.Numerator * a.Denominator,
            a.Denominator * b.Denominator);
        result.Shorten();
        return result;
    }
    
    public static Fraction operator -(Fraction a, long b)
    {
        return a with {Numerator = a.Numerator - b * a.Denominator};
    }
    
    public static Fraction operator -(long b, Fraction a)
    {
        return a with {Numerator = a.Numerator - b * a.Denominator};
    }
    #endregion
    
    #region Operator*
    public static Fraction operator *(Fraction a, Fraction b)
    {
        Fraction result = new(
            a.Numerator * b.Numerator,
            a.Denominator * b.Denominator);
        result.Shorten();
        return result;
    }
    
    public static Fraction operator *(Fraction a, long b)
    {
        return a with {Numerator = a.Numerator * b};
    }
    
    public static Fraction operator *(long b, Fraction a)
    {
        return a with {Numerator = a.Numerator * b};
    }
    #endregion
    
    #region Operator/
    public static Fraction operator /(Fraction a, Fraction b)
    {
        Fraction result = new(
            a.Numerator * b.Denominator,
            a.Denominator * b.Numerator);
        result.Shorten();
        return result;
    }
    
    public static Fraction operator /(Fraction a, long b)
    {
        return a with {Denominator = a.Denominator * b};
    }

    public static Fraction operator /(long b, Fraction a)
    {
        return a with {Denominator = a.Denominator * b};
    }
    #endregion
    
    #region Operator^
    public static Fraction operator ^(Fraction a, int b)
    {
        if (b > 0)
            return new(
                (long)Math.Pow(a.Numerator, b),
                (long)Math.Pow(a.Denominator, b));
        else if (a.Denominator == 0)
            throw new DivideByZeroException("The numerator is 0!");
        else if (b < 0)
            return new((long)Math.Pow(a.Denominator, -b),
                (long)Math.Pow(a.Numerator, -b));
        else
            return new Fraction(1, 1);
    }

    // Imperfect! Loss of data!
    public static Fraction operator ^(Fraction a, Fraction b)
    {
        return Parse(Math.Pow(a.ToDouble(), b.ToDouble()));
    }
    #endregion
    
    #endregion
}