<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var whoisText = Whois.Lookup("github.com");
    Console.WriteLine(whoisText);
}

// Define other methods and classes here
public class Whois
{
   private const int WhoisServerDefaultPortNumber = 43;
   private const string DomainRecordType = "domain";
   private const string DotComWhoisServer = "whois.verisign-grs.com";

   /// <summary>
   /// Retrieves whois information
   /// </summary>
   /// <param name="domainName">The registrar or domain or name server whose whois information to be retrieved</param>
   /// <param name="recordType">The type of record i.e a domain, nameserver or a registrar</param>
   /// <returns></returns>
   public static string Lookup(string domainName)
   {
       using (TcpClient whoisClient = new TcpClient())
       {
           whoisClient.Connect(DotComWhoisServer, WhoisServerDefaultPortNumber);

           string domainQuery = DomainRecordType + " " + domainName + "\r\n";
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
}