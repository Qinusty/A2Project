using System;
using A2_Project.Launcher;
using System.Threading;
using System.Windows.Forms;
using A2_Project.LinkedLists;
using A2_Project.Inventory;
using A2_Project.Inventory.Items;
namespace A2_Project
{
#if WINDOWS || XBOX
    static class Program
    {
        public static User _user;
        static LoginForm form = new LoginForm();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //TEST AREA
            
            //END OF TEST AREA

            form.ShowDialog();
            if (_user != null)
            {
                using (Game1 game = new Game1())
                {
                    game.Run();
                }
            }
        }
    }
#endif
    public class User
    {
        public string Username {get; private set;}
        public string PassHash{get;private set;}
        public User(string _username, string _pass)
        {
            Username = _username;
            PassHash = _pass;
        }
    }
}

