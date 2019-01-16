using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace SocketProgramming
{
    class Program//server Section
    {
        public static string dateTime ="["+DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+"]";
        public static int port_number = 12345;
        static void Main(string[] args)
        {
            new Program();
        }
        public Program()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port_number);
            server.Bind(ipep);
            server.Listen(10);

            Console.WriteLine(dateTime+"[Msg] Server Start...");
            Console.WriteLine(dateTime+"[Msg] Port number : "+port_number);

            Socket client = server.Accept();
            IPEndPoint ip = (IPEndPoint)client.RemoteEndPoint;
            Console.WriteLine(dateTime + "[Connect] Connect by " + ip.Address);

            String buf_str = "Connect Server Success!";
            Byte[] buf = Encoding.UTF8.GetBytes(buf_str);
            client.Send(buf);
            Byte[] rec_buf = new Byte[1024];
            client.Receive(rec_buf);
            String rec_str = Encoding.Default.GetString(rec_buf);
            Console.WriteLine(dateTime + "[recieve] " + rec_str);

            client.Close();
            server.Close();
        }
    }

}
