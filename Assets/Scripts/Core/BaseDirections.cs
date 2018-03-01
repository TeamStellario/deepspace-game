using UnityEngine;

namespace DeepSpace.Core
{
    /// <summary>
    /// Contains enumerables, constants and methods for assisting with directional based Math.
    /// </summary>
    public sealed class BaseDirections
    {
        public enum Direction : byte
        {
            Forward     = 0,
            Backward    = 1,
            Right       = 2,
            Left        = 3,
            Up          = 4,
            Down        = 5
        }

        public enum Axis : byte
        {
            X = 0,
            Y = 1,
            Z = 2
        }

        [System.Flags]
        public enum DirectionFlags : byte
        {
            Forward		= 1 << (int)Direction.Forward,
			Backward	= 1 << (int)Direction.Backward,
			Left		= 1 << (int)Direction.Left,
			Right		= 1 << (int)Direction.Right,
			Up			= 1 << (int)Direction.Up,
			Down		= 1 << (int)Direction.Down,

			All = Forward | Backward | Left | Right | Up | Down
        }

        private static readonly Vector3[] Directions =
        {
            Vector3.forward,
            Vector3.back,
            Vector3.right,
            Vector3.left,
            Vector3.up,
            Vector3.down
        };

        private static readonly Quaternion[] Rotations =
        {
            Quaternion.Euler(0, 0, 0),
			Quaternion.Euler(0, 180, 0),
			Quaternion.Euler(0, 90, 0),
			Quaternion.Euler(0, 270, 0),
			Quaternion.Euler(0, 0, 90),
			Quaternion.Euler(0, 0, 270)
        };

        public static Vector3 GetVector (Direction dir)
        {
            return Directions[(int)dir];
        }

        public static Vector3 VectorInDirection (Quaternion rot, Direction dir)
        {
            return rot * GetVector(dir);
        }

        public static Direction Reverse(Direction dir)
        {
            switch (dir)
            {
                case Direction.Forward:
                    return Direction.Backward;
                case Direction.Backward:
                    return Direction.Forward;
                case Direction.Right:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Right;
                case Direction.Up:
                    return Direction.Down;
            }

            return Direction.Up;
        }

        public static Axis GetAxis (Direction dir)
        {
            if (dir == Direction.Right || dir == Direction.Left)
                return Axis.X;
            if (dir == Direction.Up || dir == Direction.Down)
                return Axis.Y;

            return Axis.Z;
        }
    }
}