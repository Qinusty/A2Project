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
        private List<Entity> entities;
        private List<Projectile> projectiles = new List<Projectile>();
        
        public EntityManager(Vector2 screenSize)
        {
            entities = new List<Entity>();
            PlayerShip = new Player(screenSize, this);
        }
        public void Update(GameTime gameTime)
        {
            List<Projectile> IndexOfProjectilesToRemove = new List<Projectile>();
            List<Entity> IndexOfEntitiesToRemove = new List<Entity>();
            // SHIPS
            PlayerShip.Update(gameTime);
            //PROJECTILES
            if (projectiles.Count > 0)
            {
                for (int i = projectiles.Count; i > 0; i--)
                {
                    if (!projectiles[i - 1].isAlive)
                        IndexOfProjectilesToRemove.Add(projectiles[i-1]);

                    projectiles[i-1].Update(gameTime);
                }
            }
            // OTHER
            if (entities.Count > 0)
            {
                for (int j = entities.Count; j > 0; j--)
                {
                    if (!entities[j-1].isAlive)
                        IndexOfEntitiesToRemove.Add(entities[j-1]);

                    entities[j-1].Update(gameTime);
                }
            }
            entities.RemoveMultiple<Entity>(IndexOfEntitiesToRemove);
            projectiles.RemoveMultiple<Projectile>(IndexOfProjectilesToRemove);


            
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
        public Ship getPlayer()
        {
            return PlayerShip;
        }
        public void addProjecile(Vector2 Location, Vector2 InitialVelocity, int ForceToBeApplied, Vector2 Direction)
        {
            projectiles.Add(new Projectile(Location, InitialVelocity, ForceToBeApplied, Direction));
        }

    }
}
