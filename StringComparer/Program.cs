// See https://aka.ms/new-console-template for more information

using SC = StringComparer.StringComparer;

Console.WriteLine($"Match: {SC.Match("ab cd  ", "ab cd   ")}");
Console.ReadLine();


