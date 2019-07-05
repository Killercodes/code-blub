<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Microsoft.VisualBasic.dll</Reference>
  <Namespace>Microsoft.CSharp</Namespace>
  <Namespace>System.CodeDom.Compiler</Namespace>
</Query>

void Main()
{	
	
	
	string readCode = File.ReadAllText(@"test.cs");

	//  
	Plugin.Status += (s) => Console.WriteLine(s);
    Plugin.Compile(readCode,"asmbelly");
		
} 

// Define other methods and classes here

public static class Plugin
{	
	public delegate void CompilerStatus(string  state);
	public static event CompilerStatus Status;	
	private static void _status(string stat)
	{
		if(Status != null){
			Status(stat);
		}
	}
	
	public static void Execute(string sourceCode,string className, string methodName){
		 var compParms = new CompilerParameters(){
			GenerateExecutable = true, 
			GenerateInMemory = true,
			//OutputAssembly = exeName,
			TreatWarningsAsErrors = false,
			WarningLevel = 3
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
		
		//Execute
		object typeInstance = compilerResults.CompiledAssembly.CreateInstance(className);
    	MethodInfo mi = typeInstance.GetType().GetMethod(methodName);
    	mi.Invoke(typeInstance, null); 				
	}
	
	public static void Compile(string sourceCode,string className)
	{
		//Exe compilation
		 var compParms = new CompilerParameters{
			GenerateExecutable = false, // Generate an executable instead of a class library.
			GenerateInMemory = false, // Save the assembly as a physical file.
			OutputAssembly = String.Format(@"{0}\{1}.dll", System.Environment.CurrentDirectory,className), // Set the assembly file name to generate.
			TreatWarningsAsErrors = false, // Set whether to treat all warnings as errors.
			CompilerOptions = "/optimize", // Set compiler argument to optimize output.
			IncludeDebugInformation = true, // Generate debug information.
			//TempFiles = new TempFileCollection(".", true),
			WarningLevel = 3
    	};
		
		
		
		
		
		//Add references
		var assemblies = AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => !a.IsDynamic)
                            .Select(a => a.Location);
							
		compParms.ReferencedAssemblies.AddRange(assemblies.ToArray()); // Add an assembly reference.
		
		
		
		//compile
		_status("- Compilation started..");
		_status("- GenerateExecutable = false");
		_status("- GenerateInMemory = false");
		_status("- OutputAssembly = " + compParms.OutputAssembly);
		_status("- TreatWarningsAsErrors = false");
		_status("- WarningLevel = 3");
		
		//_status("- ReferencedAssemblies = " + assemblies.ToArray().Count());
		
		var csProvider = new CSharpCodeProvider();
    	CompilerResults compilerResults = csProvider.CompileAssemblyFromSource(compParms, sourceCode);

		if(compilerResults.Errors.Count > 0)
        {
            // Display compilation errors.
            _status("\n[:(] Errors building " + className + " into " + compilerResults.PathToAssembly);
			int errorCount = 1;
            foreach(CompilerError ce in compilerResults.Errors){
                _status(string.Format("  - ERROR {5} ==> {0} {1} on Line {2} column {3} on File {4}",ce.ErrorNumber,ce.ErrorText,ce.Line,ce.Column,ce.FileName,errorCount));      
				errorCount++;
			}
        }
        else
        {
		compilerResults.CompiledAssembly.Dump();
            // Display a successful compilation message.
            _status("\n[:)] Source " + className + " built into " + compilerResults.PathToAssembly + " successfully.");
        }
	}
}