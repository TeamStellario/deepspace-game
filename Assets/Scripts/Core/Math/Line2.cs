using UnityEngine;

namespace DeepSpace.Core
{
    /// <summary>
    /// Defines a 2 dimensional line with an origin and a position vector.
    /// </summary>
    public struct Line2
    {
        public Line2 (Vector2 origin, Vector2 positionVector)
        {
            Origin = origin;
            Vector = Vector3.Normalize(positionVector);
        }

        public readonly Vector2 Origin;
        public readonly Vector2 Vector;

        public Vector2 GetPointAt(float distance)
        {
            return Vector * distance;
        }
    }
}