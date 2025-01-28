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
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 12);
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(460, 300);
            this.LogBox.TabIndex = 0;
            // 
            // StartServerButton
            // 
            this.StartServerButton.Location = new System.Drawing.Point(12, 320);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(200, 30);
            this.StartServerButton.TabIndex = 1;
            this.StartServerButton.Text = "Запустить сервер";
            this.StartServerButton.Click += new System.EventHandler(this.StartServerButton_Click);
            // 
            // StopServerButton
            // 
            this.StopServerButton.Location = new System.Drawing.Point(272, 320);
            this.StopServerButton.Name = "StopServerButton";
            this.StopServerButton.Size = new System.Drawing.Size(200, 30);
            this.StopServerButton.TabIndex = 2;
            this.StopServerButton.Text = "Остановить сервер";
            this.StopServerButton.Click += new System.EventHandler(this.StopServerButton_Click);
            // 
            // Server
            // 
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.StartServerButton);
            this.Controls.Add(this.StopServerButton);
            this.Name = "Server";
            this.Text = "Сервер Чата";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StopServerButton_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}
