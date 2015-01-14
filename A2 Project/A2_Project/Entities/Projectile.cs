using A2_Project.Globals;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Entities
{
    public class Projectile : Entity
    {
        private Vector2 Velocity;
        private Ship Owner;
        private double LifeTime;
        /// <summary>
        /// The projectile is instantiated and its constant velocity is set based on the force applied and the direction given.
        /// </summary>
        /// <param name="InitialVelocity">The velocity of the ship firing it.</param>
        /// <param name="Force">The force applied to the projectile to set it off.</param>
        /// <param name="Direction">The direction of the ship.</param>
        public Projectile(Vector2 StartLoc, Vector2 InitialVelocity, int Force, Vector2 Direction)
        {
            Image = Textures.Star;
            Mass = 1;
            isAlive = true;
            LifeTime = 10;
            Location = StartLoc;
            Velocity = InitialVelocity + (Direction * (float)(Force / Mass));
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        public override void Update(GameTime gt)
        {
            LifeTime -= gt.ElapsedGameTime.TotalSeconds;
            if (LifeTime <= 0) // projectiles have a lifespan so that they don't stay forever.
                base.Kill();

            // SUVAT s = vt - (1/2)at^2 BUT a = 0 therefore s = vt
            Vector2 displacement = Velocity * Globals.GlobalHandler.CurrentSecondsPerCycle;
            Location += displacement;
            base.Update(gt);
        }
    }
}
