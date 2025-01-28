namespace ServerChatForm
{
    partial class Server
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Button StartServerButton;
        private System.Windows.Forms.Button StopServerButton;

        private void InitializeComponent()
        {
            this.LogBox = new System.Windows.Forms.TextBox();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.StopServerButton = new System.Windows.Forms.Button();

            // LogBox
            this.LogBox.Multiline = true;
            this.LogBox.Location = new System.Drawing.Point(12, 12);
            this.LogBox.Size = new System.Drawing.Size(460, 300);
            this.LogBox.ReadOnly = true;

            // StartServerButton
            this.StartServerButton.Location = new System.Drawing.Point(12, 320);
            this.StartServerButton.Size = new System.Drawing.Size(200, 30);
            this.StartServerButton.Text = "Запустить сервер";
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);

            // StopServerButton
            this.StopServerButton.Location = new System.Drawing.Point(272, 320);
            this.StopServerButton.Size = new System.Drawing.Size(200, 30);
            this.StopServerButton.Text = "Остановить сервер";
            this.StopServerButton.Click += new System.EventHandler(this.StopServerButton_Click);

            // ServerForm
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.StartServerButton);
            this.Controls.Add(this.StopServerButton);
            this.Text = "Сервер Чата";
        }
    }

}
