﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Extensions;
namespace A2_Project.Entities
{
    public class Ship : Entity
    {
        protected EntityManager entityManager;
        public Ship()
        {
            BoundingCircle = new CollisionCircle(Location, DrawRectangle.Width, Image.Width, radius);
        }
        const float Time = 1 / 60;
        public int radius
        {
            get
            {
                if (Image.Width >= Image.Height)
                {
                    return Image.Width / 2;
                }
                else return Image.Height / 2;

            }
        }
        
        public Inventory.Inventory Cargo;
        /// <summary>
        /// Measured in Newtons.
        /// </summary>
        protected float Thrust; 
        /// <summary>
        /// Measured in Newtons.
        /// </summary>
        protected float MaxThrust;
        /// <summary>
        /// Measured as a 2 dimensional vector of ms^-1.
        /// </summary>
        protected Vector2 Velocity
        {
            get;
            private set;
        }
        protected Vector2 MaxVelocity
        {
            get;
            set;
        }
        /// <summary>
        /// Returns the Vector2 Location from the base class.
        /// </summary>
        public Vector2 getLocation
        {
            get
            {
                return Location;
            }
        }
        /// <summary>
        /// Measured in ms^-2.
        /// </summary>
        protected Vector2 Acceleration
        {
            get { return Direction * (Thrust / (float)Mass) ; }
        }
        private Vector2 Direction
        {
            get { return Extensions.Extensions.AngleToVector(Orientation); }
        }
        protected Vector2 PreviousLocation;
        public CollisionCircle BoundingCircle;
        public virtual void Update(GameTime gt)
        {
            Orientation = Orientation % 360;
            BoundingCircle.UpdatePosition(Location, Image.Width, Image.Height);
            DrawRectangle = new Rectangle((int)Location.X, (int)Location.Y, Image.Width, Image.Height);
        }
        public virtual void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {

        }
        protected virtual void Move(GameTime gt)
        {
            if (Globals.GlobalHandler.CurrentSecondsPerCycle == 0)
                Globals.GlobalHandler.CurrentSecondsPerCycle = 1 / 60;// Presume 60fps
            Velocity = CalculateVelocity(Velocity, Acceleration, Globals.GlobalHandler.CurrentSecondsPerCycle);

            
            Location += CalculateDisplacement();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u">A vector 2 representing Initial velocity.</param>
        /// <param name="a">A floating point value representing the current acceleration in m/tick</param>
        /// <param name="t">A floating point value representing the number of seconds in the movement.</param>
        /// <returns></returns>
        private Vector2 CalculateVelocity(Vector2 u, Vector2 a, float t)
        {
            // SUVAT v = u + at
            Vector2 velocity = u + (a * t);
            if (Math.Abs(velocity.X) > MaxVelocity.X)
                velocity = new Vector2(velocity.X / Math.Abs(velocity.X) * MaxVelocity.X, velocity.Y); 
            // dividing a by modulus of a causes it to equal 1 or -1 depending on whether it is positive or negative
            if (Math.Abs(velocity.Y) > MaxVelocity.Y)
                velocity = new Vector2(velocity.X, velocity.Y / Math.Abs(velocity.Y) * MaxVelocity.Y);// NEED TO LIMIT VELOCITY
            return velocity;
        }
        private Vector2 CalculateDisplacement()
        {
            // SUVAT s = vt - (1/2)at^2 where s = displacement
            return (Velocity * (float)Globals.GlobalHandler.CurrentSecondsPerCycle) -
                ((Acceleration * (float)Math.Pow(Globals.GlobalHandler.CurrentSecondsPerCycle, 2) / 2));
        }
        protected void FireProjectile(Ship s)
        {
            entityManager.addProjecile(Location, Velocity, 1000, Extensions.Extensions.AngleToVector(Orientation), s);
        }
    }
}
