namespace TcpipServer
{
    internal class Program
    {
        public static void Main()
        {
            var server = new SimpleServer("127.0.0.1", 8001);

            while (true)
            {
                var message = server.Receive();

                int number;
                if (int.TryParse(message, out number))
                {
                    server.Send((number * number).ToString());
                }
                else
                {
                    server.Send("NaN");
                }
            }
        }
    }
}