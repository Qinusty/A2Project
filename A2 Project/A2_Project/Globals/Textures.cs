using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Globals
{
    public static class Textures
    {
        public static Texture2D StarterShip, Star;
        public static Texture2D[] Asteroids, ExplosionFrames;

        public static void Load(ContentManager content)
        {
            StarterShip = content.Load<Texture2D>("Textures/Ship2");
            Star = content.Load<Texture2D>("Textures/Star");
        }

    }
}
