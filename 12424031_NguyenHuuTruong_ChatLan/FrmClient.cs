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
            byte[] nameData = Encoding.UTF8.GetBytes(txtName.Text);
            await networkStream.WriteAsync(nameData, 0, nameData.Length);
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
                    Invoke(new Action(() => { lstChat.Items.Add(msg); }));
                }
                catch
                {
                    break;
                }
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (networkStream == null) return;
            if (txtMessage.Text.Trim() == "") return;
            byte[] data = Encoding.UTF8.GetBytes(txtMessage.Text);
            await networkStream.WriteAsync(data, 0, data.Length);
            txtMessage.Clear();
        }
    }
}
