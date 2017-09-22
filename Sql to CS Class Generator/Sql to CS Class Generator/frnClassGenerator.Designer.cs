namespace Sql_to_CS_Class_Generator
{
    partial class frnClassGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlInput = new System.Windows.Forms.Panel();
            this.gbConnection = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.gbSql = new System.Windows.Forms.GroupBox();
            this.pnlSql = new System.Windows.Forms.Panel();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.lblGenerateTo = new System.Windows.Forms.Label();
            this.rbGenerateToNewWindow = new System.Windows.Forms.RadioButton();
            this.rbGenerateToFile = new System.Windows.Forms.RadioButton();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.rbGenerateToClipboard = new System.Windows.Forms.RadioButton();
            this.pnlInput.SuspendLayout();
            this.gbConnection.SuspendLayout();
            this.gbSql.SuspendLayout();
            this.pnlSql.SuspendLayout();
            this.pnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.gbSql);
            this.pnlInput.Controls.Add(this.gbConnection);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInput.Location = new System.Drawing.Point(0, 0);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(582, 138);
            this.pnlInput.TabIndex = 2;
            // 
            // gbConnection
            // 
            this.gbConnection.Controls.Add(this.txtPassword);
            this.gbConnection.Controls.Add(this.lblServer);
            this.gbConnection.Controls.Add(this.txtUsername);
            this.gbConnection.Controls.Add(this.lblDatabase);
            this.gbConnection.Controls.Add(this.txtDatabase);
            this.gbConnection.Controls.Add(this.lblUsername);
            this.gbConnection.Controls.Add(this.txtServer);
            this.gbConnection.Controls.Add(this.lblPassword);
            this.gbConnection.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbConnection.Location = new System.Drawing.Point(0, 0);
            this.gbConnection.Name = "gbConnection";
            this.gbConnection.Size = new System.Drawing.Size(347, 138);
            this.gbConnection.TabIndex = 2;
            this.gbConnection.TabStop = false;
            this.gbConnection.Text = "Connection";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 100);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(260, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(31, 25);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(38, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(75, 74);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(260, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(16, 51);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(53, 13);
            this.lblDatabase.TabIndex = 0;
            this.lblDatabase.Text = "Database";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(75, 48);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(260, 20);
            this.txtDatabase.TabIndex = 2;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(14, 77);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(75, 22);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(260, 20);
            this.txtServer.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 103);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password";
            // 
            // gbSql
            // 
            this.gbSql.Controls.Add(this.rbGenerateToClipboard);
            this.gbSql.Controls.Add(this.rbGenerateToFile);
            this.gbSql.Controls.Add(this.rbGenerateToNewWindow);
            this.gbSql.Controls.Add(this.lblGenerateTo);
            this.gbSql.Controls.Add(this.lblClassName);
            this.gbSql.Controls.Add(this.txtClassName);
            this.gbSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSql.Location = new System.Drawing.Point(347, 0);
            this.gbSql.Name = "gbSql";
            this.gbSql.Size = new System.Drawing.Size(235, 138);
            this.gbSql.TabIndex = 3;
            this.gbSql.TabStop = false;
            this.gbSql.Text = "Sql to C#";
            // 
            // pnlSql
            // 
            this.pnlSql.Controls.Add(this.txtSql);
            this.pnlSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSql.Location = new System.Drawing.Point(0, 138);
            this.pnlSql.Name = "pnlSql";
            this.pnlSql.Size = new System.Drawing.Size(582, 492);
            this.pnlSql.TabIndex = 3;
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(75, 22);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(241, 20);
            this.txtClassName.TabIndex = 5;
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Location = new System.Drawing.Point(6, 25);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(63, 13);
            this.lblClassName.TabIndex = 0;
            this.lblClassName.Text = "Class Name";
            // 
            // txtSql
            // 
            this.txtSql.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSql.Location = new System.Drawing.Point(0, 0);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(582, 492);
            this.txtSql.TabIndex = 7;
            // 
            // lblGenerateTo
            // 
            this.lblGenerateTo.AutoSize = true;
            this.lblGenerateTo.Location = new System.Drawing.Point(1, 51);
            this.lblGenerateTo.Name = "lblGenerateTo";
            this.lblGenerateTo.Size = new System.Drawing.Size(67, 13);
            this.lblGenerateTo.TabIndex = 0;
            this.lblGenerateTo.Text = "Generate To";
            // 
            // rbGenerateToNewWindow
            // 
            this.rbGenerateToNewWindow.AutoSize = true;
            this.rbGenerateToNewWindow.Checked = true;
            this.rbGenerateToNewWindow.Location = new System.Drawing.Point(75, 49);
            this.rbGenerateToNewWindow.Name = "rbGenerateToNewWindow";
            this.rbGenerateToNewWindow.Size = new System.Drawing.Size(89, 17);
            this.rbGenerateToNewWindow.TabIndex = 6;
            this.rbGenerateToNewWindow.Text = "New Window";
            this.rbGenerateToNewWindow.UseVisualStyleBackColor = true;
            // 
            // rbGenerateToFile
            // 
            this.rbGenerateToFile.AutoSize = true;
            this.rbGenerateToFile.Location = new System.Drawing.Point(75, 72);
            this.rbGenerateToFile.Name = "rbGenerateToFile";
            this.rbGenerateToFile.Size = new System.Drawing.Size(41, 17);
            this.rbGenerateToFile.TabIndex = 6;
            this.rbGenerateToFile.Text = "File";
            this.rbGenerateToFile.UseVisualStyleBackColor = true;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnGenerate);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(0, 597);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(582, 33);
            this.pnlButton.TabIndex = 4;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerate.Location = new System.Drawing.Point(0, 0);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(582, 33);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // rbGenerateToClipboard
            // 
            this.rbGenerateToClipboard.AutoSize = true;
            this.rbGenerateToClipboard.Location = new System.Drawing.Point(75, 95);
            this.rbGenerateToClipboard.Name = "rbGenerateToClipboard";
            this.rbGenerateToClipboard.Size = new System.Drawing.Size(69, 17);
            this.rbGenerateToClipboard.TabIndex = 6;
            this.rbGenerateToClipboard.Text = "Clipboard";
            this.rbGenerateToClipboard.UseVisualStyleBackColor = true;
            // 
            // frnClassGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 630);
            this.Controls.Add(this.pnlButton);
            this.Controls.Add(this.pnlSql);
            this.Controls.Add(this.pnlInput);
            this.Name = "frnClassGenerator";
            this.Text = "C# Class Generator";
            this.pnlInput.ResumeLayout(false);
            this.gbConnection.ResumeLayout(false);
            this.gbConnection.PerformLayout();
            this.gbSql.ResumeLayout(false);
            this.gbSql.PerformLayout();
            this.pnlSql.ResumeLayout(false);
            this.pnlSql.PerformLayout();
            this.pnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.GroupBox gbConnection;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.GroupBox gbSql;
        private System.Windows.Forms.Panel pnlSql;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Label lblGenerateTo;
        private System.Windows.Forms.RadioButton rbGenerateToNewWindow;
        private System.Windows.Forms.RadioButton rbGenerateToFile;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RadioButton rbGenerateToClipboard;

    }
}

