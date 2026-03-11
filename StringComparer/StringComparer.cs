using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StringComparer
{
  public static partial class StringComparer
  {

    public static bool Match(string str1, string str2, bool emptiesMatch = true)
    {
      if (Guard(str1, str2)) return emptiesMatch;
      return PerformTokenMatch(str1, str2, emptiesMatch);
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

    private static bool PerformTokenMatch(string lhs, string rhs, bool emptiesMatch = true)
    {
      var t1 = new TokenEnumerator(lhs);
      var t2 = new TokenEnumerator(rhs);

      while (true)
      {
        var m1 = t1.MoveNext();
        var m2 = t2.MoveNext();
        if (m1 == false && m2 == false) return true;

        if (t1.Current != t2.Current) return false;
      }
    }

    public static bool GuardTest()
    {
      return Guard("", " ");
    }
  }

}


