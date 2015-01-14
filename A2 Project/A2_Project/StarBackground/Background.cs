using A2_Project.LinkedLists;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.StarBackground
{
    public class Background
    {
        const int MaxNumberOfStars = 4000;
        private MyLinkedList<Star> stars = new MyLinkedList<Star>();
        Random rand = new Random();
        public Background()
        {
            GenerateStars(); 
        }
        public void Draw(SpriteBatch spritebatch)
        {
            MyLinkedListNode<Star> cNode = stars.Start;
            do
            {
                cNode.Data.Draw(spritebatch, Globals.GlobalHandler._camera);
                cNode = cNode.Pointer;
            } while (cNode.Pointer != null);
        }
        public void Update(Camera c)
        {
            
        }

        private void GenerateStars(int i = 0)
        {
            if (i > MaxNumberOfStars)
            {
                //BASE CASE
            }
            else
            {
                Star tempStar = new Star(new Vector2(rand.Next(-3000, 3000),
                    rand.Next(-10000, 10000)),
                    rand.Next(100, 255),
                    new Vector2((float)rand.NextDouble()));
                stars.AddToList(new MyLinkedListNode<Star>(tempStar, tempStar.ParralaxValue.X.ToString()));
                GenerateStars(i + 1);
            }
            
        }
    }
}
