using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppChatLan
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
        }

        Socket server;
        List<Socket> clients = new List<Socket>();

        private void frmServer_Load(object sender, EventArgs e)
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
                Socket client = server.Accept();
                clients.Add(client);
                Invoke(new Action(() => { listBox1.Items.Add("Client mới kết nối"); }));
                Task.Run(() => HandleClient(client));
            }
        }

        void HandleClient(Socket client)
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                int bytes = client.Receive(buffer);
                if (bytes == 0) break;
                string msg = Encoding.UTF8.GetString(buffer, 0, bytes);
                Broadcast(msg);
            }
            clients.Remove(client);
            client.Close();
        }

        void Broadcast(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);

            foreach (var c in clients)
            {
                try
                {
                    c.Send(data);
                }
                catch { }
            }
        }

    }
}
