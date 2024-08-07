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
    
    [Fact]
    public void Subtraction1()
    {
        Fraction a = new(4, 3);
        Fraction b = new(7, 3);
        Fraction c = new(-1, 1);
        Assert.True(a - b == c);
    }
    
    [Fact]
    public void Subtraction2()
    {
        Fraction a = new(4, 3);
        Fraction b = new(-20, 3);
        Assert.True(a - 8 == b);
    }
    
    [Fact]
    public void Multiplying1()
    {
        Fraction a = new(7, 12);
        Fraction b = new(5, 11);
        Fraction c = new(35, 132);
        Assert.True(a * b == c);
    }
    
    [Fact]
    public void Multiplying2()
    {
        Fraction a = new(55, 12);
        Fraction b = new(4, 11);
        Fraction c = new(5, 3);
        Assert.True(a * b == c);
    }
    
    [Fact]
    public void Multiplying3()
    {
        Fraction a = new(5, 12);
        Fraction b = new(5, 3);
        Assert.True(a * 4 == b);
    }
    
    [Fact]
    public void Division1()
    {
        Fraction a = new(7, 12);
        Fraction b = new(5, 11);
        Fraction c = new(77, 60);
        Assert.True(a / b == c);
    }
    
    [Fact]
    public void Division2()
    {
        Fraction a = new(7, 12);
        Fraction b = new(5, 4);
        Fraction c = new(7, 15);
        Assert.True(a / b == c);
    }
    
    [Fact]
    public void Division3()
    {
        Fraction a = new(7, 12);
        Fraction b = new(1, 12);
        Assert.True(a / 7 == b);
    }
    
    [Fact]
    public void Division4()
    {
        Fraction a = new(7, 12);
        Fraction b = new(132, 49);
        Assert.True(11 / a / 7 == b);
    }
}