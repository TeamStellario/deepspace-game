using UnityEngine;

namespace DeepSpace.Core
{
    /// <summary>
    /// Defines a 2 dimensional line with an origin and a position vector.
    /// </summary>
    public struct Line2D
    {
        public Line2D (Vector2D origin, Vector2D positionVector)
        {
            Origin = origin;
            Vector = Vector2D.Normalize(positionVector);
        }

        public readonly Vector2D Origin;
        public readonly Vector2D Vector;

        public Vector2D GetPointAt(double distance)
        {
            return Vector * distance;
        }
    }
}