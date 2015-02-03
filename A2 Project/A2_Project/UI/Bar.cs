using A2_Project.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.UI
{
    public class Bar
    {
        public Color ForeColour { get; private set; }
        public Color BackColour { get; private set; }
        public Vector2 Dimensions { get; private set; }
        public Vector2 Position { get; private set; }
        public BarType Direction { get; private set; }
        public int Maximum { get; private set; }
        private Texture2D singlePixel;
        public Bar(Color foreCol, Color backCol, Vector2 dimensions, Vector2 position, int maximum, BarType direction)
        {
            ForeColour = foreCol;
            BackColour = backCol;
            Dimensions = dimensions;
            Position = position;
            Maximum = maximum;
            Direction = direction;
        }
        public void Draw(SpriteBatch sb, int Value)
        {

            //BackBar
            sb.Draw(Textures.SinglePixel, new Rectangle((int)Position.X, (int)Position.Y,
                (int)Dimensions.X, (int)Dimensions.Y), BackColour);
            //ForeBar
            sb.Draw(Textures.SinglePixel, GetForeRect(Value), ForeColour);
            
            
        }
        private Rectangle GetForeRect(float value)
        {
            float ratio = value / Maximum;
            switch (Direction)
            {
                case BarType.LeftToRight:
                    return new Rectangle((int)Position.X, (int)Position.Y, (int)(Dimensions.X * ratio), (int)Dimensions.Y);
                    break;
                case BarType.BottomToTop:
                    return new Rectangle((int)Position.X, (int)Position.Y, (int)Dimensions.X, (int)(Dimensions.Y * ratio));
                    break;
                default:
                    return new Rectangle(0,0,0,0);
                    break;
            }
        }
    }
    public enum BarType
    {
        LeftToRight,
        BottomToTop
    }
}
