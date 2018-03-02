<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	XDB xdb = new XDB("abc");
	
	Parallel.For(1, 50,
                index =>
                {
					Thread.Sleep(5000);
					xdb.SaveRecord("title"+index,"content_"+index);
					index.Dump();
				});

	
}

// Define other methods and classes here
public class XDB
    {
        private string DatabaseName { get; set; }
		private string Filename { get;set; }

        public XDB(string databaseName)
        {
            DatabaseName = databaseName;
			Filename = databaseName + ".xml";
        }

        private XDocument OpenDatabase()
        {
            if (!File.Exists(Filename))
            {
                XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
                XElement myroot = new XElement(DatabaseName, " ");
                doc.Add(myroot);
                doc.Save(Filename);
                return doc;
            }
            else
            {
                XDocument xd = XDocument.Load(Filename);
                return xd;
            }
        }


        public void SaveRecord(string title, string content)
        {
            XElement titleElement = new XElement("title", title);
            //XAttribute attribute = new XAttribute("createdOn", DateTime.UtcNow.ToString("s"));
            titleElement.SetAttributeValue("createdOn", DateTime.UtcNow.ToString("s"));

            var newRecord = new XElement("record", titleElement, new XElement("contents", new XCData(content)));
            var xd = OpenDatabase();
            xd.Root.Add(newRecord);
            xd.Save(Filename);
        }

        public string SearchRecord(string title)
        {
            XDocument xd = XDocument.Load(Filename);
            var recordFOund = xd.Elements().FirstOrDefault(e => e.Attribute("title").Value == title);

            if (recordFOund != null) 
                return recordFOund.Value;

            return null;
        }

    }
