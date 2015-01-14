using A2_Project.Entities;
using A2_Project.StarBackground;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Screen_Management.Screens
{
    public class GameScreen : BaseScreen
    {
        private Background background;
        private EntityManager entityManager;
        public GameScreen(string ScreenName)
        {
            entityManager = new EntityManager(Globals.GlobalHandler.BufferArea);
            Name = ScreenName;
            background = new Background();
        }
        public override void Update(GameTime gameTime)
        {
            entityManager.Update(gameTime);
            Globals.GlobalHandler._camera.LookAt(entityManager.getPlayer().getLocation);
            background.Update(Globals.GlobalHandler._camera);
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Add your drawing code here
            Vector2 parallax = Vector2.One;

            // Spritebatch.Begin() is called within the Star Class for an effective parralax effect
            background.Draw(spriteBatch);


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null,
                Globals.GlobalHandler._camera.GetViewMatrix(parallax));
            entityManager.Draw(spriteBatch);
            spriteBatch.End();

           base.Draw(spriteBatch);
        }
    }
}
