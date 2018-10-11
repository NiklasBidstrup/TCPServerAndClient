using System;
using System.Xml.Serialization;
using OOServer;

namespace OOGramogOunce
{
    class Program
    {
        private const int Port1 = 7;
        static void Main(string[] args)
        {
            Server server1 = new Server(Port1);
            server1.Start();

        }
    }
}
