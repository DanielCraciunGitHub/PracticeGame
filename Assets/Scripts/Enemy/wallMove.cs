using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMove : MonoBehaviour
{
    float timeStamp;
    Rigidbody2D rb;
    BoxCollider2D boxCol;

    string positionToSpawn = "";

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(8.5f);
            spawnWall();
        }
    }

    void Update()
    {
        switch (positionToSpawn)
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
    void spawnWall()
    {
        int sideToSpawn = Random.Range(0, 4); 
        
        switch (sideToSpawn)
        {
            case 0:
                transform.position = new Vector2(-12f, -0.25f);
                rb.velocity = new Vector2(3,0);
                positionToSpawn = "left";
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 1:
                transform.position = new Vector2(12f, 0.25f);
                rb.velocity = new Vector2(-3,0);
                positionToSpawn = "right";
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2:
                transform.position = new Vector2(0, 7.45f);
                rb.velocity = new Vector2(0,-3);
                positionToSpawn = "up";
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case 3:
                transform.position = new Vector2(0, -7.45f);
                rb.velocity = new Vector2(0,3);
                positionToSpawn = "down";
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
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
