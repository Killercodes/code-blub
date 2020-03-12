<Query Kind="Program">
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	 // A simple source for demonstration purposes. Modify this path as necessary.
        String[] files = System.IO.Directory.GetFiles(@"C:\Users\Public\Downloads\WebEx Connect", "*.*");
        String newDir = @"C:\Users\Public\Pictures\Sample Pictures\Modified";
        System.IO.Directory.CreateDirectory(newDir);

        // Method signature: Parallel.ForEach(IEnumerable<TSource> source, Action<TSource> body)
        // Be sure to add a reference to System.Drawing.dll.
        Parallel.ForEach(files, (currentFile) => 
                                {
                                    // The more computational work you do here, the greater 
                                    // the speedup compared to a sequential foreach loop.
                                    Console.WriteLine(currentFile);
                                });


        // Keep the console window open in debug mode.
        Console.WriteLine("Processing complete. Press any key to exit.");
        Console.ReadKey();
}

// Define other methods and classes here
