using System.Collections;
using System.Diagnostics;

public class TokenEnumerator(string raw) : IEnumerator<Token>
{
  public Token Current { get; protected set; } = Token.Empty;
  private string Raw => raw;
  private int Index { get; set; } = -1;


  object IEnumerator.Current => Current;

  public void Dispose() { }

  protected Token Peek()
  {
    try
    {
      if (Index + 1 >= Raw.Length) return Token.Empty;
      return Token.Create(Raw[Index + 1]);
    }
    catch
    {
      return Token.Empty;
    }
  }

  public bool MoveNext()
  {
    try
    {
      return (Current = GetNextToken()) != Token.Empty;
    }
    catch
    {
      return false;
    }
  }

  private Token GetNextToken()
  {
    try
    {
      Index++;
      if (Index >= Raw.Length) return Token.Empty;

      var result = Token.Create(Raw[Index]);
      //Debug.WriteLine(result);

      if (result.IsSpace)
        while (Peek().IsSpace)
        {
          Index++;
        }

      return result;
    }
    catch (Exception ex)
    {
      Debug.WriteLine(ex.Message);
      return Token.Empty;
    }
  }

  public void Reset()
  {
    Index = 0;
  }
}


