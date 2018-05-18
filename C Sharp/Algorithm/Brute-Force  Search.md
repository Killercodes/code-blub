# Brute-force search

A brute-force algorithm to find the divisors of a natural number n would enumerate all integers from 1 to n, and check whether each of them divides n without remainder. A brute-force approach for the eight queens puzzle would examine all possible arrangements of 8 pieces on the 64-square chessboard, and, for each arrangement, check whether each (queen) piece can attack any other.

While a brute-force search is simple to implement, and will always find a solution if it exists, its cost is proportional to the number of candidate solutions – which in many practical problems tends to grow very quickly as the size of the problem increases. Therefore, brute-force search is typically used when the problem size is limited, or when there are problem-specific heuristics that can be used to reduce the set of candidate solutions to a manageable size. The method is also used when the simplicity of implementation is more important than speed.

[Read more for reference](https://en.wikipedia.org/wiki/Brute-force_search)

``` csharp
void Main()
{
	BruteForceTest testCallback = delegate(ref char[] testChars)
	{
		var str = new string(testChars);
		Console.WriteLine(str);
		return (str == "bbcee");
	};
 
 
            bool result = BruteForce("abcde", 1, 5, testCallback);
            Console.WriteLine(result);
}

// Define other methods and classes here
public delegate bool BruteForceTest(ref char[] testChars);
 
public static bool BruteForce(string testChars, int startLength, int endLength, BruteForceTest testCallback)
{
  for (int len = startLength; len <= endLength; ++len)
  {
      char[] chars = new char[len];

      for (int i = 0; i < len; ++i)
          chars[i] = testChars[0];

      if (testCallback(ref chars))
          return true;

      for (int i1 = len - 1; i1 > -1; --i1)
      {
          int i2 = 0;

          for (i2 = testChars.IndexOf(chars[i1]) + 1; i2 < testChars.Length; ++i2)
          {
              chars[i1] = testChars[i2];

              if (testCallback(ref chars))
                  return true;

              for (int i3 = i1 + 1; i3 < len; ++i3)
              {
                  if (chars[i3] != testChars[testChars.Length - 1])
                  {
                      i1 = len;
                      goto outerBreak;
                  }
              }
          }

      outerBreak:
          if (i2 == testChars.Length)
              chars[i1] = testChars[0];
      }
  }

  return false;
}
```
