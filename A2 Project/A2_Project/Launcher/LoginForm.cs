﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace A2_Project.Launcher
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void RegisterBTN_Click(object sender, EventArgs e)
        {
            using (Register rForm = new Register())
            {
                rForm.ShowDialog();
            }

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // perform database check
            string HashedPass = AccessHelper.HashPassword(PasswordBox.Text);
            string sql = "Select UserID FROM Users WHERE Username = '" + UsernameBox.Text + "' AND PassHash = '" + HashedPass + "'";
            DataSet ds = AccessHelper.ExecuteDataSet(sql, "Users");
            if (ds.Tables["Users"].Rows.Count == 0)
            {
                MessageBox.Show("Incorrect Username or password, try again.");
            }
            else
            {
                MessageBox.Show("You have successfully logged in!");
                Program._user = new User(UsernameBox.Text, HashedPass);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program._user = new User("Bypass", "BYPASSED");
            this.Close();
        }
    }
}
