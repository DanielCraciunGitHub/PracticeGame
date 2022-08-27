using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) // for bullet-wall collisions, and bullet enemy collisions
    {
        if (other.collider.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        if (other.collider.CompareTag("enemy"))
        {
            
            Destroy(other.collider.gameObject);
            
            if (!gameObject.CompareTag("orb")) // allow bullet penetration through enemies for the 'orb' bullet
            {
                Destroy(gameObject);
            }

            ScoreManager.playerScore++;
        }
    }
}
