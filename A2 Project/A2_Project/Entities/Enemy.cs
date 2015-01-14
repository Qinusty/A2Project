using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Entities
{
    public class Enemy : Ship
    {
        private Ship Target;

        public Enemy(float x, float y, Ship target)
        {
            Target = target;
            Location = new Vector2(x, y);
        }
    }
}
