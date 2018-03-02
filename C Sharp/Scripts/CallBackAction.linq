<Query Kind="Program" />

void Main()
{
	 EvenNumbers.callback = (i) => Console.WriteLine("Number hit" + i);
    EvenNumbers.Run();
}

// Define other methods and classes here
static class EvenNumbers
{
    public static Action<int> callback;

    public static void Run()
    {
       for (int i = 0; i < 10; i++)
		{
			
			if (i%2 == 0)
			{
				if(callback != null)
					callback(i);
			}
		}
    }
}
