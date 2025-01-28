namespace ClientChatForm
{
    partial class Client
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button ConnectButton;

        private void InitializeComponent()
        {
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();

            // ChatBox
            this.ChatBox.Multiline = true;
            this.ChatBox.Location = new System.Drawing.Point(12, 12);
            this.ChatBox.Size = new System.Drawing.Size(360, 200);
            this.ChatBox.ReadOnly = true;

            // MessageTextBox
            this.MessageTextBox.Location = new System.Drawing.Point(12, 220);
            this.MessageTextBox.Size = new System.Drawing.Size(260, 20);

            // SendButton
            this.SendButton.Location = new System.Drawing.Point(280, 218);
            this.SendButton.Size = new System.Drawing.Size(92, 23);
            this.SendButton.Text = "Отправить";
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);

            // ConnectButton
            this.ConnectButton.Location = new System.Drawing.Point(12, 250);
            this.ConnectButton.Size = new System.Drawing.Size(360, 23);
            this.ConnectButton.Text = "Подключиться";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);

            // ClientForm
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ConnectButton);
            this.Text = "Чат";
        }
    }

}
