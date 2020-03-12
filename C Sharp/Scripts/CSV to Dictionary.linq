<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.Compression.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Extensions.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>Microsoft.Crm.Sdk.Messages</Namespace>
  <Namespace>Microsoft.Crm.Sdk.Messages</Namespace>
  <Namespace>Microsoft.Xrm.Sdk</Namespace>
  <Namespace>Microsoft.Xrm.Sdk</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Client</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Client</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Messages</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Metadata</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Query</Namespace>
  <Namespace>Microsoft.Xrm.Sdk.Query</Namespace>
  <Namespace>System.IO.Compression</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
  <Namespace>System.ServiceModel.Description</Namespace>
  <Namespace>System.ServiceModel.Description</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Web.Script.Serialization</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>System.Xml.Xsl</Namespace>
</Query>

void Main()
{
	string csv = "AccountCode=A0017835807S BUCode=DEFOOD -f -h";
	
	//ToDictionary(csv).Dump();
	
	ToList(csv,' ').Dump();
	
}

// Define other methods and classes here
public static Dictionary<string, string> ToDictionary( string stringData, char propertyDelimiter = ' ', char keyValueDelimiter = '=')
{
    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
    Array.ForEach<string>(stringData.Split(propertyDelimiter), s =>
        {
            keyValuePairs.Add(s.Split(keyValueDelimiter)[0], s.Split(keyValueDelimiter)[1]);
        });

    return keyValuePairs;
}

public static List<string> ToList( string stringData, char propertyDelimiter = ' ')
{
    List<string> stringList = new List<string>();
    Array.ForEach<string>(stringData.Split(propertyDelimiter), s =>
        {
            stringList.Add(s);
        });

    return stringList;
}