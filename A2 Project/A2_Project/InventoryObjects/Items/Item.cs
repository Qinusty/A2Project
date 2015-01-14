using A2_Project.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using A2_Project.LinkedLists;
using A2_Project.Inventory.Items;
namespace A2_Project.Inventory
{
    public abstract class Item
    {
        public String ItemName { get; protected set; }
        public ItemType itemType { get; private set; }
        public string ItemDescription { get; private set; }
        public Texture2D image { get; private set; }
        public decimal BuyPrice { get; private set; }
        public decimal SellPrice { get; private set; }
        public Ship Owner { get; protected set; }


        public delegate void ActivationDelegate();
        public ActivationDelegate Activate;
        protected void inititialise(string itemName)
        {
            Console.WriteLine("Loading Item: " + ItemName);
            DataSet ds = AccessHelper.ExecuteDataSet("Select * FROM Items WHERE ItemName = " + ItemName + ";", "ItemData");
            DataRow dr = ds.Tables["ItemData"].Rows[0];

            ItemName = dr["ItemName"].ToString();
            itemType = (ItemType)Enum.Parse(typeof(ItemType), dr["ItemType"].ToString());
            BuyPrice = int.Parse(dr["BuyPrice"].ToString());
            SellPrice = int.Parse(dr["SellPrice"].ToString());
            ItemDescription = dr["Description"].ToString();
            Console.WriteLine("Item Loaded to Memory: " + ItemName);
        }
        public static SortStatus CompareBuyPrice(Item a, Item b)
        {
            if (a.BuyPrice < b.BuyPrice)
                return SortStatus.Before;
            else if (a.BuyPrice == b.BuyPrice)
                return SortStatus.Equal;
            else return SortStatus.After;
        }
        public static SortStatus CompareName(Item a, Item b)
        {
            if (string.Compare(a.ItemName, b.ItemName) < 0)
                return SortStatus.Before;
            else if (string.Compare(a.ItemName, b.ItemName) == 0)
                return SortStatus.Equal;
            else return SortStatus.After;
        }
        public static SortStatus CompareType(Item a, Item b)
        {
            if (a.itemType < b.itemType)
                return SortStatus.Before;
            else if (a.itemType == b.itemType)
                return SortStatus.Equal;
            else return SortStatus.After;
        }
        public static void initialiseItems()
        {
            #region ITEMLIST DECLARATION
            List<Type> Items = new List<Type>();
            Items.Add(typeof(Fuel_Barrel));
            #endregion
            
        }
    }
    public enum ItemType
    {
        Ammunition,
        Fuel,
        Upgrade,
        Tool
    }
}
