using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "movingWall") // ignores collisions with walls
        {
            Physics2D.IgnoreCollision(other.collider, gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
