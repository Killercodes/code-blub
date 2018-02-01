using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace killercodes.NetInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            String _input;

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            
            // Use the default TTL value which is 128, but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;


                PingReply reply = pingSender.Send("localhost", timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    /* Console.WriteLine("Address: {0}", reply.Address.ToString());
                     Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                     Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                     Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                     Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);*/
                    Console.WriteLine("Address: {0} RoundTrip time: {1} Time to live: {2} Don't fragment: {3} Buffer size: {4}", reply.Address.ToString(), reply.RoundtripTime, reply.Options.Ttl, reply.Options.DontFragment, reply.Buffer.Length);

                }        
                else if(reply.Status == IPStatus.TtlExpired || reply.Status == IPStatus.TimedOut)
                {
                    Console.WriteLine(reply.RoundtripTime);
                }
        }      

        private string  TraceRoute(String Hostname, int TTL)
        {
            string result;
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();


            // Use the default TTL value which is 128, but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;


            PingReply reply = pingSender.Send("localhost", timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                /* Console.WriteLine("Address: {0}", reply.Address.ToString());
                 Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                 Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                 Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                 Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);*/
                Console.WriteLine("Address: {0} RoundTrip time: {1} Time to live: {2} Don't fragment: {3} Buffer size: {4}", reply.Address.ToString(), reply.RoundtripTime, reply.Options.Ttl, reply.Options.DontFragment, reply.Buffer.Length);

            }
            else if (reply.Status == IPStatus.TtlExpired || reply.Status == IPStatus.TimedOut)
            {
                //Console.WriteLine("     {0} RoundTrip time: {1} TTL: {2} Size: {3}", reply.Address.ToString(), reply.RoundtripTime, reply.Options.Ttl, reply.Buffer.Length);
                Console.WriteLine(Hostname);
                //result = TraceRoute(Hostname, TTL + 1);
            }
            return "no";
        }
    }
}
