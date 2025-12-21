using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSocket
{
    public partial class FrmClient : Form
    {
        public FrmClient()
        {
            InitializeComponent();
        }

        Socket client;
        NetworkStream networkStream;
        private void FrmClient_Load(object sender, EventArgs e)
        {

        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên trước khi kết nối.");
                return;
            }
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await client.ConnectAsync(GetIPv4(), 9999);
            networkStream = new NetworkStream(client);
            Send("LOGIN|" + txtName.Text);
            lstChat.Items.Add("Đã kết nối server.");
            _ = ReceiveMessages();
        }

        private string GetIPv4()
        {
            foreach (var ip in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "";
        }

        private async Task ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            while (true)
            {
                try
                {
                    int bytes = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytes == 0) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, bytes);

                    Invoke(new Action(() =>
                    {
                        lstChat.Items.Add(msg);
                    }));
                }
                catch
                {
                    break;
                }
            }
        }

        private void Send(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg);
            networkStream.WriteAsync(data, 0, data.Length);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() == "") return;

            Send("PUBLIC|" + txtMessage.Text);
            txtMessage.Clear();
        }

        private void btnPrivate_Click(object sender, EventArgs e)
        {
            if (txtTo.Text.Trim() == "" || txtMessage.Text.Trim() == "")
                return;

            Send($"PRIVATE|{txtTo.Text}|{txtMessage.Text}");
            txtMessage.Clear();
        }

    }
}
