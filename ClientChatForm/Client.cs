using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace ClientChatForm
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;

        public Client()
        {
            InitializeComponent();
            
        }
        //подключение к серверу
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient("127.0.0.1", 8888);
                stream = client.GetStream();

                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.Start();

                MessageBox.Show("Подключение успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}");
            }
        }
        private void Client_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) SendMessage();
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        //отправка сообщений
        private void SendMessage()
        {
            string message = MessageTextBox.Text;
            if (!string.IsNullOrEmpty(message))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                stream.Write(buffer, 0, buffer.Length);
                MessageTextBox.Clear();
            }
        }
        // принятие сообщений
        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            int byteCount;

            try
            {
                while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    AppendMessage(message);
                }
            }
            catch
            {
                AppendMessage("Соединение с сервером разорвано.");
            }
        }
        //вывод сообщений в чат
        private void AppendMessage(string message)
        {
            if (ChatBox.InvokeRequired)
            {
                ChatBox.Invoke(new Action<string>(AppendMessage), message);
            }
            else
            {
                ChatBox.AppendText(message + Environment.NewLine);
            }
        }

        
    }
}