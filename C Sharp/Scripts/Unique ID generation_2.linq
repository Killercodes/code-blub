<Query Kind="Program" />

void Main()
{
	long unixTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1,0,0,0,0))).TotalSeconds;
	Console.WriteLine("EPOCH: {0}",unixTimestamp);
	long ticks = unixTimestamp;// DateTime.UtcNow.Ticks;
	Console.WriteLine("CurrentTime: {0}",ticks);
	
		// convert to binary
			string binary = IntToString(ticks, new char[] { '0', '1' });
	Console.WriteLine("BinaryTick: {0}",binary);
	
			// convert to hexadecimal
			string hex = IntToString(ticks, 
				new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
							'A', 'B', 'C', 'D', 'E', 'F'});
	Console.WriteLine("HexTick: {0}",hex);
	
			// convert to hexavigesimal (base 26, A-Z)
			string hexavigesimal = IntToString(ticks, 
				Enumerable.Range('a', 26).Select(x => (char)x).ToArray());
	Console.WriteLine("HexavigesimalTick: {0}",hexavigesimal);
	
			// convert to sexagesimal
			string xx = IntToStringFast(ticks, 
				new char[] { '0','1','2','3','4','5','6','7','8','9',
				'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
				'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x'});
	Console.WriteLine("SexagesimalTick: {0}",xx);			
}

// Define other methods and classes here
public static string IntToString(long value, char[] baseChars)
    {
        string result = string.Empty;
        int targetBase = baseChars.Length;

        do
        {
            result = baseChars[value % targetBase] + result;
            value = value / targetBase;
        } 
        while (value > 0);

        return result;
    }

    /// <summary>
    /// An optimized method using an array as buffer instead of 
    /// string concatenation. This is faster for return values having 
    /// a length > 1.
    /// </summary>
    public static string IntToStringFast(long value, char[] baseChars)
    {
        // 32 is the worst cast buffer size for base 2 and int.MaxValue
        int i = 32;
        char[] buffer = new char[i];
        int targetBase= baseChars.Length;

        do
        {
            buffer[--i] = baseChars[value % targetBase];
            value = value / targetBase;
        }
        while (value > 0);

        char[] result = new char[32 - i];
        Array.Copy(buffer, i, result, 0, 32 - i);

        return new string(result);
    }