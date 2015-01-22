using A2_Project.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Extensions;

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
        private List<Entity> entities, EntitiesToRemove;
        private List<Projectile> projectiles, ProjectilesToRemove, ProjectilesToAdd;
        private List<Enemy> enemies, EnemiesToRemove, EnemiesToAdd;
        
        public EntityManager(Vector2 screenSize)
        {
            entities = new List<Entity>();
            projectiles = new List<Projectile>();
            enemies = new List<Enemy>();

            ProjectilesToAdd = new List<Projectile>();
            EnemiesToAdd = new List<Enemy>();

            EntitiesToRemove = new List<Entity>();
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
            if (projectiles.Count > 0)
            {
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
                                e.Kill();
                                p.Kill();
                            }
                        }
                    }
                }
            }
            // ENEMIES
            if (enemies.Count > 0)
            {
                foreach (Enemy e in enemies)
                {
                    if (!e.isAlive)
                        EnemiesToRemove.Add(e);

                    e.Update(gameTime);
                }
            }

            // OTHER
            if (entities.Count > 0)
            {
                for (int j = entities.Count; j > 0; j--)
                {
                    if (!entities[j-1].isAlive)
                        EntitiesToRemove.Add(entities[j-1]);

                    entities[j-1].Update(gameTime);
                }
            }
            // Remove things which are no longer in the lists.
            entities.RemoveMultiple<Entity>(EntitiesToRemove);
            projectiles.RemoveMultiple<Projectile>(ProjectilesToRemove);
            enemies.RemoveMultiple<Enemy>(EnemiesToRemove);
            // Add the new things
            enemies.AddRange(EnemiesToAdd);
            projectiles.AddRange(ProjectilesToAdd);
            EnemiesToAdd.Clear();
            ProjectilesToAdd.Clear();
                
            // Clear 
            EntitiesToRemove.Clear();
            ProjectilesToRemove.Clear();
            EnemiesToRemove.Clear();
            Console.WriteLine("Bullets: " + projectiles.Count);
            if (enemies.Count > 0)
                Console.WriteLine("Enemies: " + enemies.Count);
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
            foreach (Entity e in entities)
            {
                e.Draw(spriteBatch);
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
                // DRAW ships OVER other entities
            PlayerShip.Draw(spriteBatch);
        }
        /// <summary>
        /// Adds a Entity Object to the list of entities within the EntityManager Instance.
        /// </summary>
        /// <param name="entity">Entity to be added.</param>
        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
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
