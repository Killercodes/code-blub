<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	ExecuteWithReflection("Hello");
	ExecuteWithReflection("Run","jo");
	ExecuteWithReflection("TestNoParameters");
	ExecuteWithReflection("Execute",new object[]{"jo","wo"});
}

// Define other methods and classes here

private void ExecuteWithReflection(string methodName,object parameterObject =null)
{
    Assembly assembly = Assembly.LoadFile("C:\\Program Files (x86)\\LINQPad4\\test2.dll");
    Type typeInstance = assembly.GetType("TestAssembly.Main");

    if (typeInstance != null)
    {
        MethodInfo methodInfo = typeInstance.GetMethod(methodName);
        ParameterInfo[] parameterInfo = methodInfo.GetParameters();
        object classInstance = Activator.CreateInstance(typeInstance, null);
		
        if (parameterInfo.Length == 0)
        {
            // there is no parameter we can call with 'null'
            var result = methodInfo.Invoke(classInstance, null);
        }
        else
        {
            var result = methodInfo.Invoke(classInstance,new object[] { parameterObject } );
        }
    }
}