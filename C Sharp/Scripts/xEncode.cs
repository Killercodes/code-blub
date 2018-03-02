void Main()
{
	string str = @"(function()
		{
			alert('hello world');
		}
	)();";
	
	string hex = str.ToStringHex();
	
Console.WriteLine( "Look, I'm so happy : \x28\x66\x75" );
	Console.WriteLine(hex);
	//Console.WriteLine(hex.ToString());
	//hex.Dump();
	//Console.WriteLine(ToCharHex(hex));
}

// Define other methods and classes here
public static string ToCharHex( string data){
		string hexOutput="";
		string[] ch = data.Split('x');
		ch[0] = "28";
		//ch.Dump();
		StringBuilder strinbuilder = new StringBuilder();
		for(int i = 0;i< ch.Length;i++){
			
			//char cf = _eachChar.Replace("x","");
			//_eachChar.Dump();
			//uint decval =   System.Convert.ToUInt32(_eachChar, 16);
			char value = Convert.ToChar(ch[i]);
			Console.WriteLine(ch[i]);
			//hexOutput += String.Format("{0:X}", value);
		}
		hexOutput = strinbuilder.ToString();
		return hexOutput;
	}
