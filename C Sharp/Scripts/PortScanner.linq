<Query Kind="Program">
  <Namespace>System.Net.Sockets</Namespace>
</Query>

void Main()
{
	string IpAddress = "127.0.0.1";

	for (int CurrPort = 79; CurrPort <= 85; CurrPort++)
	{
		
		TcpClient TcpScan = new TcpClient();	
		try	
		{
			TcpScan.Connect(IpAddress, CurrPort); 
			Console.WriteLine("Port " + CurrPort + " open"); 
		} 
		
		catch 	
		{ 	
		// An exception occured, thus the port is probably closed 	
			//Console.Write("Port " + CurrPort + " closed"); 
		} 
	
	}
}

// Define other methods and classes here
