using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace A2_Project.Launcher
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private bool ValidUsername()
        {
            // NOTHING THERE?
            if (UsernameBox.Text.Length == 0)
            {
                MessageBox.Show("Please Enter a valid Username!");
                return false;
            }
            // REGEX
            Regex regex = new Regex("[A-z+1-9+_-]{4,12}"); // Any upper/lowercase letter, digit, underscore or hyphen, 4-12 chars long
            if (!regex.IsMatch(UsernameBox.Text))
            {
                MessageBox.Show("Usernames must only contain alphanumeric characters with the exception of underscores and hyphens");
                return false;
            }
            // IS TAKEN?
            string sql = "Select * FROM Users WHERE Username = '" + UsernameBox.Text + "'";
            DataSet d = AccessHelper.ExecuteDataSet(sql, "Users");
            if (d.Tables["Users"].Rows.Count != 0)
            {
                MessageBox.Show(this, "This Username is taken!");
                return false;
            }
            // MEETS ALL CONDITIONS
            return true;
        }
        private bool ValidPassword()
        {
            // Nothing THERE
            if (Password1Box.Text.Length == 0 || Password2Box.Text.Length == 0)
            {
                MessageBox.Show("Please enter a password.");
                return false;
            }
            // PASSWORDS MATCH
            if (Password1Box.Text != Password2Box.Text)
            {
                MessageBox.Show("The passwords do not match, try again.");
                return false;
            }
            // REGEX
            Regex regex = new Regex("([^;@\"]{6,24})");
            if (!regex.IsMatch(Password1Box.Text))
            {
                MessageBox.Show("Invalid Password! Passwords must be between 6 and 24 characters long and cannot contain semi-colons or quotation marks.");
                return false;
            }


            return true;
        }
        private bool ValidEmail()
        {
            // NOTHING THERE
            if (Email1Box.Text.Length == 0 || Email2Box.Text.Length == 0)
            {
                MessageBox.Show("Please Enter a valid Email!");
                return false;
            }
            // EMAILS MATCH
            if (Email1Box.Text != Email2Box.Text)
            {
                MessageBox.Show("Emails do not match!");
                return false;
            }
            // REGEX BEFORE SQL BECAUSE SAVES PROCESSING TIME
            Regex regex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            if (!regex.IsMatch(Email1Box.Text))
            {
                MessageBox.Show("Please Enter a valid Email!");
                return false;
            }
            // EMAIL TAKEN
            string sql = "Select UserID FROM Users WHERE Email = '" + Email1Box.Text + "'";
            DataSet d = AccessHelper.ExecuteDataSet(sql, "Users");
            if (d.Tables["Users"].Rows.Count != 0)
            {
                MessageBox.Show("This Email is unavailable!");
                return false;
            }
            // MEETS ALL CONDITIONS!
            return true;
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (ValidUsername() && ValidPassword() && ValidEmail())
            {
                string HashedPass = AccessHelper.HashPassword(Password1Box.Text);
                string sql = "INSERT INTO Users (Username, PassHash, Email) VALUES ('" + UsernameBox.Text + "', '"
                            + HashedPass + "', '" + Email1Box.Text + "');";
                AccessHelper.ExecuteNonQuery(sql);
                MessageBox.Show("You have successfully registered, feel free to log in!");
                this.Close();
               
            }
        }
        
    }
}