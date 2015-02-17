using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace A2_Project.Launcher
{
    public class User
    {
        public string Username { get; private set; }
        public string PassHash { get; private set; }
        public int[] Highscores { get; private set; }
        public User(string _username, string _pass)
        {

            Username = _username;
            PassHash = _pass;
            Highscores = GetHighScores(_username);
        }
        public static int[] GetHighScores(string Username)
        {
            int[] retVal;
            string sql = "SELECT Kills FROM HighScores, Users WHERE Users.UserID = HighScores.UserID AND Users.Username = '"
                + Username + "';";
            DataSet ds = AccessHelper.ExecuteDataSet(sql, "Highscores");
            retVal = new int[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                retVal[i] = (int)ds.Tables[0].Rows[i][0];
            }
            return retVal;
        }
        public static string GetUserID(string _username)
        {
            string sql = "SELECT UserID FROM Users WHERE Username = '" + _username + "';";
            DataSet ds = AccessHelper.ExecuteDataSet(sql, "UserIDs");

            return ds.Tables[0].Rows[0][0].ToString();
        }
        public void AddHighScore(int Kills)
        {
            string sql = "INSERT INTO HighScores (UserID, Kills, DateOfScore) VALUES ('" + 
                GetUserID(Username) + "', '" + Kills + "', '" + DateTime.Now + "');";
            AccessHelper.ExecuteNonQuery(sql);
        }
    }
}
