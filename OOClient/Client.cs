using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OOClient
{
    public class Client
    {
        private readonly string connectToHost;
        private readonly int connectToPort;

        public Client(string connectToHost, int connectToPort)
        {
            this.connectToHost = connectToHost;
            this.connectToPort = connectToPort;
        }

        public void Start()
        {
            using (TcpClient clientSocket = new TcpClient(connectToHost, connectToPort))
            using (StreamReader sr = new StreamReader(clientSocket.GetStream()))
            using (StreamWriter sw = new StreamWriter(clientSocket.GetStream()))
            {
                // read from console
                Console.Write("Type in a line : ");
                String str = Console.ReadLine();

                // send to server
                sw.WriteLine(str);
                sw.Flush();

                // read response from server
                String inStr = sr.ReadLine();

                Console.WriteLine("From server: " + inStr);
            }

            ;
        }
    }
}
