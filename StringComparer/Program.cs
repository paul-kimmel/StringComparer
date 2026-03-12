// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using StringComparer;


/* A solution to the coding problem is in stringcomparer.cs. The fuzzy string stuff is just to play with. */

var stopwatch = new Stopwatch();

try
{
  stopwatch.Start();
  //Console.WriteLine($"Match: {StringComparer.StringComparer.Match("ab cd  ", "ab cd   ")}");
  Console.WriteLine($"Match: {StringComparer.StringComparer.Match("abra cadabra  ", "abra cadabra")}");
  //Console.WriteLine($"Match: {StringComparer.StringComparer.Match(TestStrings.Dolar1, TestStrings.Dolar2)}");
  stopwatch.Stop();
}
finally
{
  Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");
}


//Thread.Sleep(3000);
Console.ReadLine();