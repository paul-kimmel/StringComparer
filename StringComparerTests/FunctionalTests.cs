using SC = StringComparer.FunctionalStringComparer;

namespace StringComparerTests
{
  public class FunctionalTests
  {
    [Fact] void Guard_True() => Assert.True(SC.GuardTest());

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    void Test_IsEmpty(string s) => Assert.True(SC.IsEmpty(s));

    [Theory]
    [InlineData("", " ")]
    [InlineData("", "")]
    [InlineData("ab cd  ", "ab cd  ")]
    [InlineData("ab cd", "ab cd")]
    void Test_Match_True(string left, string right) => Assert.True(SC.Match(left, right));

    [Theory]
    [InlineData("a", " ")]
    [InlineData("ab cd", "ab cd ")]
    [InlineData("ab cd", "ab cde")]
    [InlineData("abcd", "ab cd")]
    [InlineData("ab cd", "ab cd ef")]
    [InlineData("ab cd e f", "ab cd ef")]
    void Test_Match_False(string left, string right) => Assert.False(SC.Match(left, right));

    //1. “ab cd” matches “ab cd“
    //2. “ab cd” does not match “ab cde”
    //3. “abcd” does not match “ab cd“
    //4. “ab cd” does not match “ab cd ef”
    //5. “ab cd e f” does not match “ab cd ef”
  }
}