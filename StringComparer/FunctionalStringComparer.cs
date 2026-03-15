using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringComparer
{
  public static partial class FunctionalStringComparer
  {

    public static bool Match(string str1, string str2, bool emptiesMatch = true)
    {
      if (Guard(str1, str2)) return emptiesMatch;
      return PerformMatch(str1, str2, emptiesMatch);
    }

    private static bool Guard(string str1, string str2)
    {
      return IsEmpty(str1) && IsEmpty(str2);
    }

    private static bool PerformMatch(string str1, string str2, bool emptiesMatch = true)
    {
      int i = 0, j = 0;

      while (true)
      {
        ConsumeWhiteSpaceCheck(str1, ref i, str2, ref j);

        if (ConsumedBothStrings(str1, i, str2, j)) return true;
        if (ConsumedOnlyOneString(str1, i, str2, j)) return false;
        if (str1[i++] != str2[j++]) return false;
      }
    }

    private static bool ConsumedOnlyOneString(string str1, int i, string str2, int j)
    {
      return i >= str1.Length || j >= str2.Length;
    }

    private static bool ConsumedBothStrings(string str1, int i, string str2, int j)
    {
      return i >= str1.Length && j >= str2.Length;
    }

    private static void ConsumeWhiteSpaceCheck(string str1, ref int i, string str2, ref int j)
    {
      if (EmptyAhead(str1, i) && EmptyAhead(str2, j))
      {
        ConsumeWhitespace(str1, ref i);
        ConsumeWhitespace(str2, ref j);
      }
    }

    private static void ConsumeWhitespace(string s, ref int k)
    {
      while (k < s.Length && s[k] == ' ') k++;
    }

    private static bool EmptyAhead(string s, int k)
    {
      return k < s.Length - 1 && s[k + 1] == ' ';
    }

    public static bool IsEmpty(string s)
    {
      for (var i = 0; i < s.Length; i++)
      {
        if (s[i] == ' ' || s[i] == '\0') continue;
        return false;
      }

      return true;
    }
  }

  [Description("Segregated for private helper test methods")]
  public static partial class FunctionalStringComparer
  {
    public static bool ConsumeWhitespaceTest()
    {
      int k = 0;
      ConsumeWhitespace("   abc", ref k);
      return k == 3;
    }

    public static bool ConsumeWhiteSpaceCheckTest()
    {
      int i = 3, j = 0;
      ConsumeWhiteSpaceCheck("abc  ", ref i, "   abc", ref j);

      Debug.WriteLine($"i: {i}, j: {j}");
      return i == 5 && j == 3;
    }
    public static bool GuardTest()
    {
      return Guard("", " ");
    }
  }

}