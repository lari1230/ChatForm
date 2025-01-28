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
        private TcpListener listener;
        private List<TcpClient> clients = new List<TcpClient>();
        private List<string> bannedWords = new List<string> { "хуй", "даун", "негр" }; // запрещенные слова
        private bool isRunning;

        public Server()
        {
            InitializeComponent();
        }
        //запуск сервера
        private void StartServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, 8888);
                listener.Start();
                isRunning = true;

                Thread listenThread = new Thread(ListenForClients);
                listenThread.Start();

                AppendLog("Сервер запущен.");
                StartServerButton.Enabled = false;
            }
            catch (Exception ex)
            {
                AppendLog($"Ошибка запуска сервера: {ex.Message}");
            }
        }
        //подключает клиента
        private void ListenForClients()
        {
            while (isRunning)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    clients.Add(client);

                    Thread clientThread = new Thread(() => HandleClient(client));
                    clientThread.Start();

                    AppendLog("Новый клиент подключен.");
                }
                catch (Exception ex)
                {
                    AppendLog($"Ошибка приема клиента: {ex.Message}");
                }
            }
        }
        //принимает сообщения
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
                    AppendLog($"Сообщение от клиента: {message}");

                    // Модерация сообщений
                    foreach (var word in bannedWords)
                    {
                        if (message.Contains(word))
                        {
                            message = "[Сообщение заблокировано модератором]";
                            AppendLog("Модерация: запрещенное слово было обнаружено.");
                            break;
                        }
                    }

                    BroadcastMessage(message, client);
                }
            }
            catch (Exception ex)
            {
                AppendLog($"Ошибка обработки клиента: {ex.Message}");
            }
            finally
            {
                clients.Remove(client);
                AppendLog("Клиент отключился.");
            }
        }
        // проверка отправки
        private void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);

            foreach (var client in clients)
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
                        AppendLog("Ошибка отправки сообщения клиенту.");
                    }
                }
            }
        }
        // показ всех логов
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
        //стоп сервера
        private void StopServerButton_Click(object sender, EventArgs e)
        {
            isRunning = false;
            listener?.Stop();
            AppendLog("Сервер остановлен.");
            StartServerButton.Enabled = true;
        }


    }

}
