using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Inventory.Items
{
    public class Fuel_Barrel : Item
    {
        public Fuel_Barrel(ActivationDelegate Action)
        {
            Activate = Action;
            base.ItemName = "Fuel Barrel";
        }
    }
}
