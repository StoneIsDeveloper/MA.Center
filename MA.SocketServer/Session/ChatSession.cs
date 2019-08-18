using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA.SocketServer.Session
{
    public class ChatSession : AppSession<ChatSession>
    {
        public string Id { get; set; }
        public bool Login { get; set; }
        public DateTime Time { get; set; } 
    }
}
