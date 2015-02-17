using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Extensions;
using A2_Project.Globals;
namespace A2_Project.Entities
{
    public abstract class Entity
    {
        /// <summary>
        /// TickCounter is used to keep track of the sum of the elapsed gameTimes between each update allowing us to keep
        /// performance stable over different devices with different CPU's/GPU's by updating based on Real time compared to
        /// just updating each update.
        /// </summary>
        #region "Protected Variables"
        protected Color OverlayColour = Color.White;
        public Vector2 Location
        {
            get;
            protected set;
        }
        protected Texture2D Image = Textures.StarterShip;
        public Rectangle DrawRectangle;
        /// <summary>
        /// An angle in radians using 0 as north;
        /// </summary>
        protected float Orientation;
        protected float Scale = 1;
        /// <summary>
        /// Measured in Kilograms.
        /// </summary>
        protected decimal Mass;
        #endregion

        public bool isAlive
        {
            get;
            protected set;
        }

        /// <summary>
        /// Sets the isAlive value to false
        /// </summary>
        public virtual void Kill()
        {
            isAlive = false;
        }

        /// <summary>
        /// Returns the Size of the Image in form of Vector2 (Width, Height).
        /// </summary>
        public Vector2 Size
        {
            get
            {
                return Image == null ? Vector2.Zero : Vector2.Multiply(new Vector2(Image.Width, Image.Height), Scale);
            }
        }

        public Vector2 Origin
        {
            get
            {
                return Size / 2F;
            }
        }

    }
}