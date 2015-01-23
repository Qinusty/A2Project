﻿using A2_Project.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Extensions;
using A2_Project.Inventory;
using A2_Project.InventoryObjects.Items;

namespace A2_Project.Entities
{
    public class EntityManager
    {
        private const int EnemySpawnTimer = 8 * 1000; 
        #region "Singleton"
        private static EntityManager instance;
        public static EntityManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new EntityManager(new Vector2(1280, 1024));
                return instance;
            }
        }
        #endregion

        private Ship PlayerShip;
        private int SpawnCycleTimer = 0;
        private List<ItemInWorld> items, itemsToRemove, itemsToAdd;
        private List<Projectile> projectiles, ProjectilesToRemove, ProjectilesToAdd;
        private List<Enemy> enemies, EnemiesToRemove, EnemiesToAdd;
        
        public EntityManager(Vector2 screenSize)
        {
            items = new List<ItemInWorld>();
            projectiles = new List<Projectile>();
            enemies = new List<Enemy>();

            ProjectilesToAdd = new List<Projectile>();
            EnemiesToAdd = new List<Enemy>();
            itemsToAdd = new List<ItemInWorld>();

            itemsToRemove = new List<ItemInWorld>();
            ProjectilesToRemove = new List<Projectile>();
            EnemiesToRemove = new List<Enemy>();

            PlayerShip = new Player(screenSize, this);
        }
        public void Update(GameTime gameTime)
        {

            if (SpawnCycleTimer >= EnemySpawnTimer && enemies.Count < 15)
            {
                SpawnCycleTimer = 0;
                GenerateEnemies(6);
            }
            else SpawnCycleTimer += gameTime.ElapsedGameTime.Milliseconds;

            // SHIPS
            PlayerShip.Update(gameTime);
            //PROJECTILES
                foreach(Projectile p in projectiles)
                {
                    if (!p.isAlive)
                        ProjectilesToRemove.Add(p);

                    p.Update(gameTime);
                    // Collision
                    foreach (Enemy e in enemies)
                    {
                        if (p.Owner != e)
                        {
                            if (p.CollidesWith(e)) // SORT OUT COLLISION USING DRAWRECTANGLE AS A RECTANGLE TO COLLIDE WITH
                            {
                                e.DropLoot(this);
                                e.Kill();
                                p.Kill();
                            }
                        }
                    }
                }
            
            // ENEMIES

                foreach (Enemy e in enemies)
                {
                    if (!e.isAlive)
                        EnemiesToRemove.Add(e);

                    e.Update(gameTime);
                }
            

            // OTHER
            foreach (ItemInWorld i in items)
            {
                if (!i.isAlive)
                    itemsToRemove.Add(i);

                // Collision with player 
                if (i.DrawBox.Intersects(PlayerShip.DrawRectangle))
                {
                    PlayerShip.Cargo.AddToInventory(i.Item);
                    itemsToRemove.Add(i);
                }
                i.Update(gameTime);
            }

            // Remove things which are no longer in the lists.
            items.RemoveMultiple<ItemInWorld>(itemsToRemove);
            projectiles.RemoveMultiple<Projectile>(ProjectilesToRemove);
            enemies.RemoveMultiple<Enemy>(EnemiesToRemove);
            // Add the new things
            items.AddRange(itemsToAdd);
            enemies.AddRange(EnemiesToAdd);
            projectiles.AddRange(ProjectilesToAdd);

                
            // Clear 
            itemsToRemove.Clear();
            ProjectilesToRemove.Clear();
            EnemiesToRemove.Clear();
            EnemiesToAdd.Clear();
            ProjectilesToAdd.Clear();
            itemsToAdd.Clear();
        }
        public void GenerateEnemies(int maxEnemies, int minEnemies = 1)
        {
            Random r = new Random();
            int enemiesToGenerate = r.Next(minEnemies, maxEnemies);
            for(int i = 0; i < enemiesToGenerate; i++)
            {
                AddEnemy(new Enemy(PlayerShip.Location + new Vector2(r.Next(-50, 50), r.Next(-50, 50)), PlayerShip));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (ItemInWorld i in items)
            {
                i.Draw(spriteBatch);
            }
                // Draw projectiles
            foreach (Projectile p in projectiles)
            {
                p.Draw(spriteBatch);
            }
            foreach (Enemy e in enemies)
            {
                e.Draw(spriteBatch);
            }
                // DRAW ships OVER other items
            PlayerShip.Draw(spriteBatch);
        }

        public void LootDrop(Item Item, Vector2 Location)
        {
            itemsToAdd.Add(new ItemInWorld(Location, Item, 30000));
        }
        public void AddEnemy(Enemy e)
        {
            EnemiesToAdd.Add(e);
        }
        public Ship getPlayer()
        {
            return PlayerShip;
        }
        public void addProjecile(Vector2 Location, Vector2 InitialVelocity, int ForceToBeApplied, Vector2 Direction)
        {
            ProjectilesToAdd.Add(new Projectile(Location, InitialVelocity, ForceToBeApplied, Direction));
        }

    }
}
