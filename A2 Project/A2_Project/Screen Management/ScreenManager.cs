using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2_Project.Screen_Management;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace A2_Project.Screen_Management
{
    public enum ScreenState
    {
        Active,
        ShutDown,
        Hidden
    }
    public class ScreenManager
    {

        #region Variables
        private static List<BaseScreen> Screens = new List<BaseScreen>();
        private static List<BaseScreen> NewScreens = new List<BaseScreen>();
        #endregion

        public ScreenManager()
        {
            
        }
        
        public void Update(GameTime gameTime)
        {
            List<BaseScreen> RemoveScreens = new List<BaseScreen>();

            // ITTERATE THROUGH SCREENS LOOKING FOR DEAD SCREENS, IF DEAD ADD TO REMOVESCREENS

            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.State == ScreenState.ShutDown)
                {
                    RemoveScreens.Add(FoundScreen);
                }
                else
                {
                    FoundScreen.Focused = false;
                }
            }
                // Remove Dead Screens

            foreach (BaseScreen FoundScreen in RemoveScreens)
            {
                Screens.Remove(FoundScreen);
            }
            
            // Add New Screens To Manager List

            foreach (BaseScreen FoundScreen in NewScreens)
            {
                Screens.Add(FoundScreen);
            }
            NewScreens.Clear();

            // Check Screen Focus
            if (Screens.Count > 0)
            {
                for (int i = Screens.Count - 1; i > 0; i--)
                {
                    if (Screens[i].GrabFocus)
                    {
                        Screens[i].Focused = true;
                        break;
                    }
                }
            }

            // Handle Input for Focused Screen
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (Globals.GlobalHandler.WindowFocused)
                {
                    FoundScreen.HandleInput();
                }
                FoundScreen.Update(gameTime);
            }
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.State == ScreenState.Active)
                {
                    FoundScreen.Draw(spriteBatch);
                }
            }
        }

        public void AddScreen(BaseScreen screen)
        {
            NewScreens.Add(screen);
        }
        public void UnloadScreen(BaseScreen screen)
        {
            foreach (BaseScreen FoundScreen in Screens)
            {
                if (FoundScreen.Name == screen.Name)
                {
                    FoundScreen.Unload();
                }
            }
        }
        public bool ScreenExists(BaseScreen screen)
        {
            foreach (BaseScreen currentScreen in Screens)
            {
                if (currentScreen.Name == screen.Name)
                    return true;
            }
            return false;
        }
    }
}
