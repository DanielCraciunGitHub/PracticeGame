using UnityEngine;

namespace Packages.PlayerChasing
{
    public class ChasedPlayer : MonoBehaviour
    {
        private Vector2 _direction;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float playerSpeed;
        public static Transform playerTransform;

        private void Awake()
        {
            playerTransform = transform;
        }

        private void Update()
        {
            float moveX = Input.GetAxisRaw("Horizontal"); 
            float moveY = Input.GetAxisRaw("Vertical"); 

            _direction = new Vector2(moveX, moveY).normalized;
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(_direction.x * playerSpeed, _direction.y * playerSpeed);
        }
    }
}
