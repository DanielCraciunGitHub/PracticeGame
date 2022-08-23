using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D otherObjectCollidedWith)
    {
        if (otherObjectCollidedWith.gameObject.tag == "wall" || otherObjectCollidedWith.gameObject.tag == "movingWall")
        {
            Physics2D.IgnoreCollision(otherObjectCollidedWith.collider, gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
