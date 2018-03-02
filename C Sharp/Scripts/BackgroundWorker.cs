<Query Kind="Program">
  <Namespace>System.ComponentModel</Namespace>
</Query>

void Main()
{
	BackgroundWorker bw = new BackgroundWorker();
	bw.DoWork += (s,e) => {  
		while(true){ 
				Thread.Sleep(1000); 
				Console.WriteLine("-" + e); 
			} 
	};
	bw.RunWorkerAsync();
}

// Define other methods and classes here
