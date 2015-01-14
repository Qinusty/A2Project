using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project
{
    public class Camera
    {
        public Camera(Viewport viewport)
        {
            Origin = new Vector2(viewport.Width / 2.0f, viewport.Height / 2.0f);
            Zoom = 1.5f;
            _viewport = viewport;

        }

        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }
        public Viewport _viewport;

        public Matrix GetViewMatrix(Vector2 parallax)
        {
            // To add parallax, simply multiply it by the position
            return Matrix.CreateTranslation(new Vector3(-Position * parallax, 0.0f)) *
                // The next line has a catch. See note below.
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }
        public void LookAt(Vector2 position)
        {
            Position = position - new Vector2(_viewport.Width / 2.0f, _viewport.Height / 2.0f);
        }


        public Vector2 WorldToScreen(Vector2 worldPosition, Vector2 parallax)
        {
            return Vector2.Transform(worldPosition, GetViewMatrix(parallax));
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition, Vector2 parallax)
        {
            return Vector2.Transform(screenPosition, Matrix.Invert(GetViewMatrix(parallax)));
        }
    }
}
