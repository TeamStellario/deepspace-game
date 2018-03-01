using System;
using UnityEngine;

namespace DeepSpace.Core
{
    /// <summary>
    /// Defines a vector with 3 double components.
    /// </summary>
    public struct Vector3D
    {
        public Vector3D (double x, double y, double z) {this.x = x; this.y = y; this.z = z;}
        public Vector3D (double x, double y) {this.x = x; this.y = y; z = 0;}

        public double x;
        public double y;
        public double z;

        public static Vector3D zero     =   new Vector3D(0, 0, 0);
        public static Vector3D forward  =   new Vector3D(0, 0, 1);
        public static Vector3D backward =   new Vector3D(0, 0, -1);
        public static Vector3D right    =   new Vector3D(0, 1, 0);
        public static Vector3D left     =   new Vector3D(0, -1, 0);
        public static Vector3D up       =   new Vector3D(0, 1, 0);
        public static Vector3D down     =   new Vector3D(0, -1, 0);

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public static Vector3D Normalize (Vector3D vec)
        {
            double m = vec.Magnitude;
            return new Vector3D(vec.x / m, vec.y / m, vec.z / m);
        }

		public override int GetHashCode()
        {
			return ((byte)x << 16) | ((byte)y << 8) | (byte)z;
		}

		public override bool Equals(object obj)
		{
			if (obj != null)
			{
				var rhs = obj as Vector3D?;
				if (rhs.HasValue)
					return this == rhs.Value;
			}

			return false;
		}

        public static bool operator == (Vector3D lhs, Vector3D rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y && lhs.z == rhs.z;
        }

        public static bool operator != (Vector3D lhs, Vector3D rhs)
        {
            return !(lhs == rhs);
        }

        public static Vector3D operator + (Vector3D lhs, Vector3D rhs)
        {
            return new Vector3D(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Vector3D operator - (Vector3D lhs, Vector3D rhs)
        {
            return new Vector3D(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static Vector3D operator * (Vector3D lhs, double rhs)
        {
            return new Vector3D(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector3D operator * (double lhs, Vector3D rhs)
        {
            return rhs * lhs;
        }

        public static Vector3D operator / (Vector3D lhs, double rhs)
        {
            return new Vector3D(lhs.x / rhs, lhs.y * rhs, lhs.z / rhs);
        }
    }
}