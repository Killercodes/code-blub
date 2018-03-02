<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime</Namespace>
</Query>

void Main()
{
//Reflection.Emit  Code Generation
	 AppDomain ad = AppDomain.CurrentDomain;
        
		AssemblyName am = new AssemblyName(){
			Name = "TestAsm"
		};		
        AssemblyBuilder ab = ad.DefineDynamicAssembly(am, AssemblyBuilderAccess.Save);
		
        ModuleBuilder mb = ab.DefineDynamicModule("testmod", "TestAsm.Exe");
        
		TypeBuilder tb = mb.DefineType("TestAsm", TypeAttributes.Public);
        
		MethodBuilder metb = tb.DefineMethod("hiHello", MethodAttributes.Public |MethodAttributes.Static, null, null);
        ab.SetEntryPoint(metb);
        ILGenerator il = metb.GetILGenerator();
        il.EmitWriteLine("Hi Hello World");
        il.Emit(OpCodes.Ret);
		
		MethodBuilder metb2 = tb.DefineMethod("hiHello2", MethodAttributes.Public |MethodAttributes.Static, null, null);
        ILGenerator il2 = metb2.GetILGenerator();
        il2.EmitWriteLine("Hi Hello World 2");
        il2.Emit(OpCodes.Ret);
		
        tb.CreateType();
        ab.Save("TestAsm.Exe");
}

// Define other methods and classes here
