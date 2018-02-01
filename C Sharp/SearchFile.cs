using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Killercodes.FileSearch
{
    class SearchFile
    {
        static void Main(string[] args)
        {
            string startFolder = "C:\\";//args[0];
            string ext = args[0];  //".xml";//

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("GOOGLiNG 4");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" " + ext + "....");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n [on] [");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(startFolder);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" ]\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            try
            {
                // Take a snapshot of the file system.
                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(startFolder);

                // This method assumes that the application has discovery permissions
                // for all folders under the specified path.
                IEnumerable<System.IO.FileInfo> fileList = dir.GetFiles(ext, System.IO.SearchOption.AllDirectories);

                //Create the query
                IEnumerable<System.IO.FileInfo> fileQuery =
                    from file in fileList
                    //where file.Extension == ext
                    orderby file.Name
                    select file;

                //Execute the query. This might write out a lot of files!
                foreach (System.IO.FileInfo fi in fileList)
                {
                    Console.WriteLine("# " + fi.FullName);
                }

                // Create and execute a new query by using the previous 
                // query as a starting point. fileQuery is not 
                // executed again until the call to Last()
                var newestFile =
                    (from file in fileQuery
                     orderby file.CreationTime
                     select new { file.FullName, file.CreationTime, file.Name })
                    .Last();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\r\nThe newest .txt file is [ {0} ]. Creation time: {1}\n",
                    newestFile.Name, newestFile.CreationTime);
                Console.ForegroundColor = ConsoleColor.Gray;
                // Keep the console window open in debug mode.
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
           }
            catch (Exception ex){}
        }
    }
}
