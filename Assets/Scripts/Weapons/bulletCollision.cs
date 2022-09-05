using GameFlow;
using UnityEngine;

namespace Weapons
{
    public class BulletCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("wall"))
            {
                Destroy(gameObject);
            }

            if (other.collider.CompareTag("enemy"))
            {
            
                Destroy(other.collider.gameObject);
            
                if (!gameObject.CompareTag("orb"))
                {
                    Destroy(gameObject);
                }

                ScoreManager.playerScore++;
            }

            if (!other.collider.CompareTag("boss")) 
                return;
            
            Destroy(other.collider.gameObject);
            if (!gameObject.CompareTag("orb")) 
                Destroy(gameObject);

            ScoreManager.playerScore++;
        }
    }
}
