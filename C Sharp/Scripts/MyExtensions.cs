void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
	
}

//Linqpad Extensions
public static class MyExtensions
{
	// Write custom extension methods here. They will be available to all queries.
	
	public static void _l(this object obj)
	{
		Console.Write(obj);
	}
	
	public static void _(this object obj)
	{
		Console.WriteLine(obj); 
	}
	
	public static string ToBinary(this long value)
    {
		char[] baseChars = new char[] { '0', '1' };
        string result = string.Empty;
        int targetBase = baseChars.Length;
        do
        {
            result = baseChars[value % targetBase] + result;
            value = value / targetBase;
        } 
        while (value > 0);
        return result;
    }
	
	public static string ToString(this Exception exception) 
	{
		PropertyInfo[] properties = exception.GetType().GetProperties();
		List<string> fields = new List<string>();
		foreach(PropertyInfo property in properties) {
			object value = property.GetValue(exception, null);
			fields.Add(String.Format(
							"{0} = {1}",
							property.Name,
							value != null ? value.ToString() : String.Empty
			));    
		}
		if(exception.InnerException != null){
			fields.Add(exception.InnerException.ToString());
		}
		return String.Join("\n", fields.ToArray());
	}
	
	public static string ToBinary(this int value)
    {
		char[] baseChars = new char[] { '0', '1' };
        string result = string.Empty;
        int targetBase = baseChars.Length;
        do
        {
            result = baseChars[value % targetBase] + result;
            value = value / targetBase;
        } 
        while (value > 0);
        return result;
    }
	
	public static string ToHex(this int value)
    {
		char[] baseChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','A', 'B', 'C', 'D', 'E', 'F'};
        string result = string.Empty;
        int targetBase = baseChars.Length;
        do
        {
            result = baseChars[value % targetBase] + result;
            value = value / targetBase;
        } 
        while (value > 0);
        return result;
    }
	
	public static string ToStringHex(this string data){
		string hexOutput=null;
		foreach (char _eachChar in data.ToCharArray() ){
			int value = Convert.ToInt32(_eachChar);
			hexOutput += String.Format("x{0:X}", value);
		}
		
		return hexOutput;
	}
	
	public static string ToHex(this long value)
    {
		char[] baseChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9','A', 'B', 'C', 'D', 'E', 'F'};
        string result = string.Empty;
        int targetBase = baseChars.Length;
        do
        {
            result = baseChars[value % targetBase] + result;
            value = value / targetBase;
        } 
        while (value > 0);
        return result;
    }
	
    public static string Whois(this string domainName)
	{
		int Whois_Server_Default_PortNumber = 43;
		string Domain_Record_Type = "domain";
		string DotCom_Whois_Server = "whois.verisign-grs.com";
		using (TcpClient whoisClient = new TcpClient())
		{
			whoisClient.Connect(DotCom_Whois_Server, Whois_Server_Default_PortNumber);
		
			string domainQuery = Domain_Record_Type + " " + domainName + "\r\n";
			byte[] domainQueryBytes = Encoding.ASCII.GetBytes(domainQuery.ToCharArray());
		
			Stream whoisStream = whoisClient.GetStream();
			whoisStream.Write(domainQueryBytes, 0, domainQueryBytes.Length);
		
			StreamReader whoisStreamReader = new StreamReader(whoisClient.GetStream(), Encoding.ASCII);
		
			string streamOutputContent = "";
			List<string> whoisData = new List<string>();
			while (null != (streamOutputContent = whoisStreamReader.ReadLine()))
			{
				whoisData.Add(streamOutputContent);
			}
		
			whoisClient.Close();
		
			return String.Join(Environment.NewLine, whoisData);
		}            
	}        
	
	//Serialize
    public static string Serialize<T>(this T dynamicEntity)
    {
        StringWriter stringwriter = new StringWriter();
        XmlSerializer serilizer = new XmlSerializer(dynamicEntity.GetType());
        serilizer.Serialize(stringwriter, dynamicEntity);
        return stringwriter.ToString();
    }

    //Deserialize
    public static T deserialize<T>(this string serializeEntity)
    {
        var stringReader = new StringReader(serializeEntity);
        var serializer = new XmlSerializer(typeof(T));
        return (T)serializer.Deserialize(stringReader);
    }
	
	public static string InnerXML (this XElement xElement)
	{
		var reader = xElement.CreateReader();
		reader.MoveToContent();
		return reader.ReadInnerXml();
	}
	
	public static string OuterXML (this XElement xElement)
	{
		var reader = xElement.CreateReader();
		reader.MoveToContent();
		return reader.ReadOuterXml();
	}
	
	private static XElement RemoveAllNamespaces (this XElement xElement)
	{
		if (!xElement.HasElements)
		{
			XElement newXElement = new XElement(xElement.Name.LocalName);
			newXElement.Value = xElement.Value;
		
			foreach (XAttribute attribute in xElement.Attributes())
				newXElement.Add(attribute);
		
			return newXElement;
		}
		return new XElement(xElement.Name.LocalName, xElement.Elements().Select(el => RemoveAllNamespaces(el)));
	}
	
	public static string ApplyTransformation (this string xmlContent, string xsltFilePath)
	{
		XslCompiledTransform transform = new XslCompiledTransform(true);
		transform.Load(xsltFilePath, XsltSettings.TrustedXslt, new XmlUrlResolver());
		
		XElement xmlDocumentWithoutNs = null;
		if (xmlContent.EndsWith(".xml", StringComparison.InvariantCultureIgnoreCase))
		{
			xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse((File.ReadAllText(xmlContent))));
		}
		else
		{
			xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlContent));
		}
		
		XmlReader reader = XmlReader.Create(new StringReader(xmlDocumentWithoutNs.ToString()));
		StringWriter output = new StringWriter();
		XmlWriter writer = XmlWriter.Create(output, transform.OutputSettings);
		transform.Transform(reader, writer);
		return output.ToString();
	}
}

// You can also define non-static classes, enums, etc.
