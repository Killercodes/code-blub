using Microsoft.CSharp;
using System.CodeDom.Compiler;

static void Main()
{
	string sourceCode = @"using System; 
	public class Test{
		public static void Main(){
		}
		public void Hello()
		{ 
			var name = Console.ReadLine();
			Console.Write(""Hello"" + name + "" at "" + DateTime.Now);
		}
	}";

	//or read from a file 
	string readCode = File.ReadAllText(@"test.cs");
   
	Plugin.Status += (s) => Console.WriteLine(s);
    Plugin.Compile(sourceCode,"Test");
		
}

// Define other methods and classes here

public static class Plugin
{	
	//stus
	public delegate void CompilerStatus(string  state);
	public static event CompilerStatus Status;	
	private static void _status(string stat)
	{
		if(Status != null){
			Status(stat);
		}
	}
	
	//Execute
	public static void Execute(string sourceCode,string className, string methodName){
		 var compParms = new CompilerParameters{
			 // True - exe file generation, false - dll file generation
			GenerateExecutable = true, 
			 // True - memory generation, false - external file generation
			 GenerateInMemory = true,
			//OutputAssembly = exeName,
			TreatWarningsAsErrors = false,
			ReferencedAssemblies.Add("System");
    	};
		
		//Add references
		var assemblies = AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => !a.IsDynamic)
                            .Select(a => a.Location);   
							
		compParms.ReferencedAssemblies.AddRange(assemblies.ToArray());
		
		//compile
		var csProvider = new CSharpCodeProvider();
    	CompilerResults compilerResults = csProvider.CompileAssemblyFromSource(compParms, sourceCode);
		if(compilerResults.Errors.Count > 0)
        {
            // Display compilation errors.
            Console.WriteLine("Errors building {0} into {1}",  
                className, compilerResults.PathToAssembly);
            foreach(CompilerError ce in compilerResults.Errors)
            {
                Console.WriteLine("  {0}", ce.ToString());
                Console.WriteLine();
            }
        }
        else
        {
            // Display a successful compilation message.
            Console.WriteLine("Source {0} built into {1} successfully.",
                className, compilerResults.PathToAssembly);
        }
		
		//Execute
		object typeInstance = compilerResults.CompiledAssembly.CreateInstance(className);
    	MethodInfo mi = typeInstance.GetType().GetMethod(methodName);
    	mi.Invoke(typeInstance, null); 				
	}
	
	//Compile Exe
	public static void Compile(string sourceCode,string className, bool isExe){
		 var compParms = new CompilerParameters{
			GenerateExecutable = true, 
			GenerateInMemory = false,
			OutputAssembly = String.Format(@"{0}\{1}.exe", System.Environment.CurrentDirectory,className),
			TreatWarningsAsErrors = false
    	};
		
		//compile
		var csProvider = new CSharpCodeProvider();
    	CompilerResults compilerResults = csProvider.CompileAssemblyFromSource(compParms, sourceCode);
		if(compilerResults.Errors.Count > 0)
        {
            // Display compilation errors.
            Console.WriteLine("Errors building {0} into {1}",  
                className, compilerResults.PathToAssembly);
            foreach(CompilerError ce in compilerResults.Errors)
            {
                Console.WriteLine("  {0}", ce.ToString());
                Console.WriteLine();
            }
        }
        else
        {
            // Display a successful compilation message.
            Console.WriteLine("Source {0} built into {1} successfully.",
                className, compilerResults.PathToAssembly);
        }
						
	}
	
	// compile dll/exe
	public static void Compile(string sourceCode,string className)
	{
		// DLL compiler 
		 var compParms = new CompilerParameters{
			GenerateExecutable = false, 
			GenerateInMemory = false,
			OutputAssembly = String.Format(@"{0}\{1}.dll", System.Environment.CurrentDirectory,className),
			TreatWarningsAsErrors = false,
			//CompilerOptions = "/optimize",
			//IncludeDebugInformation = true,
			//TempFiles = new TempFileCollection(".", true),
			WarningLevel = 3,
			
    		};
		//Exe compilation
		/* var compParmsExe = new CompilerParameters{
			GenerateExecutable = true, 
			GenerateInMemory = false,
			OutputAssembly = String.Format(@"{0}\{1}.exe", System.Environment.CurrentDirectory,className),
			TreatWarningsAsErrors = false,
			//CompilerOptions = "/optimize",
			//IncludeDebugInformation = true,
			//TempFiles = new TempFileCollection(".", true),
			WarningLevel = 3,
			
    		};
		*/
				
		
		//Add all references
		var assemblies = AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => !a.IsDynamic)
                            .Select(a => a.Location);   
							
		compParms.ReferencedAssemblies.AddRange(assemblies.ToArray());
		
		//compile
		var csProvider = new CSharpCodeProvider();
    		CompilerResults compilerResults = csProvider.CompileAssemblyFromSource(compParms, sourceCode);
		if(compilerResults.Errors.Count > 0)
		{
		    // Display compilation errors.
		    Console.WriteLine("Errors building {0} into {1}", className, compilerResults.PathToAssembly);
		    foreach(CompilerError ce in compilerResults.Errors)
		    {
			Console.WriteLine("  {0}", ce.ToString());
			Console.WriteLine();
		    }
		}
		else
		{
		    // Display a successful compilation message.
		    Console.WriteLine("Source {0} built into {1} successfully.",className, compilerResults.PathToAssembly);
		}
	}
}
