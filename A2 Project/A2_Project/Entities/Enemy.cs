using A2_Project.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Entities
{
    public class Enemy : Ship
    {
        private Ship Target;

        public Enemy(Vector2 StartPos, Ship target)
        {
            Target = target;
            Image = Textures.StarterShip;
            Location = StartPos;
            Mass = 100;
            DrawRectangle = new Rectangle((int)Location.X, (int)Location.Y, Image.Width, Image.Height);
            isAlive = true;
        }
        public override void Update(GameTime gt)
        {
            DrawRectangle = new Rectangle((int)Location.X, (int)Location.Y, Image.Width, Image.Height);
            //Thrust = 10000;
            Move(gt);
            base.Update(gt);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, DrawRectangle, new Rectangle(0,0,Image.Width,Image.Height), Color.Red,
                Orientation, Size / 2f, SpriteEffects.None, 0);
            base.Draw(spriteBatch);
        }
        
    }
}
