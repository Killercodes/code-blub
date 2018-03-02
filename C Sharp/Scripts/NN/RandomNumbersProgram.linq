<Query Kind="Program" />

void Main()
{
	Console.WriteLine("RandomNumbersProgram\nhttps://msdn.microsoft.com/magazine/mt767700\n\nBegin lightweight random number generation demo \n");

      int hi = 10;
      int lo = 0;

      //LehmerRng lehmer = new LehmerRng(2);
      //for (int i = 0; i < 9; ++i)
      //{
      //  double x = lehmer.Next();
      //  Console.WriteLine(x.ToString("F12"));
      //}

      Console.WriteLine("Generating 1000 ints in [0, 9] using Lehmer RNG ");
      int[] counts = new int[10];
      LehmerRng lehmer = new LehmerRng(1);
      for (int i = 0; i < 1000; ++i)
      {
        double x = lehmer.Next();
        int ri = (int)((hi - lo) * x + lo);
        ++counts[ri];
      }
      Console.Write("Counts:  ");
      for (int i = 0; i < 10; ++i)
        Console.Write(counts[i] + " ");
      Console.WriteLine("\n\n");

      Console.WriteLine("Generating 1000 ints in [0, 9] using Wichmann-Hill RNG ");
      counts = new int[10];
      WichmannRng wich = new WichmannRng(1);
      for (int i = 0; i < 1000; ++i)
      {
        double x = wich.Next();
        int ri = (int)((hi - lo) * x + lo);
        ++counts[ri];
      }
      Console.Write("Counts:  ");
      for (int i = 0; i < 10; ++i)
        Console.Write(counts[i] + " ");
      Console.WriteLine("\n\n");

      Console.WriteLine("Generating 1000 ints in [0, 9] using Linear Congruential RNG ");
      counts = new int[10];
      LinearConRng lincon = new LinearConRng(0);
      for (int i = 0; i < 1000; ++i)
      {
        double x = lincon.Next();
        int ri = (int)((hi - lo) * x + lo);
        ++counts[ri];
      }
      Console.Write("Counts:  ");
      for (int i = 0; i < 10; ++i)
        Console.Write(counts[i] + " ");
      Console.WriteLine("\n\n");

      Console.WriteLine("Generating 1000 ints in [0, 9] using Lagged Fibonacci RNG ");
      counts = new int[10];
      LaggedFibRng lagged = new LaggedFibRng(0);
      for (int i = 0; i < 1000; ++i)
      {
        double x = lagged.Next();
        int ri = (int)((hi - lo) * x + lo);
        ++counts[ri];
      }
      Console.Write("Counts:  ");
      for (int i = 0; i < 10; ++i)
        Console.Write(counts[i] + " ");
      Console.WriteLine("\n\n");

      Console.WriteLine("End demo \n");
      Console.ReadLine();
}

// Define other methods and classes here
public class LehmerRng
  {
    private const int a = 16807;
    private const int m = 2147483647;
    private const int q = 127773;
    private const int r = 2836;
    private int seed;

    public LehmerRng(int seed)
    {
      // seed in [1, maxint)
      if (seed <= 0 || seed == int.MaxValue)
        throw new Exception("Bad seed");
      this.seed = seed;
    }

    public double Next()
    {
      int hi = seed / q;
      int lo = seed % q;
      seed = (a * lo) - (r * hi);
      if (seed <= 0)
        seed = seed + m;
      return (seed * 1.0) / m;
    }
  } // class LehmerRng

  public class WichmannRng
  {
    private int s1, s2, s3;

    public WichmannRng(int seed)
    {
      if (seed <= 0 || seed > 30000)
        throw new Exception("Bad seed");
      s1 = seed;
      s2 = seed + 1;
      s3 = seed + 2;
    }

    public double Next()
    {
      //Console.WriteLine(s1 + " " + s2 + " " + s3);
      s1 = 171 * (s1 % 177) - 2 * (s1 / 177);
      if (s1 < 0) { s1 += 30269; }

      s2 = 172 * (s2 % 176) - 35 * (s2 / 176);
      if (s2 < 0) { s2 += 30307; }

      s3 = 170 * (s3 % 178) - 63 * (s3 / 178);
      if (s3 < 0) { s3 += 30323; }

      double r = (s1 * 1.0) / 30269 + (s2 * 1.0) / 30307 + (s3 * 1.0) / 30323;
      return r - Math.Truncate(r);  // orig uses % 1.0
    }
  } // class WichmannRng

  public class LinearConRng
  {
    private const long a = 25214903917;
    private const long c = 11;
    // m = 2^48
    private long seed;

    public LinearConRng(long seed)
    {
      //this.seed = (seed ^ 0x5DEECE66DL) & ((1L << 48) - 1);
      if (seed < 0)
        throw new Exception("Bad seed");
      this.seed = seed;
    }

    private int next(int bits)
    {
      seed = (seed * a + c) & ((1L << 48) - 1);
      return (int)(seed >> (48 - bits));  // high order bits set to sign bit (0)
    }

    public double Next()
    {
      return (((long)next(26) << 27) + next(27)) / (double)(1L << 53);
    }
  } // class LinearConRng

  public class LaggedFibRng
  {
    private const int k = 10; // largest magintude"-index"
    private const int j = 7; // other "-index"
    private const int m = 2147483647;  // 2^31 - 1 = maxint

    private List<int> vals = null;
    private int seed;

    public LaggedFibRng(int seed)
    {
      vals = new List<int>();
      for (int i = 0; i < k + 1; ++i)
        vals.Add(seed);
      if (seed % 2 == 0) vals[0] = 11;  // at least one seed must be odd

      // burn some values away
      for (int ct = 0; ct < 1000; ++ct) {
        double dummy = this.Next();
      }
    }  // ctor

    public double Next()
    {
      // (a + b) mod n = [(a mod n) + (b mod n)] mod n
      int left = vals[0] % m;    // [x-big]
      int right = vals[k - j] % m; // [x-other]
      long sum = (long)left + (long)right;  // prevent overflow

      seed = (int)(sum % m);  // because m is int, result has int range
      vals.Insert(k + 1, seed);  // add new val at end
      vals.RemoveAt(0);  // delete now irrelevant [0] val
      return (1.0 * seed) / m;
    }
  } // LaggedFibRng