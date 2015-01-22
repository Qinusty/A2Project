using A2_Project.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Inventory.Items
{
    public class Fuel_Barrel : Item
    {
        public Fuel_Barrel()
        {
            
            base.ItemName = "Fuel Barrel";
            Image = Textures.Fuel_Barrel;
        }
    }
}
