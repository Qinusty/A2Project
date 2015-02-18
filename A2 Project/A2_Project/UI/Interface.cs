using A2_Project.Entities;
using A2_Project.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace A2_Project.UI
{
    public class Interface
    {
        private Bar HealthBar;
        private Bar ShieldBar;
        private EntityManager eM;
        private Stopwatch stopWatch;
        public Interface(EntityManager entityManager)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            eM = entityManager;
            HealthBar = new Bar(Color.Red, Color.White, new Vector2(250,20),
                new Vector2(10, 40), eM.getPlayer().MaxHealth, BarType.LeftToRight);
            ShieldBar = new Bar(Color.Cyan, Color.White, new Vector2(250, 20),
                new Vector2(10, 70), eM.getPlayer().MaxShield, BarType.LeftToRight);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Begin();
            HealthBar.Draw(sb, eM.getPlayer().Health);
            ShieldBar.Draw(sb, eM.getPlayer().Shield);
            if ( Program._user.Highscores.Length != 0) // check that there is some highscores first
            {
                sb.DrawString(Fonts.DebugFont, "Highscore: " + Program._user.Highscores.Max(), new Vector2(10, 120), Color.Red);
            }
            sb.DrawString(Fonts.DebugFont, "Kills: " + eM.getPlayer().KillCount,
                new Vector2(10, 140), Color.Red);
            sb.DrawString(Fonts.DebugFont, "Time Played: " + stopWatch.Elapsed.Minutes + 
                ":" + stopWatch.Elapsed.Seconds, new Vector2(10, 160), Color.Red);
            sb.End();
        }

    }
}
