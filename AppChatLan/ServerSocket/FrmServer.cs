using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSocket
{
    class ClientInfo
    {
        public string Name;
        public Socket Socket;
    }

    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
        }

        Socket server;
        List<ClientInfo> clients = new List<ClientInfo>();
        NetworkStream networkStream;

        private void FrmServer_Load(object sender, EventArgs e)
        {
            StartServer();
        }

        private void StartServer()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, 9999));
            server.Listen(10);
            listBox1.Items.Add("Server đã chạy...");
            Task.Run(AcceptClients);
        }

        private void AcceptClients()
        {
            while (true)
            {
                Socket socket = server.Accept();

                ClientInfo client = new ClientInfo
                {
                    Socket = socket
                };

                clients.Add(client);

                Invoke(new Action(() =>
                {
                    listBox1.Items.Add("Client mới kết nối");
                }));

                Task.Run(() => HandleClient(client));
            }
        }

        private void HandleClient(ClientInfo client)
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                int bytes;
                try
                {
                    bytes = client.Socket.Receive(buffer);
                    if (bytes == 0) break;
                }
                catch { break; }

                string msg = Encoding.UTF8.GetString(buffer, 0, bytes);
                ProcessMessage(client, msg);
            }

            clients.Remove(client);
            client.Socket.Close();

            if (!string.IsNullOrEmpty(client.Name))
                BroadcastPublic($"*** {client.Name} đã thoát ***");
        }

        private void ProcessMessage(ClientInfo sender, string msg)
        {
            string[] parts = msg.Split('|');
            string command = parts[0];

            if (command == "LOGIN")
            {
                sender.Name = parts[1];
                BroadcastPublic($"*** {sender.Name} đã vào phòng ***");
            }
            else if (command == "PUBLIC")
            {
                BroadcastPublic($"[{sender.Name}] {parts[1]}");
            }
            else if (command == "PRIVATE")
            {
                SendPrivate(sender.Name, parts[1], parts[2]);
            }
        }

        private void BroadcastPublic(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);

            foreach (var c in clients)
            {
                try { c.Socket.Send(data); }
                catch { }
            }
        }

        private void SendPrivate(string from, string to, string msg)
        {
            var target = clients.FirstOrDefault(c => c.Name == to);
            if (target == null) return;
            string fullMsg = $"[PRIVATE] {from} → {to}: {msg}";
            byte[] data = Encoding.UTF8.GetBytes(fullMsg);
            target.Socket.Send(data);
            var sender = clients.First(c => c.Name == from);
            sender.Socket.Send(data);
        }

    }
}
