using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MA.SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 2018;
            string host = "127.0.0.1";

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(ipe);

            while (true)
            {
                Console.WriteLine($"请输入发送到服务器的信息:");
                string sendStr = Console.ReadLine(); ;
                if(sendStr == "exit")
                {
                    break;
                }

                byte[] sendBytes = Encoding.Default.GetBytes(sendStr);
                clientSocket.Send(sendBytes);

                // receive message
                string recStr = "";
                byte[] recByte = new byte[4096];
                int bytes = clientSocket.Receive(recByte, recByte.Length, 0);
                recStr += Encoding.Default.GetString(recByte, 0, bytes);
                Console.WriteLine($"服务器返回：{recStr}");
            }

            clientSocket.Close();
        }
    }
}
