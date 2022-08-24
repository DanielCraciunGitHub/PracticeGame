using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wallMove : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCol;
    string positionToSpawn = string.Empty;

    void Awake() 
    {
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
        checkWallLocation();
    }
    private void checkWallLocation()
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
                initWall("left", position: new Vector2(-12f, -0.25f), velocity: new Vector2(3, 0), rotation: new Vector3(0, 0, 0));
                break;
            case 1:
                initWall("right", position: new Vector2(12f, 0.25f), velocity: new Vector2(-3, 0), rotation: new Vector3(0, 0, 0));
                break;
            case 2:
                initWall("up", position: new Vector2(0, 7.45f), velocity: new Vector2(0, -3), rotation: new Vector3(0, 0, 90));
                break;
            case 3:
                initWall("down", position: new Vector2(0, -7.45f), velocity: new Vector2(0, 3), rotation: new Vector3(0, 0, 90));
                break;
        }
    }
    private void initWall(string sideToSpawn, Vector2 position, Vector2 velocity, Vector3 rotation)
    {
        transform.position = position;
        rb.velocity = velocity;
        positionToSpawn = sideToSpawn;
        transform.rotation = Quaternion.Euler(rotation);
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
