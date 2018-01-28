using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace killercodes.cracking
{
    
    public class WinPswdCracker
    {
        [System.Runtime.InteropServices.DllImport("ADVAPI32.dll", EntryPoint = "LogonUserW")]
        public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, int phToken);

        [System.Runtime.InteropServices.DllImport("advapi32.dll", EntryPoint = "GetUserNameW")]
        public static extern int GetUserName(char[] lpBuffer, int nSize);
        
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern int Beep (int dwFreq, int dwDuration);


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

        private static UInt64 NoPswd;

        static void Main(string[] args)
        {
            System.Console.Title = "BruteForce Windows login";
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.Green;
            DateTime d1 = DateTime.Now;
            Console.WriteLine(d1);
            Console.WriteLine(timelag().Second);
            Console.WriteLine("dasdasdasdASDA");
            Console.WriteLine(timelag().Ticks);
            //int r = 0;
            //foreach(string d in args)
            //{
            //    r+=1;
            //    Console.Write(r);
            //    Console.WriteLine(d);
                
            //}
           // StartBruteForce(4);
         StartBruteForce(Convert.ToInt32(args[0]));
            //CRACK("l");
            DateTime d2 = DateTime.Now;
            TimeSpan delay = d2.Subtract(d1).Duration();
            UInt64 totaldel = Convert.ToUInt64(delay.Seconds) + Convert.ToUInt64(delay.Minutes) + Convert.ToUInt64(delay.Minutes);
            UInt64 res = NoPswd / totaldel;
            Beep(3000, 50);
            Console.WriteLine("\n{0} Passwords in ", NoPswd);
            Console.WriteLine("\n \nTook: {0} Days : {1} Hrs : {2} Min : {3} Sec : {4} Ms : {5} Ticks",
            delay.Days,delay.Hours,delay.Minutes,delay.Seconds,delay.Milliseconds,delay.Ticks);
            Console.WriteLine("{0} password per second\n {1} total delay",res,totaldel );
            Console.ReadLine();
        }

        /// <summary>
        /// Start Brute Force.
        /// </summary>
        /// <param name="length">Words length.</param>
        public static void StartBruteForce(int length)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder(length);
            char currentChar = fCharList[0];

            for (int i = 1; i <= length; i++)
            {
                sb.Append(currentChar);
            }

            ChangeCharacters(0, sb, length);
        }


        static DateTime timelag()
        {
            DateTime nw;
            nw = DateTime.Now;
            return nw;
        }
        //private unsafe int GetUserNameAWrp(ref string lpBuffer, ref int nSize)
        //{
        //    int ret;
        //    IntPtr plpBuffer = GetByteFromString(lpBuffer);

        //    fixed (int* pnSize = &nSize)
        //    {
        //        ret = GetUserName(plpBuffer, pnSize);
        //    }

        //    GetStringFromByte(ref lpBuffer, plpBuffer);
            
        //    return ret;
        //}
        public static void CRACK(string psw)
        {
            int buff = 3727;
            char[] usr_nm = new char[buff]; ;//="";
            GetUserName(usr_nm,buff);
            
            Console.WriteLine("user = [0]",usr_nm);
        }


        private static System.Text.StringBuilder ChangeCharacters(int pos, System.Text.StringBuilder sb, int length)
        {
            
            for (int i = 0; i <= fCharList.Length - 1; i++)
            {
                sb.Replace(sb[pos], fCharList[i], pos, 1);

                if (pos == length - 1)
                {
                    //System.Console.Clear();
                    System.Console.Write("\t");
                    //System.Console.WriteLine("\n ........................");
                    //System.Console.Write("\n \t Current password [ ");
                    //// Write the Brute Force generated word.
                    System.Console.Write(sb.ToString());
                    NoPswd += 1;
                    //System.Console.WriteLine(" ........................");

                    //System.Console.Title = i.ToString();

                }
                else
                {
                    ChangeCharacters(pos + 1, sb, length);
                }
            }

            return sb;
        }
    }
}
