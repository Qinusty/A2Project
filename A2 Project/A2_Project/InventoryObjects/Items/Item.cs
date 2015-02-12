using A2_Project.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using A2_Project.LinkedLists;
using A2_Project.Inventory.Items;
using Microsoft.Xna.Framework;
namespace A2_Project.Inventory
{
    public abstract class Item
    {
        public String ItemName { get; protected set; }
        public ItemType itemType { get; private set; }
        public string ItemDescription { get; private set; }
        public Texture2D Image { get; protected set; }
        public decimal BuyPrice { get; private set; }
        public decimal SellPrice { get; private set; }

        protected void inititialise(string itemName)
        {
            //Console.WriteLine("Loading Item: " + ItemName);
            //DataSet ds = AccessHelper.ExecuteDataSet("Select * FROM Items WHERE ItemName = " + ItemName + ";", "ItemData");
            //DataRow dr = ds.Tables["ItemData"].Rows[0];

            //ItemName = dr["ItemName"].ToString();
            //itemType = (ItemType)Enum.Parse(typeof(ItemType), dr["ItemType"].ToString());
            //BuyPrice = int.Parse(dr["BuyPrice"].ToString());
            //SellPrice = int.Parse(dr["SellPrice"].ToString());
            //ItemDescription = dr["Description"].ToString();
            //Console.WriteLine("Item Loaded to Memory: " + ItemName);
        }
        protected void Update(GameTime gt)
        {

        }
        /// <summary>
        /// Used to draw the item in the world
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="Location">This is used to define the location that the item will be placed in the world.</param>
        protected void Draw(SpriteBatch sb, Vector2 Location)
        {
            
        }
        //public static SortStatus CompareBuyPrice(Item a, Item b)
        //{
        //    if (a.BuyPrice < b.BuyPrice)
        //        return SortStatus.Before;
        //    else if (a.BuyPrice == b.BuyPrice)
        //        return SortStatus.Equal;
        //    else return SortStatus.After;
        //}
        //public static SortStatus CompareName(Item a, Item b)
        //{
        //    if (string.Compare(a.ItemName, b.ItemName) < 0)
        //        return SortStatus.Before;
        //    else if (string.Compare(a.ItemName, b.ItemName) == 0)
        //        return SortStatus.Equal;
        //    else return SortStatus.After;
        //}
        //public static SortStatus CompareType(Item a, Item b)
        //{
        //    if (a.itemType < b.itemType)
        //        return SortStatus.Before;
        //    else if (a.itemType == b.itemType)
        //        return SortStatus.Equal;
        //    else return SortStatus.After;
        //}
    }
    public enum ItemType
    {
        Ammunition,
        Fuel,
        Upgrade,
        Tool
    }
}
