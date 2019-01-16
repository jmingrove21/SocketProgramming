using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace SocketProgramming_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }
        public Program()
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            client.Connect(ipep);
            Console.WriteLine("Socket Connect!");
            Byte[] buf = new Byte[1024];
            client.Receive(buf);
            String rec_buf = Encoding.Default.GetString(buf);
            Console.WriteLine(rec_buf);

            String send_str = "Send messeage by client";
            Byte[] send_buf = new Byte[1024];
            send_buf = Encoding.UTF8.GetBytes(send_str);
            client.Send(send_buf);

            client.Close();
            
        }
    }
}
