using Code.Domain;
using UnityEngine;

namespace Code.Application.Common
{
    public static class Vector2IntExtensions
    {
        public static Position ToPosition(this Vector2Int vector)
        {
            return new Position(vector.x, vector.y);
        }
        
        public static Vector2Int ToVector2Int(this Position position)
        {
            return new Vector2Int(position.X, position.Y);
        }
    }
}