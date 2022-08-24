using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{   
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("movingWall"))
        {
            Physics2D.IgnoreCollision(other.collider, gameObject.GetComponent<BoxCollider2D>());
        }
    }
}

