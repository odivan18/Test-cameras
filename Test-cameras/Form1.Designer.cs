
namespace Test_cameras
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginLable = new System.Windows.Forms.Label();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passworTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.serverInfoLabel = new System.Windows.Forms.Label();
            this.cancelConnectButton = new System.Windows.Forms.Button();
            this.connectionInfoLabel = new System.Windows.Forms.Label();
            this.cameraListDataGridView = new System.Windows.Forms.DataGridView();
            this.cameraID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCameraName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cameraListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLable
            // 
            this.loginLable.AutoSize = true;
            this.loginLable.Location = new System.Drawing.Point(15, 42);
            this.loginLable.Name = "loginLable";
            this.loginLable.Size = new System.Drawing.Size(41, 15);
            this.loginLable.TabIndex = 0;
            this.loginLable.Text = "Логин";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(15, 60);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(255, 23);
            this.loginTextBox.TabIndex = 1;
            // 
            // passworTextBox
            // 
            this.passworTextBox.Location = new System.Drawing.Point(14, 108);
            this.passworTextBox.Name = "passworTextBox";
            this.passworTextBox.PasswordChar = '*';
            this.passworTextBox.Size = new System.Drawing.Size(256, 23);
            this.passworTextBox.TabIndex = 2;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(15, 90);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(49, 15);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Пароль";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(14, 156);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(111, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // serverInfoLabel
            // 
            this.serverInfoLabel.AutoSize = true;
            this.serverInfoLabel.Location = new System.Drawing.Point(15, 10);
            this.serverInfoLabel.Name = "serverInfoLabel";
            this.serverInfoLabel.Size = new System.Drawing.Size(0, 15);
            this.serverInfoLabel.TabIndex = 5;
            // 
            // cancelConnectButton
            // 
            this.cancelConnectButton.Location = new System.Drawing.Point(195, 156);
            this.cancelConnectButton.Name = "cancelConnectButton";
            this.cancelConnectButton.Size = new System.Drawing.Size(75, 23);
            this.cancelConnectButton.TabIndex = 6;
            this.cancelConnectButton.Text = "Отмена";
            this.cancelConnectButton.UseVisualStyleBackColor = true;
            this.cancelConnectButton.Click += new System.EventHandler(this.cancelConnectButton_Click);
            // 
            // connectionInfoLabel
            // 
            this.connectionInfoLabel.AutoSize = true;
            this.connectionInfoLabel.Location = new System.Drawing.Point(15, 138);
            this.connectionInfoLabel.Name = "connectionInfoLabel";
            this.connectionInfoLabel.Size = new System.Drawing.Size(0, 15);
            this.connectionInfoLabel.TabIndex = 7;
            // 
            // cameraListDataGridView
            // 
            this.cameraListDataGridView.AllowUserToAddRows = false;
            this.cameraListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cameraListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cameraID,
            this.columnCameraName});
            this.cameraListDataGridView.Location = new System.Drawing.Point(276, 12);
            this.cameraListDataGridView.Name = "cameraListDataGridView";
            this.cameraListDataGridView.RowTemplate.Height = 25;
            this.cameraListDataGridView.Size = new System.Drawing.Size(450, 169);
            this.cameraListDataGridView.TabIndex = 8;
            // 
            // cameraID
            // 
            this.cameraID.HeaderText = "ID";
            this.cameraID.Name = "cameraID";
            this.cameraID.Width = 250;
            // 
            // columnCameraName
            // 
            this.columnCameraName.HeaderText = "Имя камеры";
            this.columnCameraName.Name = "columnCameraName";
            this.columnCameraName.Width = 157;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 194);
            this.Controls.Add(this.cameraListDataGridView);
            this.Controls.Add(this.connectionInfoLabel);
            this.Controls.Add(this.cancelConnectButton);
            this.Controls.Add(this.serverInfoLabel);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passworTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.loginLable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.cameraListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLable;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passworTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label serverInfoLabel;
        private System.Windows.Forms.Button cancelConnectButton;
        private System.Windows.Forms.Label connectionInfoLabel;
        private System.Windows.Forms.DataGridView cameraListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn cameraID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCameraName;
    }
}

