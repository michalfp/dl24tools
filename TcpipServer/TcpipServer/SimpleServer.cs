using System;
using System.Collections.Generic;
using System.Text;

namespace TcpipServer
{
    using System.Net;
    using System.Net.Sockets;

    public class SimpleServer
    {
        TcpListener tcpListener;

        private Socket socket;

        public SimpleServer(string ip, int port, bool startNow = true)
        {
            this.tcpListener = new TcpListener(IPAddress.Parse(ip), port);

            if (startNow)
            {
                this.StartServer();
            }
        }

        public void StartServer()
        {
            this.tcpListener.Start();
            this.socket = this.tcpListener.AcceptSocket();
        }

        public void StopServer()
        {
            this.socket.Close();
            this.tcpListener.Stop();
        }

        public string Receive(int bufferSize = 1024)
        {
            var buffer = new byte[bufferSize];
            var messageLength = this.socket.Receive(buffer);

            var output = new StringBuilder();

            for (var i = 0; i < messageLength; i++)
            {
                output.Append(Convert.ToChar(buffer[i]));
            }

            return output.ToString();

        }

        public void Send(string message)
        {
            var encodedMessage = new ASCIIEncoding().GetBytes(message);
            this.socket.Send(encodedMessage);
        }
    }
}
