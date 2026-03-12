public class Report : IReport<Token>
{
  private List<Token> tokens = new List<Token>();

  public void Clear()
  {
    tokens.Clear();
  }

  public void Dump()
  {
#if DEBUG
    var result = string.Join(", ", tokens.Select(t => t.ToString()));
    Console.WriteLine($"Token count: {tokens.Count}, Tokens: {result}, Last Token: {tokens.Last()}");

#endif
  }

  public void Stash(Token t)
  {
    tokens.Add(t);
  }
}


