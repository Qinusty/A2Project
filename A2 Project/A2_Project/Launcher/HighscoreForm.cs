using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace A2_Project.Launcher
{
    public partial class HighscoreForm : Form
    {
        public HighscoreForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HighscoreForm_Load(object sender, EventArgs e)
        {
            string sql = "SELECT Users.Username, Highscores.Kills, Highscores.DateOfScore FROM Users, Highscores WHERE Users.UserID = HighScores.UserID ORDER BY Highscores.Kills DESC;";
            DataSet ds = AccessHelper.ExecuteDataSet(sql, "Highscores");
            TableView.DataSource = ds.Tables[0];
            TableView.Dock = DockStyle.Fill;
        }
    }

}