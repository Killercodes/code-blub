<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	DependencyInfo(@"C:\Users\ivsr\Desktop\EGSP\microsoft.crm.tools.logging.dll");
}

// Define other methods and classes here
public static int DependencyInfo(string args) 
{
	try {
		var assemblies = Assembly.LoadFile(args).GetReferencedAssemblies();	
		if (assemblies.GetLength(0) > 0)
		{
			foreach (var assembly in assemblies)
			{
				Console.WriteLine(assembly);
				//Console.WriteLine(" - " + assembly.FullName + ", ProcessorArchitecture=" + assembly.ProcessorArchitecture);
			}
			return 0;
		}
	}
	catch(Exception e) {
		Console.WriteLine("An exception occurred: {0}", e.Message);
		return 1;
	} 
	finally{}

  	return 1;
}
