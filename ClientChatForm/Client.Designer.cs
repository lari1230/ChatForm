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
            this.SuspendLayout();
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(12, 12);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(360, 200);
            this.ChatBox.TabIndex = 0;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(12, 220);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(260, 23);
            this.MessageTextBox.TabIndex = 1;
            this.MessageTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Client_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(280, 218);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(92, 23);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Отправить";
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            this.SendButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Client_KeyDown);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 250);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(360, 23);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Подключиться";
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // Client
            // 
            this.ClientSize = new System.Drawing.Size(384, 281);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ConnectButton);
            this.Name = "Client";
            this.Text = "Чат";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Client_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}