using System;
using System.Collections.Generic;
using System.Text;

namespace TcpipClient
{
    using System.Net.Sockets;

    public class SimpleClient
    {
        private TcpClient tcpClient;

        private string hostname;

        private int port;

        public SimpleClient(string hostname, int port, bool connectNow = true)
        {
            this.tcpClient = new TcpClient();
            this.hostname = hostname;
            this.port = port;

            if (connectNow)
            {
                this.Connect();
            }
        }

        public void Connect()
        {
            this.tcpClient.Connect(this.hostname, this.port);
        }

        public void CloseConnection()
        {
            this.tcpClient.Close();
        }

        public void Send(string message)
        {
            var stream = this.tcpClient.GetStream();
            var encodedMessage = new ASCIIEncoding().GetBytes(message);
            stream.Write(encodedMessage, 0, encodedMessage.Length);
        }

        public string Receive(int bufferSize = 1024)
        {
            var stream = this.tcpClient.GetStream();
            var buffer = new byte[bufferSize];
            var messageLength = stream.Read(buffer, 0, bufferSize);

            var output = new StringBuilder(messageLength);
            for (var i = 0; i < messageLength; i++)
            {
                output.Append(Convert.ToChar(buffer[i]));
            }

            return output.ToString();
        }
    }
}
