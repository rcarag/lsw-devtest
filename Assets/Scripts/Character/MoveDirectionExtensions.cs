using System;
using UnityEngine;

namespace Game
{
    public static class MoveDirectionExtensions
    {
        public static Vector2 AsVector2(this MoveDirection direction)
        {
            switch (direction)
            {
                case MoveDirection.None:
                    return Vector2.zero;
                case MoveDirection.Up:
                    return Vector2.up;
                case MoveDirection.Down:
                    return Vector2.down;
                case MoveDirection.Left:
                    return Vector2.left;
                case MoveDirection.Right:
                    return Vector2.right;
            }

            throw new NotImplementedException();
        }
    }

}