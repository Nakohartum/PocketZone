using UnityEngine;

namespace _Root.Code.MoveFeature
{
    public class MoveBehaviour
    {
        private Rigidbody2D _rigidbody;

        public MoveBehaviour(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public void Move(Vector2 direction, float speed)
        {
            var movePosition = direction * speed;
            _rigidbody.velocity = movePosition;
        }
    }
}