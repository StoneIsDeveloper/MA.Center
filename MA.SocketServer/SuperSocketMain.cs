using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using SuperSocket.SocketEngine.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.SocketServer
{
    /// <summary>
    /// Session:每个用户的连接
    /// AppServer:Socket服务器的实例
    /// </summary>
    public class SuperSocketMain
    {
        public static void Init()
        {
            
            Console.WriteLine("Welcome to SuperSocket SocketService");
            IBootstrap bootstrap = BootstrapFactory.CreateBootstrap();
            if (!bootstrap.Initialize())
            {
                Console.WriteLine("初始化");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("启动中");
            var result = bootstrap.Start();
            foreach (var server in bootstrap.AppServers)
            {
                if(server.State == ServerState.Running)
                {
                    Console.WriteLine($"- {server.Name} 运行中");
                }
                else
                {
                    Console.WriteLine($"- {server.Name} 启动失败");
                }
            }

        }
    }
}
