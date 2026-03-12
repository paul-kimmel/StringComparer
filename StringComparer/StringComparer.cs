using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StringComparer
{
  public static partial class StringComparer
  {

    public static bool Match(string lhs, string rhs, bool emptiesMatch = true)
    {
      if (Guard(lhs, rhs)) return emptiesMatch;
      return PerformTokenMatch(lhs, rhs, emptiesMatch);
    }

    private static bool Guard(string str1, string str2)
    {
      return IsEmpty(str1) && IsEmpty(str2);
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

    private static (TokenEnumerator lhs, TokenEnumerator rhs, bool matchResult) _PerformTokenMatch(string lhs, string rhs, bool emptiesMatch = true)
    {
      var tokenLhs = new TokenEnumerator(lhs);
      var tokenRhs = new TokenEnumerator(rhs);

      while (true)
      {
        var leftToken = tokenLhs.MoveNext();
        var rightToken = tokenRhs.MoveNext();
        if (leftToken == false && rightToken == false) return (tokenLhs, tokenRhs, true);

        if (tokenLhs.Current != tokenRhs.Current) return (tokenLhs, tokenRhs, false);
      }
    }

    private static bool PerformTokenMatch(string lhs, string rhs, bool emptiesMatch = true)
    {
      var result = _PerformTokenMatch(lhs, rhs, emptiesMatch);

      return Report(result).matchResult;
    }

    private static (TokenEnumerator lhs, TokenEnumerator rhs, bool matchResult) Report((TokenEnumerator lhs, TokenEnumerator rhs, bool matchResult) result)
    {
      result.lhs.DumpTokens();
      Console.WriteLine(new string('*', 80));
      result.rhs.DumpTokens();
      return result;
    }

    public static bool GuardTest()
    {
      return Guard("", " ");
    }
  }

}



