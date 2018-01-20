// Convert plain text to 1337 in C#

/// project: Leet
/// Dated: 22 Aug 2008
/// Remarks: It converts a plain string to Leet text.. make objects Leet l = new Leet();
/// Public Methods: LowerLEET(),MediumLEET(),ExtremeLEET(),UpsideDOWN()
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace killercodes.leetTyping
{
    class Leet
    {


        //Array Declaration
        string[] arr = new string[] { 
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", 
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", ".", " ", "[", "]" };
        string[] larr = new string[] { 
            "4", "8", "(", "d", "3", "f", "9", "#", "!", "j", "k", "1", "m", "~", "0", "p", 
            "q", "r", "5", "7", "u", "v", "w", "*", "y", "2", ".", " ", "[", "]" };
        string[] Marr = new string[] {
            "/\\", "I3", "(", "|)", "3", "|=", "6", "|-|", "|", "_|", "|<", "|_", "]\\/[", 
            "]\\[", "0", "9", "(,)", "|2", "5", "+", "|_|", "\\/", "|/\\|", "><", "\\-/", "2", ".", " ", "[", "]" };
        string[] Earr = new string[] { 
            "@", "ß", "©", "Đ", "Ǝ", "Ƒ", "ĝ", "Ħ", "Ï", "ĵ", "Ķ", "|", "ɰ", "¶", "Φ", "Þ", 
            "ƍ", "®", "5", "+", "µ", "▼", "Ш", "Ж", "¥", "2", ".", " ", "[", "]" };
        string[] UDarr = new string[] { 
            "ɐ", "q", "ɔ", "p", "ǝ", "ɟ", "ƃ", "ɥ", "ı", "ɾ", "ʞ", "ן", "ɯ", "u", 
            "o", "d", "b", "ɹ", "s", "ʇ", "n", "Λ", "ʍ", "x", "ʎ", "z", ".", " ", "]", "[" };


        // Makes a Lower LEET function
        public string LowerLEET(string plaintext)
        {
            string RESULT = "";
            if (plaintext.Length <= 0)
            {
                RESULT = "Not enough parameter\nUnable to Continue..";
            }
            else
            {
                foreach (char ch in plaintext)
                {
                    if (Convert.ToInt32(ch) == Convert.ToInt32(ConsoleKey.Enter))
                    { RESULT = RESULT + "\r\n"; }
                    for (int c = 0; c < arr.Length; c++)
                    {
                        if (ch.ToString() == arr[c])
                            RESULT = RESULT + larr[c];
                    }
                }
            }
            return RESULT;
        }//LwLEET


        // Makes a Lower XlwLEET function
        public string XLowerLEET(string chipertext)
        {
            string RESULT = "";
            if (chipertext.Length <= 0)
            {
                RESULT = "Not enough parameter\nUnable to Continue..";
            }
            else
            {
                foreach (char ch in chipertext)
                {
                    for (int c = 0; c < larr.Length; c++)
                    {
                        if (ch.ToString() == larr[c])
                            RESULT = RESULT + arr[c];
                    }
                }
            }
            return RESULT;
        }


        // Makes a Medium LEET function
        public string MediumLEET(string plaintext)
        {
            string RESULT = "";
            if (plaintext.Length <= 0)
            {
                RESULT = "Not enough parameter\nUnable to Continue..";
            }
            else
            {

                foreach (char ch in plaintext)
                {
                    if (Convert.ToInt32(ch) == Convert.ToInt32(ConsoleKey.Enter))
                    { RESULT = RESULT + "\r\n"; }
                    for (int c = 0; c < arr.Length; c++)
                    {
                        if (ch.ToString() == arr[c])
                            RESULT = RESULT + Marr[c];
                    }
                }
            }
            return RESULT;
        }//MdLEET


        // Makes a string upside down
        public string UpsideDOWN(string chipertext)
        {
            string RESULT = "";

            foreach (char ch in chipertext)
            {
                bool ENTER = false;
                bool FOUND = false;
                //int c=0;
                //string r = "",a,x;
                int c = 0, gp, tmp = 1;
                gp = Convert.ToInt32(ch);
                if (gp == 13)
                { ENTER = true; }
                else
                { ENTER = false; }
                for (; c < arr.Length; c++) //while (c < arr.Length) 
                {
                    //a = arr[c];
                    //x = ch.ToString();
                    //test = ch.ToString().Equals(arr[c]);
                    if (ch.ToString() == arr[c])
                    {
                        //r = UDarr[c]; 
                        RESULT = UDarr[c] + RESULT;
                        FOUND = true;

                    }
                    tmp = c;
                    //RESULT = r + RESULT;
                    //c++;
                }
                if (ENTER == true)
                { RESULT = "\r\n" + RESULT; }
                //if (FOUND == false)
                //{ RESULT = arr[tmp] + RESULT; }

            }
            //}
            return RESULT;
        }//Upside Down


        // Makes a Extreme LEET function
        public string ExtremeLEET(string plaintext)
        {
            //bool ENTER = false;
            string RESULT = "";
            if (plaintext.Length <= 0)
            {
                RESULT = "Not enough parameter\nUnable to Continue..";
            }
            else
            {
                foreach (char ch in plaintext)
                {
                    //int GK = Convert.ToInt32(ch);
                    if (Convert.ToInt32(ch) == Convert.ToInt32(ConsoleKey.Enter))
                    { RESULT = RESULT + "\r\n"; }
                    int c = 0;
                    for (; c < arr.Length; c++)
                    {
                        if (ch.ToString() == arr[c])
                        {
                            RESULT = RESULT + Earr[c];
                            //ENTER = false;
                        }
                    }
                }
            }
            return RESULT;
        }//ExLEET
    }
}
