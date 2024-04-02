using UnityEngine;

namespace _Root.Code.MoveFeature
{
    public class MoveBehaviour
    {
        private Transform _transform;

        public MoveBehaviour(Transform transform)
        {
            _transform = transform;
        }

        public void Move(Vector2 direction, float speed, float deltaTime)
        {
            _transform.Translate(direction * deltaTime * speed);
        }
    }
}