using Microsoft.Xna.Framework;
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
        public static Texture2D Asteroids, ExplosionFrames;
        public static Texture2D SinglePixel;
        public static void Load(ContentManager content, GraphicsDevice gDev)
        {
            Fuel_Barrel = content.Load<Texture2D>("Textures/FuelBarrel");
            StarterShip = content.Load<Texture2D>("Textures/Ship2");
            Star = content.Load<Texture2D>("Textures/Star");
            ExplosionFrames = content.Load<Texture2D>("Textures/Explosions");
            SinglePixel = new Texture2D(gDev, 1, 1);
            SinglePixel.SetData(new[] { Color.White });

        }
        #region "Bibliography"
        // http://commondatastorage.googleapis.com/codeskulptor-assets/explosion.hasgraphics.png
        #endregion

    }
}
