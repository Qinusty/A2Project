using A2_Project.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.UI
{
    public class Interface
    {
        private Bar HealthBar;
        private Bar ShieldBar;
        private EntityManager eM;
        public Interface(EntityManager entityManager)
        {
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
            sb.End();
        }

    }
}
