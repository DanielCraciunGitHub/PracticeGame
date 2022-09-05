using UnityEngine;

namespace Packages.PlayerChasing
{
    public class PlayerChaser : MonoBehaviour
    {
        public static float chaseSpeed = 1.0f;
        [SerializeField] private Rigidbody2D chaserRb;


        private void FixedUpdate()
        {
            Vector2 direction = ChasedPlayer.playerTransform.position - transform.position;
            direction.Normalize();
            Follow(direction);
        }

        private void Follow(Vector2 direction)
        {
            chaserRb.MovePosition((Vector2)transform.position + (direction * (chaseSpeed * Time.deltaTime)));
            Vector2 lookDirection = (Vector2)ChasedPlayer.playerTransform.position - chaserRb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            chaserRb.rotation = angle;
        } 
    }
}
