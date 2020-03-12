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
	bool Execute = true;
   Parallel.ForEach(Infinite(), new ParallelOptions(), new Action<bool>((val) =>  
   {  
   		if(Execute == true)
       		Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff"));  
		else
			return;
	   
   })); 
   Execute = false;
}

// Define other methods and classes here

private IEnumerable<bool> Infinite()  
{  
    while (true)  
    {  
		Thread.Sleep(1000);
        yield return true;  
    }  
}