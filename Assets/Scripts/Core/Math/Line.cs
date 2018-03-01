using UnityEngine;

namespace DeepSpace.Core
{
    /// <summary>
    /// Defines a 3 dimensional line with an origin and a position vector.
    /// </summary>
    public struct Line
    {
        public Line (Vector3 origin, Vector3 positionVector)
        {
            Origin = origin;
            Vector = Vector3.Normalize(positionVector);
        }

        public readonly Vector3 Origin;
        public readonly Vector3 Vector;

        public Vector3 GetPointAt(float distance)
        {
            return Vector * distance;
        }
    }
}