<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Security</Namespace>
  <Namespace>System.Security.Cryptography.X509Certificates</Namespace>
</Query>

void Main()
{
	string Url =  "http://indiatyping.com/index.php";
	var wrt = new WebRequestTest();
	//wrt.Trace(Url);
	wrt.GetOptions(Url);
	
}

// Define other methods and classes here

class WebRequestTest
    {
        private DateTime counter1;
        long minDuration = -1;
        long maxDuration = -1;
        private static ConsoleColor Highlighter;
		int aseconds = 2;
		
		// Generic call
		private HttpWebRequest Request(string address)
		{
			 HttpWebRequest _wr = (HttpWebRequest)WebRequest.Create(address);
                _wr.Credentials = CredentialCache.DefaultCredentials;
			return _wr;
		}
		
		private void Response(HttpWebRequest _wreq)		
		{
		try{
		    var _wresp = _wreq.GetResponse(); 
			 Fwrite(String.Format(" Status: [{0}] \n", ((HttpWebResponse)_wresp).StatusDescription));
			  Fwrite(String.Format(" [{0}]",((HttpWebResponse)_wresp).Headers));
                using (Stream _strm = _wresp.GetResponseStream())
				{
                	using(StreamReader _strmRdr = new StreamReader(_strm))
					{
                		string responseFromServer = _strmRdr.ReadToEnd();
                			Console.WriteLine(" ResponseLength: {0} \n", responseFromServer.Length);
							Console.WriteLine(" Response: {0} \n", responseFromServer);
					}
				}
		}
		catch(Exception e){
			Console.WriteLine(" [X]",e.Message);
		}
		}
		
		//TRACE
		public void Trace(string webUrl)
		{
		    //Fwrite(String.Format(" Request: [{0}] \n", webUrl));
			var hwr = Request(webUrl);
			hwr.ContentType = "*/*; charset=utf-8";
			hwr.Host = "www.testtools.com";
			Response(hwr);
		}
		
		//HEADER
		public void ResponseBody(string webUrl)
		{
			var hwr = Request(webUrl);
			hwr.ContentType = "*/*; charset=utf-8";
			hwr.Host ="http:\\abc.con";
			Response(hwr);
		}
		
		//Options
		public void GetOptions(string webUrl)
		{
			var hwr = Request(webUrl);
			hwr.ContentType = "*/*; charset=utf-8";
			hwr.Host ="www.abc.con";
			hwr.Method = "OPTIONS";
			Response(hwr);
		}
		
        public double CreateRequest(string address, bool ShowOutput)
        {
            double totalTImeout = 0;
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            //Console.Write("\"{0}\"",address);
            //counter1 = DateTime.Now;
            SetHighlightColor(ConsoleColor.Yellow);


            WebResponse _wresp;
            try
            {
                HttpWebRequest _wr = (HttpWebRequest)WebRequest.Create(address);
                _wr.Credentials = CredentialCache.DefaultCredentials;
                _wr.ContentType = "*/*; charset=utf-8";
                _wr.Host = "www.test.com";
                _wr.Method = "GET";
                _wr.Headers.Add("CacheControl", "no-cache");
                _wr.UserAgent = "serviceTest\r\n";
                //_wr.Headers.Set(HttpRequestHeader.IfModifiedSince, "Sat, 01 Jan 2000 00:00:00 GMT");
                //_wr.Headers.Add(HttpRequestHeader.Connection,"keep-alive");
                //_wr.Headers.Set(HttpRequestHeader.Connection, "keep-alive");

                watch.Start(); // START
                _wresp = _wr.GetResponse();
                watch.Stop(); //STOP

                Fwrite(String.Format("| Status: [{0}] |", ((HttpWebResponse)_wresp).StatusDescription));
                Stream _strm = _wresp.GetResponseStream();
                StreamReader _strmRdr = new StreamReader(_strm);
                string responseFromServer = _strmRdr.ReadToEnd();
				if(ShowOutput)
                	Console.Write("\nResponseLength:\n {0}| \n", responseFromServer);
					
                _strmRdr.Close();
                _wresp.Close();
            }
            catch (System.Net.WebException e)
            {
                Ferror(String.Format("| Status: [{0}] |", e.Status.ToString()));
            }


            TimeSpan elapsedSpan = watch.Elapsed;//new TimeSpan(elapsedTicks);

            ConsoleColor def = Console.ForegroundColor;
            Console.Write(" Response:");
            //Console.ForegroundColor = ConsoleColor.Green;
            if (elapsedSpan.TotalSeconds < aseconds)
            {
                Print(ConsoleColor.Green, " {0} Milliseconds\n", elapsedSpan.Milliseconds);

            }
            else
            {
                Print(ConsoleColor.Red, " {0} MiliSec\n", elapsedSpan.Milliseconds);
            }
            totalTImeout += elapsedSpan.TotalSeconds;
            //Console.Write("  {0:N0} nanoseconds", elapsedTicks * 100);
            // Console.Write("  {0} ticks", elapsedTicks);
            //Console.Write(" or  {0} seconds\n", elapsedSpan.TotalSeconds);
            //Console.Write("  {0:N2} minutes", elapsedSpan.TotalMinutes);
            //Console.Write("  {0:N0} days, {1} hours, {2} minutes, {3} seconds", elapsedSpan.Days, elapsedSpan.Hours, elapsedSpan.Minutes, elapsedSpan.Seconds);
            // Console.ForegroundColor = def;

            return totalTImeout;
        }

        private void Print(ConsoleColor color, string format, params object[] obj)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            string str = string.Format(format, obj);
            Console.Write(str);
            Console.ForegroundColor = def;
        }

        public static void SetHighlightColor(ConsoleColor color) { Highlighter = color; }
        public static void ResetColor() { Console.ResetColor(); }
        public static void Fwrite(string Msg)
        {
            var tt = Msg.Split('<', '>', '{', '}', '[', ']');
            for (int i = 0; i < tt.Length; i++)
            {
                if (i % 2 == 0)
                {
                    System.Console.Write(tt[i]);
                }
                else
                {

                    var defaultColor1 = System.Console.ForegroundColor;
                    System.Console.ForegroundColor = Highlighter;
                    System.Console.Write(tt[i]);
                    System.Console.ForegroundColor = defaultColor1;
                }
            }
            //System.Console.Write('\n');
        }

        public static void Ferror(string Msg)
        {
            var tt = Msg.Split('<', '>', '{', '}', '[', ']');
            for (int i = 0; i < tt.Length; i++)
            {
                if (i % 2 == 0)
                {
                    System.Console.Write(tt[i]);

                }
                else
                {
                    var defaultColor1 = System.Console.ForegroundColor;
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Write(tt[i]);
                    System.Console.ForegroundColor = defaultColor1;
                }
            }
            //System.Console.Write('\n');
        }

    }
