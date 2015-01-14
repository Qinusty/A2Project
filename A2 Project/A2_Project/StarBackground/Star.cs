using A2_Project.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Extensions;
namespace A2_Project.StarBackground
{
    public class Star
    {
        private Vector2 Location { get; set; }
        private int Brightness { get; set; }
        public Vector2 ParralaxValue { get; private set; }
        private float Scale { get; set; }
        public bool isAlive { get; private set; }
        private Texture2D Image;
        private Color col;

        public Star(Vector2 _location, int _brightness, Vector2 _parralax)
        {
            Location = _location; 
            Brightness = _brightness; 
            ParralaxValue = _parralax; 
            Scale = 0.5F/ParralaxValue.X;
            Image = Textures.Star;
        }
        public void Draw(SpriteBatch spritebatch, Camera c)
        {
 
            spritebatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,null, c.GetViewMatrix(ParralaxValue));
            spritebatch.Draw(Image, new Rectangle((int)Location.X, (int)Location.Y,
                (int)(Image.Width/Scale), (int)(Image.Height/Scale)), 
                Color.WhiteSmoke.ChangeAlpha(1));

            spritebatch.End();
        }
          
    }
}
