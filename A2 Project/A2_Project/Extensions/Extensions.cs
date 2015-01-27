using A2_Project.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A2_Project.Extensions
{
    static class Extensions
    {
        public static float ToAngle(this Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
        public static Vector2 AngleToVector(float angle)
        {
            return new Vector2((float)Math.Sin(angle), -(float)Math.Cos(angle));
        }
        public static Vector2 PointToVector(this Point p)
        {
            return new Vector2(p.X, p.Y);
        }
        public static Color getColourFromARGB(byte r, byte g, byte b, byte Alpha)
        {
            Color tempCol = new Color();
            tempCol.A = Alpha;
            tempCol.R = r;
            tempCol.G = g;
            tempCol.B = b;
            return tempCol;
        }
        public static Color getRandomColor(this Random r, Color[] cols)
        {
            return cols[r.Next(1, cols.Length - 1)];
        }
        public static Color ChangeAlpha(this Color c, byte Alpha)
        {
            c.A = Alpha;
            return c;
        }
        public static double Pythagorus(float a, float b)
        {
            double A, B;
            A = Convert.ToDouble(a); B = Convert.ToDouble(b);
            A = Math.Pow(A, 2); B = Math.Pow(B, 2);
            return Math.Sqrt(A + B);
        }
        public static double DistanceTo(Vector2 posA, Vector2 posB)
        {
            Vector2 DistanceVector = posA - posB;
            return Pythagorus(DistanceVector.X, DistanceVector.Y);
        }
        public static void RemoveMultiple<T>(this List<T> l, List<T> ListOfItemsToRemove)
        {
            foreach (T t in ListOfItemsToRemove)
            {
                l.Remove(t);
            }
        }
    }
}
