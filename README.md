# StringComparer

A small experimental C# utility for comparing two strings using token enumeration instead of direct string comparison.

This code attempts to normalize empty strings and whitespace before comparing tokenized values.

⚠️ This is experimental code and not production-ready.

---

## Features

- Compares two strings token-by-token
- Treats empty or whitespace-only strings as equivalent
- Avoids `Split()` or regex allocations
- Uses a custom `TokenEnumerator`

---

## Example

```csharp
var result = StringComparer.Match("hello world", "hello world");
Console.WriteLine(result); // true
