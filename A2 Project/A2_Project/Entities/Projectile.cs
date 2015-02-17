using A2_Project.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Extensions;

namespace A2_Project.Entities
{
    public class Projectile : Entity
    {
        private Vector2 Velocity;
        public Ship Owner;
        public int radius
        {
            get
            {
                if (DrawRectangle.Width >= DrawRectangle.Height)
                {
                    return 5;
                }
                else return 5;

            }
        }
        public CollisionCircle BoundingCircle;
        private double LifeTime;
        /// <summary>
        /// The projectile is instantiated and its constant velocity is set based on the force applied and the direction given.
        /// </summary>
        /// <param name="InitialVelocity">The velocity of the ship firing it.</param>
        /// <param name="Force">The force applied to the projectile to set it off.</param>
        /// <param name="Direction">The direction of the ship.</param>
        public Projectile(Vector2 StartLoc, Vector2 InitialVelocity, int Force, Vector2 Direction, Ship s)
        {
            Image = Textures.Star;
            Mass = 1;
            isAlive = true;
            LifeTime = 5;
            Location = StartLoc;
            Orientation = Direction.ToAngle();
            Velocity = InitialVelocity + (Direction * (float)(Force / Mass));
            DrawRectangle = new Rectangle((int)Location.X, (int)Location.Y, 10, 3);
            BoundingCircle = new CollisionCircle(Location, DrawRectangle.Width, DrawRectangle.Height, radius);
            Owner = s;
        }
        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(Image, Location, new Rectangle(0, 0, 10, 3), Color.Yellow,
                    Orientation, Size / 2f, Scale, SpriteEffects.None, 0);
            }
        }
        public void Update(GameTime gt)
        {
            
            DrawRectangle = new Rectangle((int)Location.X, (int)Location.Y, 10, 3);
            LifeTime -= gt.ElapsedGameTime.TotalSeconds;

            if (LifeTime <= 0) // projectiles have a lifespan so that they don't stay forever.
                base.Kill();

            // SUVAT s = vt - (1/2)at^2 BUT a = 0 therefore s = vt
            Vector2 displacement = Velocity * Globals.GlobalHandler.CurrentSecondsPerCycle;
            Location += displacement;
            
            BoundingCircle.UpdatePosition(Location, DrawRectangle.Width, DrawRectangle.Height);
        }
        public bool CollidesWith(Ship s)
        {
            if (isAlive)
            {
                if (BoundingCircle.isCollided(s.BoundingCircle))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
