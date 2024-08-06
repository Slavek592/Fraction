namespace Fraction.Tests;

public class Parsing
{
    [Fact]
    public void StringParsing1()
    {
        Fraction fraction = new(1, 1);
        Assert.True(fraction.ToString() == "1");
    }
    
    [Fact]
    public void StringParsing2()
    {
        Fraction fraction = new(3, 2);
        Assert.True(fraction.ToString() == "1.5");
    }
    
    [Fact]
    public void StringParsing3()
    {
        Fraction fraction = new(0, 7);
        Assert.True(fraction.ToString() == "0");
    }
    
    [Fact]
    public void StringParsing4()
    {
        Fraction fraction = new(1, 3);
        Assert.False(fraction.ToString() == "0");
    }
    
    [Fact]
    public void StringParsing5()
    {
        Fraction fraction = new(1, 0);
        Assert.Throws<DivideByZeroException>(() => fraction.ToString());
    }

    [Fact]
    public void DoubleParsing1()
    {
        double a = 700.0 / 3.0;
        Fraction fraction = Fraction.Parse(a);
        Assert.True(Math.Abs(a - fraction.ToDouble()) < 0.001);
    }
    
    [Fact]
    public void DoubleParsing2()
    {
        double a = Math.Pow(2, 0.5);
        Fraction fraction = Fraction.Parse(a);
        Assert.True(Math.Abs(a - fraction.ToDouble()) < 0.001);
    }
}