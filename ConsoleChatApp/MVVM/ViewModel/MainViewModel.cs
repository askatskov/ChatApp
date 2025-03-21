using ConsoleChatApp.MVVM.Model;
using ConsoleChatApp.Net;
using System.Collections.ObjectModel;
using System.Windows;


namespace ConsoleChatApp.MVVM.ViewModel
{
    class MainViewModel
    {
        public List<UserModel> Users { get; set; }
        public List<string> Messages { get; set; }


        public string Username { get; set; }
        public string Message { get; set; }
         
        private Server _server;
        public MainViewModel()
        {
            Users = new List<UserModel>();
            Messages = new List<string>();

            _server = new Server();
            _server.connectedEvent += UserConnected;
            _server.msgReceivedEvent += MessageReceived;
            _server.userDisconnectEvent += RemoveUser;
        }

            public void ConnectToServer()
            {
                if (!string.IsNullOrEmpty(Username))
                {
                    _server.ConnectToServer(Username);
                }
                else
                {
                    Console.WriteLine("Username cannot be empty.");
                }
            }

            public void SendMessage()
            {
                if (!string.IsNullOrEmpty(Message))
                {
                    _server.SendMessageToServer(Message);
                }
                else
                {
                    Console.WriteLine("Message cannot be empty.");
                }
            }

        private void RemoveUser()
        {
            var uid = _server.PacketReader.ReadMessage();
            var user = Users.Where(x => x.UID == uid).FirstOrDefault();
            Users.Remove(user);
        }

        private void MessageReceived()
        {
            var msg = _server.PacketReader.ReadMessage();
            Messages.Add(msg);
        }

        private void UserConnected()
        {
            var user = new UserModel
            {
                Username = _server.PacketReader.ReadMessage(),
                UID = _server.PacketReader.ReadMessage(),
            };
            if (!Users.Any( x => x.UID == user.UID))
            {
                Users.Add(user);
            }
        }
    }
}
