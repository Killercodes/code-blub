<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//Example of Paralled Processing
	
	Stopwatch watch;
    watch = new Stopwatch();
    watch.Start();
	int seconds = 10;
    //serial implementation
    for (int i = 0; i < seconds; i++)
    {
        Thread.Sleep(1000);
        //Do stuff
    }
    watch.Stop();
    Console.WriteLine("Serial Time:   {0} seconds ",watch.Elapsed.ToString());

    //parallel implementation
    watch = new Stopwatch();
    watch.Start();
    System.Threading.Tasks.Parallel.For(0, seconds, i =>
		{
			Thread.Sleep(1000);
			//Do stuff with i
		}
    );
    watch.Stop();
    Console.WriteLine("Parallel Time: {0} seconds", watch.Elapsed.ToString());

    //Console.ReadLine();
}

// Define other methods and classes here
