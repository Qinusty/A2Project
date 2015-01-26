using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Extensions;
namespace A2_Project.Extensions
{
    public class CollisionCircle
    {
        private int Radius;
        private Vector2 midPoint;
        public CollisionCircle(Vector2 Location, int width, int height, int radius)
        {
            Radius = radius;
            UpdatePosition(Location, width, height);
        }
        public bool isCollided(CollisionCircle c)
        {
            if (Extensions.DistanceTo(midPoint, c.midPoint) < Radius + c.Radius)
            {
                return true;
            }
            else return false;
        }
        public void UpdatePosition(Vector2 Location, int width, int height)
        {
            midPoint = new Vector2(Location.X + (width / 2), Location.Y + (height / 2));
        }
            
    }
}
