// Helper class to work with console application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace killercode.console
{
    /// <summary>
    /// Creates a Smart console
    /// </summary>
    public class QuickConsole
    {
        /// <summary>
        /// Title of the console
        /// </summary>
        private String Title { get; set; }

        /// <summary>
        /// Creates  QuickConsole with default theme
        /// </summary>
        /// <param name="ConsoleTitle" />Title
        public QuickConsole(String ConsoleTitle)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Title = "/&gt; " + ConsoleTitle.Split(',')[0] + " - \"" + ConsoleTitle.Split(',')[1] + "\" ";


            for (int i = 0; i &lt; Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }
            Console.Write(Title);
            for (int i = 0; i &lt; Console.WindowWidth - Title.Length; i++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i &lt; Console.WindowWidth; i++)
            {
                Console.Write("_");
            }
            this.NextLine().NextLine();
            this.ResetColor();
        }

        /// <summary>
        /// Creates  QuickConsole with custom theme
        /// </summary>
        /// <param name="ConsoleTitle" />Title 
        /// <param name="ForeColor" />ConsoleColor
        /// <param name="BackColor" />ConsoleColor
        public QuickConsole(String ConsoleTitle,ConsoleColor ForeColor,ConsoleColor BackColor)
        {
            Title = "/&gt; " + ConsoleTitle.Split(',')[0] + " - \"" + ConsoleTitle.Split(',')[1] + "\" ";
            Console.ForegroundColor = ForeColor;
            Console.BackgroundColor = BackColor;

            for (int i = 0; i &lt; Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }
            Console.Write(Title);
            for (int i = 0; i &lt; Console.WindowWidth - Title.Length; i++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i &lt; Console.WindowWidth; i++)
            {
                Console.Write("_");
            }
            this.NextLine().NextLine();
            this.ResetColor();
        }

        /// <summary>
        /// Sets the background color of QuickConsole
        /// </summary>
        /// <param name="BackgroundColor" />ConsoleColor
        /// <returns>QuickConsole</returns>
        public QuickConsole BackColor(ConsoleColor BackgroundColor)
        {
            Console.BackgroundColor = BackgroundColor;
            return this;
        }

        /// <summary>
        /// Sets the foreground color of QuickConsole 
        /// </summary>
        /// <param name="ForegroundColor" />ConsoleColor
        /// <returns>QuickConsole</returns>
        public QuickConsole ForeColor(ConsoleColor ForegroundColor)
        {
            Console.ForegroundColor = ForegroundColor;
            return this;
        }

        /// <summary>
        /// Prompts for input
        /// </summary>
        /// <param name="Message" />Prompt message
        /// <returns>QuickConsole</returns>
        public String Prompt(String Message)
        {           
            Console.Write("[\u263C] " + Message + ": ");
            this.ResetColor();
            return Console.ReadLine();
        }

        /// <summary>
        /// Prints the status
        /// </summary>
        /// <param name="StatusMessage" />String message
        /// <returns>QuickConsole</returns>
        public QuickConsole Print(String Message)
        {
            Console.Write("\u00BB " + Message + "..");
            this.ResetColor();
            return this;
        }

        /// <summary>
        /// Prints the status with arguments
        /// </summary>
        /// <param name="Format" />format
        /// <param name="args" />arguments
        /// <returns>QuickConsole</returns>
        public QuickConsole Print(String Format, params Object[] args)
        {
            String _message = String.Format(Format, args);
            Console.WriteLine("    \u00BB " + _message + "...");
            return this;
        }

        /// <summary>
        /// Updates the status
        /// </summary>
        /// <param name="StatusMessage" />String message: This will be overwritten 
        /// <returns>QuickConsole</returns>
        public QuickConsole Status(String StatusMessage)
        {
            Console.Write("[*]\r  " + StatusMessage + "...");
            this.ResetColor();
            return this;
        }

        /// <summary>
        /// Updates the status
        /// </summary>
        /// <param name="StatusMessage" />
        /// <param name="args" />
        /// <returns>QuickConsole</returns>
        public QuickConsole Status(String StatusMessage, params Object[] args)
        {
            String _message = String.Format(StatusMessage, args);
            Console.Write("[*]\r  " + _message + "...");
            this.ResetColor();
            return this;
        }

        /// <summary>
        /// Prints the result
        /// </summary>
        /// <param name="ResultString" />result string
        /// <returns>QuickConsole</returns>
        public QuickConsole Result(String ResultString)
        {
            Console.WriteLine("[" +(char)16 + "] "+ResultString);
            this.ResetColor();
            return this;
        }

        /// <summary>
        /// Prints the result
        /// </summary>
        /// <param name="ResultString" />
        /// <param name="args" />
        /// <returns></returns>
        public QuickConsole Result(String ResultString, params Object[] args)
        {
            String _message = String.Format(ResultString, args);
            Console.WriteLine("[+]  " + _message + "  [+]");
            return this;
        }

        /// <summary>
        /// Prints error to the console
        /// </summary>
        /// <param name="ErrorMessage" />
        /// <returns></returns>
        public QuickConsole Error(String ErrorMessage)
        {
            Console.Beep(2500, 100);
            Console.WriteLine("[x] " + ErrorMessage);
            Console.Beep(2500, 100);
            this.ResetColor();
            return this;
        }

        /// <summary>
        /// Prints error to the console
        /// </summary>
        /// <param name="ErrorMessage" />
        /// <param name="args" />
        /// <returns></returns>
        public QuickConsole Error(String ErrorMessage, params Object[] args)
        {
            String _message = String.Format(ErrorMessage, args);
            Console.Beep(2500, 500);
            Console.WriteLine("[x]  " + _message);
            Console.Beep(2500, 500);
            this.ResetColor();
            return this;
        }

        /// <summary>
        /// Prompt for password
        /// </summary>
        /// <param name="PasswordMessage" />
        /// <returns></returns>
        public String MaskPassword(String PasswordMessage)
        {
            Console.Write("[\u263C] {0}: ", PasswordMessage);
            ConsoleKeyInfo keyInfo; string pass = string.Empty;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key != ConsoleKey.Backspace) // Backspace Should Not Work
                {
                    pass += keyInfo.KeyChar;
                    if (keyInfo.Key != ConsoleKey.Enter)
                        Console.Write("*");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            this.NextLine();
            this.ResetColor();
            return pass.Trim(); 
        }

        /// <summary>
        /// Prints tab to the console
        /// </summary>
        /// <returns></returns>
        public QuickConsole Tab()
        {
            Console.Write("    ");
            return this;
        }

        /// <summary>
        /// Prints Next line
        /// </summary>
        /// <returns></returns>
        public QuickConsole NextLine()
        {
            Console.WriteLine();
            return this;
        }

        /// <summary>
        /// Pauses the console
        /// </summary>
        /// <returns></returns>
        public QuickConsole Pause()
        {
            Console.WriteLine("\n  \"Press any key to continue..\"");
            Console.Read();
            this.ResetColor();
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public QuickConsole Exit()
        {
            Console.WriteLine("[#] Press any key to Exit..");
            Console.Read();
            this.ResetColor();
            
            return this;
        }

        public QuickConsole ResetColor()
        {
            Console.ResetColor();
            return this;
        }

        public QuickConsole ResetColor(ConsoleColor ForgroundColor,ConsoleColor BackgroundColor)
        {
            Console.ResetColor();
            Console.ForegroundColor = ForgroundColor;
            Console.BackgroundColor = BackgroundColor;
            return this;
        }

        public void ExecuteParallel(params Action[] actions)
        {
             // Initialize the reset events to keep track of completed threads
                ManualResetEvent[] resetEvents = new ManualResetEvent[actions.Length];

                // Launch each method in it's own thread
                for (int i = 0; i &lt; actions.Length; i++)
                {
                    resetEvents[i] = new ManualResetEvent(false);
                    ThreadPool.QueueUserWorkItem(new WaitCallback((object index) =&gt;
                    {
                        int actionIndex = (int)index;

                        // Execute the method
                        actions[actionIndex]();

                        // Tell the calling thread that we're done
                        resetEvents[actionIndex].Set();
                    }), i);
                }

                // Wait for all threads to execute
                WaitHandle.WaitAll(resetEvents);
        }
    }
}
