using A2_Project.Inventory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.InventoryObjects.Items
{
    public class ItemInWorld
    {
        public Item Item { get; private set; }
        public Vector2 Location { get; private set; }
        public bool isAlive { get; private set; }
        public Rectangle DrawBox { get; private set; }

        private int LifeSpan;
        
        /// <summary>
        /// This will create a new instance of ItemInWorld.
        /// </summary>
        /// <param name="_Location">Location is the x and y coordinates of the item.</param>
        /// <param name="_Item">Item is the specified item which will be displayed.</param>
        /// <param name="_LifeSpan">Intended lifespan of the object in Milliseconds.</param>
        public ItemInWorld(Vector2 _Location, Item _Item, int _LifeSpan)
        {
            Location = _Location;
            Item = _Item;
            isAlive = true;
            LifeSpan = _LifeSpan;
            DrawBox = new Rectangle((int)Location.X, (int)Location.Y, 16, 16);
        }

        public void Update(GameTime gt)
        {
            LifeSpan -= gt.ElapsedGameTime.Milliseconds;
            if (LifeSpan <= 0)
                isAlive = false;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(Item.Image, DrawBox, Color.White);
        }
    }
}
