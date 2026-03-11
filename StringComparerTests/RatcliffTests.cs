using StringComparer;
using StringComparerTests;
using System.Diagnostics;
using Xunit.Abstractions;

namespace FuzzyStringTests
{
  public class RatcliffTests
  {
    private readonly ITestOutputHelper output;
    private readonly TestOutputWriter writer;

    public RatcliffTests(ITestOutputHelper output)
    {
      this.output = output;
      this.writer = new TestOutputWriter(output);
    }

    [Theory]
    [InlineData("", " ")]
    [InlineData("", "")]
    [InlineData("ab cd  ", "ab cd  ")]
    [InlineData("ab cd", "ab cd")]
    void Test_Match_True(string left, string right)
    {
      writer.WriteLine($"Testing: '{left}' vs '{right}' should pass");
      var result = FuzzyString.RatcliffObershelpCoefficient(left, right);
      writer.WriteLine($"Test_Match_True: {result}");
      Assert.True( result == 1.0);
    }

    [Theory]
    [InlineData("a", " ")]
    [InlineData("ab cd", "ab cd ")]
    [InlineData("ab cd", "ab cde")]
    [InlineData("abcd", "ab cd")]
    [InlineData("ab cd", "ab cd ef")]
    [InlineData("ab cd e f", "ab cd ef")]
    void Test_Match_False(string left, string right)
    {
      writer.WriteLine($"Testing: '{left}' vs '{right}' should fail");
      var result = FuzzyString.RatcliffObershelpCoefficient(left, right);
      writer.WriteLine($"Test_Match_False: {result}");
      Assert.False(result == 1.0);
    }
    

    //1. “ab cd” matches “ab cd“
    //2. “ab cd” does not match “ab cde”
    //3. “abcd” does not match “ab cd“
    //4. “ab cd” does not match “ab cd ef”
    //5. “ab cd e f” does not match “ab cd ef”
  }
}
