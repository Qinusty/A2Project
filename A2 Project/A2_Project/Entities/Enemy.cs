using A2_Project.Globals;
using A2_Project.Inventory.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Extensions;

namespace A2_Project.Entities
{
    public class Enemy : Ship
    {
        private int firingTimer;
        private Ship Target;
        private Random r = new Random();
        public Enemy(Vector2 StartPos, Ship target, EntityManager eM)
        {
            Target = target;
            Image = Textures.StarterShip;
            Location = StartPos;
            Mass = 100;
            DrawRectangle = new Rectangle((int)Location.X, (int)Location.Y, Image.Width, Image.Height);
            isAlive = true;
            Thrust = 10000;
            MaxThrust = 10000;
            MaxVelocity = new Vector2(100, 100);
            entityManager = eM;

        }
        public override void Update(GameTime gt)
        {
            Orientation = AngleToTarget();
            firingTimer += gt.ElapsedGameTime.Milliseconds;
            if (firingTimer >= 2000)
            {
                FireProjectile(this);
                firingTimer = 0;
            }
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
        private float AngleToTarget()
        {
            Vector2 xy = Target.DrawRectangle.Location.PointToVector()
                - DrawRectangle.Location.PointToVector();
            
            return xy.ToAngle() + (float)Math.PI / 2;
        }
        
    }
}
