using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using OOClassLibrary;

namespace OOServer
{
    public class Server
    {
        private int PORT1;
        public Server(int Port1)
        {
            PORT1 = Port1;
        }
        public void Start()
        {
            TcpListener serverListener1 = new TcpListener(IPAddress.Loopback, PORT1);
            serverListener1.Start();
            while (true)
            {
                TcpClient tempSocket = serverListener1.AcceptTcpClient();
                Task.Run(() =>
                {
                    DoClient(tempSocket);
                });

            }
        }

        private void DoClient(TcpClient socket1)
        {
            using (StreamReader streamReader1 = new StreamReader(socket1.GetStream()))
            using (StreamWriter streamWriter1 = new StreamWriter(socket1.GetStream()))
            {
                string clientOutput = streamReader1.ReadLine();
                string[] clientOutputString = clientOutput.Split(" ");
                string command = clientOutputString[0];
                double number = Convert.ToDouble(clientOutputString[1]);
                double result = 0;
                Methods lib = new OOClassLibrary.Methods();



                if (command == "TOGRAM")
                {

                     result = lib.ConvertToGram(number);
                }

                if (command == "TOOUNCES")
                {
                    result = lib.ConvertToOunce(number);
                }


                streamWriter1.WriteLine(result);
                streamWriter1.Flush();


            }
        }
    }
}
