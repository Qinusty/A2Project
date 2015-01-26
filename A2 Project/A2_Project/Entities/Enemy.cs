using A2_Project.Globals;
using A2_Project.Inventory.Items;
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
        private Random r = new Random();
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
        public override void Kill()
        {
            
            base.Kill();
        }
        public void DropLoot(EntityManager eM)
        {
            int x = r.Next(1, 101); // Generate a number between 1 and 100
            if (x <= 20)
                return;
            else if (x >= 21 && x <= 50)
                eM.LootDrop(new Fuel_Barrel(), Location);
            else if (x > 50 && x <= 100)
                eM.LootDrop(new Fuel_Barrel(), Location);
        }
        public Vector2 GetCentrePoint()
        {
            return new Vector2(DrawRectangle.Center.X, DrawRectangle.Center.Y);
        }
        
    }
}
