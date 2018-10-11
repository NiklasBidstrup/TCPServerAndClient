using System;

namespace OOClient
{
    class Program
    {
        private const int ConnectToPort = 7;
        private const String ConnectToHost = "localhost";

        static void Main(string[] args)
        {
            Client client = new Client(ConnectToHost, ConnectToPort);
            client.Start();

            Console.ReadLine();
        }
    }
}
