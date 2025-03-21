using ConsoleChatApp.Net;

namespace ConsoleChatApp

{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Server server = new Server();
            server.ConnectToServer(username);
        }
    }
}