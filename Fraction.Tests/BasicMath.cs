namespace Fraction.Tests;

public class BasicMath
{
    [Fact]
    public void Addition1()
    {
        Fraction a = new(7, 3);
        Fraction b = new(4, 3);
        Fraction c = new(11, 3);
        Assert.True(a + b == c);
    }
    
    [Fact]
    public void Addition2()
    {
        Fraction a = new(8, 9);
        Fraction b = new(4, 9);
        Fraction c = new(4, 3);
        Assert.True(a + b == c);
    }
    
    [Fact]
    public void Addition3()
    {
        Fraction a = new(3, 2);
        Fraction b = new(9, 2);
        Assert.True(1 + a + 2 == b);
    }
}