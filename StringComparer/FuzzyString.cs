using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringComparer
{
  public class FuzzyString
  {
    [Description("Double the matching number of characters divided by the total number of characters of the two strings")]
    public static double RatcliffObershelpCoefficient(string first, string second)
    {
      first = ImproveNoise(first);
      second = ImproveNoise(second);

      if (IsExactMatch(first, second)) return 1;
      if (BothAreNull(first, second)) return 0;

      return CalculateRatcliffObershelpCoefficient(first, second);
    }

    //TODO 3179: GetSubStringCoefficient Boundary Errors
    private static double CalculateRatcliffObershelpCoefficient(string first, string second)
    {
#if true
      return 2 * Convert.ToDouble(first.Intersect(second).Count()) / (Convert.ToDouble(first.Length + second.Length));
#else
      return (double)GetSubstringCoefficient(Encoding.ASCII.GetBytes(first), Encoding.ASCII.GetBytes(second), 0, first.Length, 0, second.Length) 
        / (first.Length + second.Length) * 2;
#endif
    }


    private static bool IsExactMatch(string first, string second)
    {
      return string.Compare(first, second, true) == 0;
    }

    private static string ImproveNoise(string s)
    {
      try
      {
        var o = s.Split(new char[] { ',', '.', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", o).ToUpper();
      }
      catch (Exception ex)
      {
        Debug.WriteLine("ImproveNoise Error: {0}", ex.Message);
        return s;
      }
    }

    public static bool BothAreNull(string first, string second)
    {
      return (String.IsNullOrEmpty(first) && String.IsNullOrEmpty(second));
    }

  }
}
