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

            while (true)
            {
                Console.Write("Enter Message: ");
                string msg = Console.ReadLine();

                if (msg.ToLower() == "exit")
                    break;

                server1.SendMessageToServer(msg);
            }

            Console.WriteLine("Disconnected from server.");
        }
    }
}