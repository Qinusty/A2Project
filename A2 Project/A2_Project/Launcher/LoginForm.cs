using System;
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
            ClrPckBtn.BackColor = Color.LawnGreen;
            
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
                MessageBox.Show(this, "Incorrect Username or password, try again.");
            }
            else
            {
                MessageBox.Show("You have successfully logged in!");
                Program._user = new User(UsernameBox.Text, HashedPass);
                this.Close();
            }
            Globals.Textures.ShipColor = new Microsoft.Xna.Framework.Color(ClrPckBtn.BackColor.R,
                ClrPckBtn.BackColor.G, ClrPckBtn.BackColor.B, ClrPckBtn.BackColor.A);
        }
        // Debug button disabled by default
        private void button1_Click(object sender, EventArgs e)
        {
            Program._user = new User("Bypass", "BYPASSED");
            this.Close();
        }

        private void ClrPckBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colDialog = new ColorDialog();
            colDialog.AnyColor = true;
            colDialog.ShowDialog();
            if (ClrPckBtn.BackColor == Color.Black || ClrPckBtn.BackColor == Color.DarkGray)
                ClrPckBtn.BackColor = Color.LawnGreen;
            else ClrPckBtn.BackColor = colDialog.Color;
            Globals.Textures.ShipColor = new Microsoft.Xna.Framework.Color(colDialog.Color.R, 
                colDialog.Color.G, colDialog.Color.B, colDialog.Color.A);
        }

        private void HighScoreBTN_Click(object sender, EventArgs e)
        {
            HighscoreForm form = new HighscoreForm();
            form.ShowDialog();
        }
    }
}
