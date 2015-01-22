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
        public static Texture2D StarterShip, Star, Fuel_Barrel;
        public static Texture2D[] Asteroids, ExplosionFrames;

        public static void Load(ContentManager content)
        {
            Fuel_Barrel = content.Load<Texture2D>("Textures/FuelBarrel");
            StarterShip = content.Load<Texture2D>("Textures/Ship2");
            Star = content.Load<Texture2D>("Textures/Star");
        }

    }
}
