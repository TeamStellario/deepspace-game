using UnityEngine;

namespace DeepSpace.Core
{
    /// <summary>
    /// Defines a 3 dimensional line with an origin and a position vector.
    /// </summary>
    public struct LineD
    {
        public LineD (Vector3D origin, Vector3D positionVector)
        {
            Origin = origin;
            Vector = Vector3D.Normalize(positionVector);
        }

        public readonly Vector3D Origin;
        public readonly Vector3D Vector;

        public Vector3D GetPointAt(double distance)
        {
            return Vector * distance;
        }
    }
}