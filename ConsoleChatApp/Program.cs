using ConsoleChatApp.Net;

namespace ConsoleChatApp
{
    public class Program
    {
        static void Main()
        {
            Server server1 = new Server();

            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            server1.ConnectToServer(username);

            server1.connectedEvent += () =>
            {
                string newUser = server1.PacketReader.ReadMessage();
                Console.WriteLine($"{newUser} has joined the chat.");
            };

            server1.msgReceivedEvent += () =>
            {
                string message = server1.PacketReader.ReadMessage();
                Console.WriteLine($"{message}");
            };

            server1.userDisconnectEvent += () =>
            {
                string disconnectedUser = server1.PacketReader.ReadMessage();
            };

            while (true)
            {
                string msg = Console.ReadLine();

                if (msg.ToLower() == "exit")
                    break;

                server1.SendMessageToServer(msg);
            }
        }
    }
}
