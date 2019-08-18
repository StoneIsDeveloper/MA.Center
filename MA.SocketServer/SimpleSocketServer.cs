using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MA.SocketServer
{
    public class SimpleSocketServer
    {
        public static void Process()
        {
            int port = 2018;
            string host = "127.0.0.1";

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(ipe);
            socket.Listen(0);
            Console.WriteLine("监听已经打开，请等待...");

            //收到消息，接收一个socket链接
            Socket serverSocket = socket.Accept();
            Console.WriteLine("连接已经建立...");
            while (true)
            {
                string recStr = "";
                byte[] recByte = new byte[4096];
                int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
                recStr += Encoding.Default.GetString(recByte, 0, bytes);
                Console.WriteLine($"服务器端获得信息：{recStr}");

                if (recStr.Equals("stop"))
                {
                    serverSocket.Close();
                    Console.WriteLine("关闭连接");
                    break;
                }

                // 回发消息
                Console.WriteLine("请输入会发消息：");
                string sendStr = Console.ReadLine();
                byte[] sendByte = Encoding.Default.GetBytes(sendStr);
                serverSocket.Send(sendByte, sendByte.Length, 0);

            }

            socket.Close();

        }
    }
}
