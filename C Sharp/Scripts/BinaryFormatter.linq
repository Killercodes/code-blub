<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Data</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Runtime.Serialization</Namespace>
  <Namespace>System.Runtime.Serialization.Formatters.Binary</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	BinaryFormatter formatter = new BinaryFormatter();
         FileStream output = new FileStream( "test.dat",FileMode.OpenOrCreate, FileAccess.Write );
         Record record = new Record()
		 {
         record.Account = 1234;
         record.FirstName = "FirstName";
         record.LastName = "LastName";
         record.Balance = 1234.345;
		 };

         formatter.Serialize( output, record );
         output.Close();
      
      
         BinaryFormatter reader = new BinaryFormatter();
         FileStream input = new FileStream( "test.dat", FileMode.Open, FileAccess.Read );
         Record record1 =( Record )reader.Deserialize( input );
         
         Console.WriteLine(record1.FirstName);
}

// Define other methods and classes here
[Serializable]
   public class Record{
      public int Account;
      public String FirstName;
      public String LastName;
      public double Balance;
   }