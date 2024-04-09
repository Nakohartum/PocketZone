using UnityEngine;

namespace _Root.Code.Input
{
    public class RangeDrawer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;
        private const int Segments = 60;

        public void DrawCircle(float range)
        {
            _lineRenderer.startWidth = 0.05f;
            _lineRenderer.endWidth = 0.05f;
            _lineRenderer.positionCount = 0;
            _lineRenderer.positionCount = Segments + 1;
            float deltaTheta = (2f * Mathf.PI) / Segments;
            float theta = 0f;

            for (int i = 0; i < Segments + 1; i++)
            {
                float x = range * Mathf.Cos(theta);
                float y = range * Mathf.Sin(theta);
                Vector3 pos = new Vector3(x, y, 0);
                _lineRenderer.SetPosition(i, pos);
                theta += deltaTheta;
            }
        }
    }
}