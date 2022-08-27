using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
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

        if (other.collider.CompareTag("boss"))
        {
            Destroy(other.collider.gameObject);

            if (!gameObject.CompareTag("orb"))
            {
                Destroy(gameObject);
            }
            
            ScoreManager.playerScore++;
        }
    }
}
