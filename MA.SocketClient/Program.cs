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

        /// <summary>
        /// 1 本质理解网络协议
        /// 2 Http和 Socket
        /// 3 Socket Demo 
        /// 4 基于SuperSocket功能实现
        /// 
        /// socekt的特点：跟Http不一样，一次连接，多次通信，Server可以直接给client发消息
        /// 
        /// Http协议也是通过Socket通信
        /// 
        /// socekt:主动发消息给客户端，数据的即时刷新，提升效率，不需要频繁建立和释放连接
        /// 
        /// 多客户端 -- 一个服务端
        /// SuperSocket 完成一个简单的聊天程序：
        /// 登录验证/单点登录/简单数据传输/心跳机制
        /// 
        /// </summary>
        /// <param name="args"></param>
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
