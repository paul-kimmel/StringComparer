# StringComparer

A small experimental C# utility for comparing two strings using token enumeration instead of direct string comparison.

This is a coding test style problem. It emphasizes articial boundary problems by allow -length strings greater than 0 to be the same. As a practicel hands on test the parameters include no regex, no string.Xxx function like split, and strings can the max length of 2GB. This, if you parse strings into arrays are alter the strings then the string interning will fail and you'll likely run out of memory.

You could try stacks, indexing, parsing, tokenization logic, but likely cool fuzzy matching algorithms may not match. 

I will stick a RatcliffObershelpCoefficient for tetsing to see how well that works.

This code attempts to normalize empty strings and whitespace before comparing tokenized values.

⚠️ This is is just a coding-test style solution.

---

## Features

- Compares two strings token-by-token
- Treats empty or whitespace-only strings as equivalent; whitespace is equivalent for length, where n > 0
- Avoids `Split()` or regex allocations
- Uses a custom `TokenEnumerator`

---

## Example

```csharp
var result = StringComparer.Match("hello world", "hello world");
Console.WriteLine(result); // true
