using System; 
using System.Collections; 
using System.Text; 

namespace Killercodes.Cracking 
{ 
    public class Bruteforce : IEnumerable 
    { 
        #region constructors 
        private StringBuilder sb = new StringBuilder();
        //the string we want to permutate 
        public string charset = "abcdefghijklmnopqrstuvwxyz";
        private ulong len;
        private int _max; 
        public int max { get { return _max; } set { _max = value; } }
        private int _min; 
        public int min { get { return _min; } set { _min = value; } } 
        #endregion 

        #region Methods
        public System.Collections.IEnumerator GetEnumerator() 
        { 
            len = (ulong)this.charset.Length;
            for (double x = min; x <= max; x++) 
            { 
                ulong total = (ulong)Math.Pow((double)charset.Length, (double)x); 
                ulong counter = 0; 
                while (counter < total) 
                { 
                    string a = factoradic(counter, x - 1); 
                    yield return a; 
                    counter++; 
                } 
            } 
        }
        private string factoradic(ulong l, double power) 
        { 
            sb.Length = 0; 
            while (power >= 0) 
            { 
                sb = sb.Append(this.charset[(int)(l % len)]); 
                l /= len; 
                power--; 
            } 
            return sb.ToString(); 
        } 
        #endregion 
    } 
    
    public class BruteForce2
    {
        // Array with characters to use in Brute Force Algorithm.
        // You can remove or add more characters in this array.
        private static char[] fCharList =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
            'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8',
            '9', '0','.'
        };

        /// <summary>
        /// Start Brute Force.
        /// </summary>
        /// <param name="length">Words length.</param>
        public static void StartBruteForce (int length)
        {
            StringBuilder sb = new StringBuilder(length);
            char currentChar = fCharList[0];

            for (int i = 1; i <= length; i++)
                sb.Append(currentChar);
            
            ChangeCharacters(0, sb, length);
        }

        private static StringBuilder ChangeCharacters (int pos,StringBuilder sb, int length)
        {
            for (int i = 0; i <= fCharList.Length - 1; i++)
            {
                sb.Replace(sb[pos], fCharList[i], pos, 1);
                if (pos == length - 1)
                {
                    System.Console.Write("\t");
                    System.Console.Write(sb.ToString());
                }
                else
                    ChangeCharacters(pos + 1, sb, length);
            }
            return sb;
        }
    }
}


/*namespace example 
{ 
     class Program 
     { 
         static void Main(string[] args) 
         { 
             Bruteforce b = new Bruteforce(); 
             b.min = 2; 
             b.max = 4; 
             b.charset = "abcdefghijklmnopqrstuvwxyz0123456789"; 
             string target= "abc1"; 
             foreach (string result in b) 
             { 
                  Console.Write(result +"\r"); 
                  if (result == target) 
                  { 
                       Console.WriteLine("target found:" + result); 
                       return; 
                  } 
             } 
         } 
     }
}
*/
//}
