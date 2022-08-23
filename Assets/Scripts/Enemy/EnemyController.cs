using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static float enemySpeed = 1.0f;

    
    [SerializeField] Transform player;

    private Vector2 movement;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void FixedUpdate()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        follow(direction);
    }
    void follow(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * enemySpeed * Time.deltaTime));

        // handle look direction
        Vector2 lookDirection = (Vector2)player.position - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
