using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMove : MonoBehaviour
{
    float timeStamp;
    Rigidbody2D rb;
    BoxCollider2D boxCol;

    string pos = "";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();

        InvokeRepeating("spawnWall", 1, 8.5f);
    }

    void Update()
    {
        switch (pos)
        {
            case "right":
                if (transform.position.x < -0.2f)
                {
                    rb.velocity = new Vector2(0, 0);
                }
                break;
            case "left":
                if (transform.position.x > 0.2f)
                {
                    rb.velocity = new Vector2(0, 0);
                } 
                break;
            case "up":
                if (transform.position.y < 0)
                {
                    rb.velocity = new Vector2(0, 0);
                }   
                break;
            case "down":
                if (transform.position.y > 0)
                {
                    rb.velocity = new Vector2(0, 0);
                }
                break;

        }
    }
    void spawnWall() // decide which side to spawn the wall
    {
        int loc = Random.Range(0, 4); 
        
        switch (loc)
        {
            case 0:
                transform.position = new Vector2(-12f, -0.25f);
                rb.velocity = new Vector2(3,0);
                pos = "left";
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1:
                transform.position = new Vector2(12f, 0.25f);
                rb.velocity = new Vector2(-3,0);
                pos = "right";
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                transform.position = new Vector2(0, 7.45f);
                rb.velocity = new Vector2(0,-3);
                pos = "up";
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case 3:
                transform.position = new Vector2(0, -7.45f);
                rb.velocity = new Vector2(0,3);
                pos = "down";
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }
    void OnCollisionEnter2D(Collision2D other) // handle collisions with other rigid bodies
    {
        if (other.collider.tag == "wall")
        {
            Physics2D.IgnoreCollision(other.collider, boxCol);
        }
        else if (other.collider.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
