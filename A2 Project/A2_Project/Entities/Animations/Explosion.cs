using A2_Project.Extensions;
using A2_Project.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Entities.Animations
{
    public class Explosion
    {
        private Vector2 CentrePoint;
        private Rectangle DrawRect
        {
            get
            {
                int width = 32; int height = 32;
                return new Rectangle((int)CentrePoint.X - (width), (int)CentrePoint.Y - (height), width, height);
            }
        }
        private Rectangle SrcRect
        {
            get
            {
                return new Rectangle(100 * (CurrentFrame % 9), 
                    (int)(100 * Math.Floor((double)(CurrentFrame / 9))),
                    100, 100);
            }
        }
        private Texture2D Frames;
        private int msPerFrame { get { return 50; } }
        private int CurrentFrame = 0;
        private int TotalFrames = 81;
        private double counter;
        public CollisionCircle BoundingCircle;
        public bool isAlive { get; private set; }

        public Explosion(Vector2 MidPoint)
        {
            CentrePoint = MidPoint;
            Frames = Textures.ExplosionFrames;
            isAlive = true;
            BoundingCircle = new CollisionCircle(new Vector2(DrawRect.X, DrawRect.Y), DrawRect.Width, DrawRect.Height, DrawRect.Width);
        }
        public void Update(GameTime gt)
        {
            counter += gt.ElapsedGameTime.TotalMilliseconds;
            if (counter >= msPerFrame)
            {
                CurrentFrame += 1;
                counter = 0;
                if (CurrentFrame > TotalFrames)
                {
                    isAlive = false;
                } 
            }
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Frames, DrawRect, SrcRect, Color.White);
        }
    }
}
