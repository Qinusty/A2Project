namespace A2_Project.Launcher
{
    partial class LoginForm
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
            this.RegisterBTN = new System.Windows.Forms.Button();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ClrPckBtn = new System.Windows.Forms.Button();
            this.HighScoreBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RegisterBTN
            // 
            this.RegisterBTN.Location = new System.Drawing.Point(247, 102);
            this.RegisterBTN.Name = "RegisterBTN";
            this.RegisterBTN.Size = new System.Drawing.Size(85, 30);
            this.RegisterBTN.TabIndex = 0;
            this.RegisterBTN.Text = "Register";
            this.RegisterBTN.UseVisualStyleBackColor = true;
            this.RegisterBTN.Click += new System.EventHandler(this.RegisterBTN_Click);
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Location = new System.Drawing.Point(41, 35);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(91, 20);
            this.UsernameLbl.TabIndex = 4;
            this.UsernameLbl.Text = "Username: ";
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Location = new System.Drawing.Point(41, 73);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(86, 20);
            this.PasswordLbl.TabIndex = 5;
            this.PasswordLbl.Text = "Password: ";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(138, 35);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(194, 26);
            this.UsernameBox.TabIndex = 6;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(138, 70);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(194, 26);
            this.PasswordBox.TabIndex = 7;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Location = new System.Drawing.Point(138, 102);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(103, 30);
            this.LoginBtn.TabIndex = 8;
            this.LoginBtn.Text = "Log In";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClrPckBtn
            // 
            this.ClrPckBtn.Location = new System.Drawing.Point(0, 160);
            this.ClrPckBtn.Name = "ClrPckBtn";
            this.ClrPckBtn.Size = new System.Drawing.Size(127, 34);
            this.ClrPckBtn.TabIndex = 10;
            this.ClrPckBtn.Text = "Ship Colour";
            this.ClrPckBtn.UseVisualStyleBackColor = true;
            this.ClrPckBtn.Click += new System.EventHandler(this.ClrPckBtn_Click);
            // 
            // HighScoreBTN
            // 
            this.HighScoreBTN.Location = new System.Drawing.Point(259, 160);
            this.HighScoreBTN.Name = "HighScoreBTN";
            this.HighScoreBTN.Size = new System.Drawing.Size(127, 34);
            this.HighScoreBTN.TabIndex = 11;
            this.HighScoreBTN.Text = "Highscores";
            this.HighScoreBTN.UseVisualStyleBackColor = true;
            this.HighScoreBTN.Click += new System.EventHandler(this.HighScoreBTN_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.LoginBtn;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(385, 195);
            this.Controls.Add(this.HighScoreBTN);
            this.Controls.Add(this.ClrPckBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.UsernameLbl);
            this.Controls.Add(this.RegisterBTN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RegisterBTN;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ClrPckBtn;
        private System.Windows.Forms.Button HighScoreBTN;
    }
}