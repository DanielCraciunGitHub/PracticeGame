using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollision : MonoBehaviour
{
    EnemySpawner e;
    PlayerController p;

    void Awake()
    {
        p = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>(); // allows for score counting
        e = GameObject.FindGameObjectWithTag("enemyControl").GetComponent<EnemySpawner>(); // includes an object with the EnemySpawner script attached to it
    }
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

            e.decrement(); // decrements the enemy count
            p.increment(); // increment player score
        }
    }
}
