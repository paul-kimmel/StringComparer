using System.Text;
using Xunit.Abstractions;

namespace StringComparerTests
{
  public class TestOutputWriter : TextWriter
  {

    private ITestOutputHelper output = null;

    public TestOutputWriter(ITestOutputHelper output)
    {
      this.output = output;
    }

    public override Encoding Encoding => Encoding.UTF8;

    public override void WriteLine(string s)
    {
      try
      {
        if (output != null)
          output.WriteLine(s);
      }
      catch (System.InvalidOperationException)
      {
      }
    }

    public override void Write(string s)
    {
      WriteLine(s);
    }
  }
}
