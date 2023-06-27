using static System.Console;
using System.Net;
using System.Net.NetworkInformation;

namespace Packt.Shared
{
    public class Program
    { 
        public static void Main(string[] args) 
        {
            Uri uri = TestURI();
            TestPingServer(uri);
        }

        public static void TestPingServer(Uri uri)
        {
            try
            {
                var ping = new Ping();
                WriteLine("Pining server. Please wait......");
                PingReply reply = ping.Send(uri.Host);

                WriteLine($"{uri.Host} was pinged and response status is {reply.Status}");

                if (reply.Status == IPStatus.Success)
                {
                    WriteLine("Reply from {0} took {1:N0} ms", reply.Address, reply.RoundtripTime);
                }
            }
            catch(Exception ex) 
            {
                WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
            }
        }

        public static Uri TestURI()
        {
            Write("Enter a valid URL");
            string url = ReadLine();
            if (string.IsNullOrEmpty(url))
            {
                url = "https://world.episerver.com/cms/?pagetype";
            }

            var uri = new Uri(url);

            WriteLine($"URL: {url}");
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"AbsolutePath: {uri.AbsolutePath}");
            WriteLine($"Query: {uri.Query}");

            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            WriteLine($"{entry.HostName} has the following IP addresses.");
            foreach (IPAddress address in entry.AddressList)
            {
                WriteLine($" {address}");
            }

            return uri;
        }
    }
}