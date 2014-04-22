using System;
using System.Collections.Generic;
using System.Text;

namespace TcpipClient
{
    class Program
    {
        public static void Main()
        {

            var client = new SimpleClient("127.0.0.1", 8001);

            while (true)
            {
                // Input
                Console.Write("Enter number: ");
                var input = Console.ReadLine();
                client.Send(input);

                // Output
                var answer = client.Receive();
                Console.WriteLine("Calculated: " + answer);
            }
        }
    }
}
