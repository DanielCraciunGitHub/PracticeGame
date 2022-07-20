using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static float speed = 1.0f;
    [SerializeField] Transform player; // references the players current position

    Vector2 movement; // holds the direction to move in for the current enemy!s
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void FixedUpdate()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        follow(movement);
    }
    void follow(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

        // handle look direction
        Vector2 lookDirection = (Vector2)player.position - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
