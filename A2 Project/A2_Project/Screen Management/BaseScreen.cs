using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Screen_Management
{
    public abstract class BaseScreen
    {
        #region Variables
        public string Name = "";
        public ScreenState State = ScreenState.Active;
        public Single Position;
        public bool Focused = false;
        public bool GrabFocus = true;
        private bool IsAlive = true;
           
        #endregion
      
        public virtual void HandleInput()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!IsAlive)
            {
                this.Unload();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

        public virtual void Unload()
        {
            State = ScreenState.ShutDown;
        }

    }
}
