using System;
using UnityEngine;

namespace DeepSpace.Core
{
    /// <summary>
    /// Defines a vector with 2 double components.
    /// </summary>
    public struct Vector2D
    {
        public Vector2D (double x, double y) {this.x = x; this.y = y;}

        public double x;
        public double y;

        public static Vector2D zero     =   new Vector2D(0, 0);
        public static Vector2D up       =   new Vector2D(0, 1);
        public static Vector2D down     =   new Vector2D(0, -1);
        public static Vector2D right    =   new Vector2D(1, 0);
        public static Vector2D left     =   new Vector2D(-1, 0);

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
        }

        public static Vector2D Normalize (Vector2D vec)
        {
            double m = vec.Magnitude;
            return new Vector2D(vec.x / m, vec.y / m);
        }

		public override int GetHashCode()
        {
			return ((byte)x << 8) | (byte)y;
		}

		public override bool Equals(object obj)
		{
			if (obj != null)
			{
				var rhs = obj as Vector2D?;
				if (rhs.HasValue)
					return this == rhs.Value;
			}

			return false;
		}

        public static bool operator == (Vector2D lhs, Vector2D rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator != (Vector2D lhs, Vector2D rhs)
        {
            return !(lhs == rhs);
        }

        public static Vector2D operator + (Vector2D lhs, Vector2D rhs)
        {
            return new Vector2D(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Vector2D operator - (Vector2D lhs, Vector2D rhs)
        {
            return new Vector2D(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2D operator * (Vector2D lhs, double rhs)
        {
            return new Vector2D(lhs.x * rhs, lhs.y * rhs);
        }
        public static Vector2D operator * (double lhs, Vector2D rhs)
        {
            return rhs * lhs;
        }

        public static Vector2D operator / (Vector2D lhs, double rhs)
        {
            return new Vector2D(lhs.x / rhs, lhs.y * rhs);
        }
    }
}