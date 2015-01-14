using A2_Project.Extensions;
using A2_Project.Globals;
using A2_Project.Screen_Management.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace A2_Project.Entities
{
    public class Player : Ship
    {
        public string ShipName { get; private set; }
        private EntityManager entityManager;
        public Player(Vector2 screenSize, EntityManager eM)
        {
            Location = screenSize / 2F;
            Thrust = 0;
            Scale = 1;
            setShip(1);
            entityManager = eM;
        }
        public void setShip(int ID)
        {
            Console.WriteLine("Setting Ship...");
            DataSet d = AccessHelper.ExecuteDataSet("SELECT * FROM Ships WHERE ID = " + ID + ";", "ShipDataSet");
            DataRow dr = d.Tables["ShipDataSet"].Rows[0];

            ShipName = dr["ShipName"].ToString();
            MaxThrust =  float.Parse(dr["MaxThrust"].ToString());
            base.Cargo = new Inventory.Inventory("Player Cargo", int.Parse(dr["CargoCapacity"].ToString())); // set inventory size
            Mass = decimal.Parse(dr["Mass"].ToString());            
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gt)
        {
            HandleInput();
            Move(gt);

            base.Update(gt);
        }
        private void HandleInput()
        {
            if (InputHelper.isKeyDown(Keys.W))
            {
                if (Thrust < MaxThrust)
                {
                    if (Thrust == 0)
                    {
                        Thrust += MaxThrust / 10; // Initial Thrust
                    }
                    Thrust += MaxThrust / 50;
                }
            }
            else Thrust = 0;
            if (InputHelper.isKeyDown(Keys.A))
                Orientation -= (float)(0.05);
            if (InputHelper.isKeyDown(Keys.D))
                Orientation += (float)(0.05);
            if (InputHelper.isKeyDown(Keys.S))
            {
                

            }
            if (InputHelper.isKeyPressed(Keys.E))
            {
                InventoryScreen invScreen = new InventoryScreen("Inventory", Cargo);
                if (!GlobalHandler.ScreenManager.ScreenExists(invScreen))
                    GlobalHandler.ScreenManager.AddScreen(invScreen);
                else
                    GlobalHandler.ScreenManager.UnloadScreen(invScreen);
            }
            if (InputHelper.isKeyPressed(Keys.Space))
            {
                entityManager.addProjecile(Location, Velocity, 1000, Extensions.Extensions.AngleToVector(Orientation));
            }

        }
        protected override void Move(GameTime gt)
        {
            base.Move(gt);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            
            Console.WriteLine("Thrust: " + Thrust + "\n Accel(ms^-2): " + Acceleration + "\n Velocity(ms^-1): " + Velocity + "\n Speed(ms^-1):" + Extensions.Extensions.Pythagorus(Velocity.X, Velocity.Y));
            base.Draw(spriteBatch);
        }
    }
}
