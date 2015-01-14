using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Extensions
{
    public class SolidColorTexture : Texture2D
    {
        public static void initialise(GraphicsDevice gd)
        {
            graphicsDevice = gd;
        }
        private static GraphicsDevice graphicsDevice;
        private Color _color;
        // Gets or sets the color used to create the texture
        public Color Color
        {
            get { return _color; }
            set
            {
                if (value != _color)
                {
                    _color = value;
                    SetData<Color>(new Color[] { _color });
                }
            }
        }
        public SolidColorTexture()
            : base(graphicsDevice, 1, 1)
        {
            //default constructor
        }
        public SolidColorTexture(Color color)
            : base(graphicsDevice, 1, 1)
        {
            Color = color;
        }

    }
}
