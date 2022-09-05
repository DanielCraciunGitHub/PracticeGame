using UnityEngine;

namespace Player
{
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Camera cam;

        private Vector2 _mousePos;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _mousePos = cam.ScreenToWorldPoint(Input.mousePosition);   
        }

        private void FixedUpdate()
        {
            Vector2 lookDirection = _mousePos - _rb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = angle;
        }
    }
}
