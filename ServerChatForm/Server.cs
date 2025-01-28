namespace ServerChatForm
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public partial class Server : Form
    {
        private TcpListener _listener;
        private List<TcpClient> _clients = new List<TcpClient>();
        private List<string> _bannedWords = new List<string> { "badword1", "badword2" }; // ����������� �����
        private bool _isRunning;

        public Server()
        {
            InitializeComponent();
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, 8888);
                _listener.Start();
                _isRunning = true;

                Thread listenThread = new Thread(ListenForClients);
                listenThread.Start();

                AppendLog("������ �������.");
                StartServerButton.Enabled = false;
            }
            catch (Exception ex)
            {
                AppendLog($"������ ������� �������: {ex.Message}");
            }
        }

        private void ListenForClients()
        {
            while (_isRunning)
            {
                try
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    _clients.Add(client);

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();

                    AppendLog("����� ������ ���������.");
                }
                catch (Exception ex)
                {
                    AppendLog($"������ ������ �������: {ex.Message}");
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int byteCount;

            try
            {
                while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    AppendLog($"��������� �� �������: {message}");

                    // ��������� ���������
                    foreach (var word in _bannedWords)
                    {
                        if (message.Contains(word))
                        {
                            message = "[��������� ������������� �����������]";
                            AppendLog("���������: ����������� ����� ���� ����������.");
                            break;
                        }
                    }

                    BroadcastMessage(message, client);
                }
            }
            catch (Exception ex)
            {
                AppendLog($"������ ��������� �������: {ex.Message}");
            }
            finally
            {
                _clients.Remove(client);
                AppendLog("������ ����������.");
            }
        }

        private void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            foreach (var client in _clients)
            {
                if (client != sender)
                {
                    try
                    {
                        NetworkStream stream = client.GetStream();
                        stream.Write(buffer, 0, buffer.Length);
                    }
                    catch
                    {
                        AppendLog("������ �������� ��������� �������.");
                    }
                }
            }
        }

        private void AppendLog(string message)
        {
            if (LogBox.InvokeRequired)
            {
                LogBox.Invoke(new Action<string>(AppendLog), message);
            }
            else
            {
                LogBox.AppendText(message + Environment.NewLine);
            }
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            _isRunning = false;
            _listener?.Stop();
            AppendLog("������ ����������.");
            StartServerButton.Enabled = true;
        }
    }

}
