public struct Token
{
  public static Token Create(char _ch)
  {
    Token o;
    o.ch = _ch;
    return o;
  }

  public Token(char _ch)
  {
    ch = _ch;
  }

  public char ch;
  public bool IsSpace => IsWhitespace(ch);
  private static readonly char[] Whitespace = new char[] { ' ', '\t', '\r', '\n' };

  public static bool IsWhitespace(char ch)
  {
#if DEBUG
    var result = Whitespace.Contains(ch);
    //Debug.WriteLine($"Whitespace({ch}): {result}");
    return result;
#else
      return Whitespace.Contains(ch);
#endif
  }

  public static bool operator ==(Token lhs, Token rhs)
  {
    return lhs.ch == rhs.ch;
  }

  public override string ToString()
  {
    return ch.ToString();
  }

  public static bool operator !=(Token lhs, Token rhs)
  {
    return lhs.ch != rhs.ch;
  }

  public override int GetHashCode()
  {
    return base.GetHashCode();
  }

  public override bool Equals(Object o)
  {
    return base.Equals(o);
  }

  private static readonly Token _empty = new Token('\0');
  public static Token Empty => _empty;
}


