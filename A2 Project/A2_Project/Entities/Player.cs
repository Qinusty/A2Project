using A2_Project.Extensions;
using A2_Project.Globals;
using A2_Project.Inventory.Items;
using A2_Project.Screen_Management.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Shield { get; private set; }
        public int MaxShield { get; private set; }

        public int KillCount
        {
            get;
            private set;
        }

        private int LastHitTimer;
        private int ShieldRegenTimer;
        public Player(EntityManager eM, Vector2 screenSize)
        {
            Location = screenSize / 2F;
            isAlive = true;
            Thrust = 0;
            Scale = 1;
            setShip(1);
            entityManager = eM;
            DrawRectangle = new Rectangle((int)Location.X, (int)Location.Y, Image.Width, Image.Height);
            MaxVelocity = new Vector2(200, 200);
            MaxHealth = 100; MaxShield = 100;
            Health = 100; Shield = MaxShield;
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

        public override void Update(GameTime gt)
        {
            LastHitTimer += gt.ElapsedGameTime.Milliseconds;
            ShieldRegenTimer += gt.ElapsedGameTime.Milliseconds;

            if (LastHitTimer >= 2500)
                if (ShieldRegenTimer >= 1000 && Shield < MaxShield)
                {
                    ShieldRegenTimer = 0;
                    Shield += 5;
                }
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
            //if (InputHelper.isKeyPressed(Keys.Q))
            //{
            //    entityManager.AddEnemy(new Enemy(Location, this, entityManager));
            //}
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
                FireProjectile(this);
            }

        }
        protected override void Move(GameTime gt)
        {
            base.Move(gt);
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Location, new Rectangle(0,0,32,32), Textures.ShipColor,
                 Orientation, Size / 2f, Scale, SpriteEffects.None, 0);
            
            base.Draw(spriteBatch);
        }
        public void DamagePlayer(int amount)
        {
            LastHitTimer = 0;
            
            if (Shield > amount)
            {
                Shield -= amount;
            }
            else if (Shield > 0)
            {
                int DamageOverlap = amount - Shield;
                Shield = 0;
                Health -= DamageOverlap;
            }
            else Health -= amount;

            if (Health <= 0)
                isAlive = false;
        }
        public void AddKill()
        {
            KillCount += 1;
        }
    }
}
