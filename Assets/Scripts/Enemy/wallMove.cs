using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wallMove : MonoBehaviour
{
    struct wallDetails
    {
        public Rigidbody2D rb;
        public BoxCollider2D boxCol;
        public Transform wallTransform;
        public Vector3 wallStartPos;
    }
    wallDetails wall = new wallDetails();

    string positionToSpawn = string.Empty;
    void Awake()
    {
        wall.rb = GetComponent<Rigidbody2D>();
        wall.boxCol = GetComponent<BoxCollider2D>();
        cacheTransform();
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
                stopWall(position: wall.wallTransform.position.x, stoppingPos: -0.01f); 
                break;
            case "left":          
                stopWall(position: wall.wallTransform.position.x, stoppingPos: 0.01f); 
                break;
            case "up":
                stopWall(position: wall.wallTransform.position.y, stoppingPos: -0.01f);
                break;
            case "down":
                stopWall(position: wall.wallTransform.position.y, stoppingPos: 0.01f); 
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
        wall.wallTransform.position = position;
        wall.rb.velocity = velocity;
        positionToSpawn = sideToSpawn;
        wall.wallTransform.rotation = Quaternion.Euler(rotation);
    }
    private void stopWall(float position, float stoppingPos)
    {
        if (stoppingPos < 0)
        {
            if (position < stoppingPos) wall.rb.velocity = Vector2.zero;
        }
        else
        {
            if (position > stoppingPos) wall.rb.velocity = Vector2.zero;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("wall"))
        {
            Physics2D.IgnoreCollision(other.collider, wall.boxCol);
        }
        else if (other.collider.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
        }
    }
    void cacheTransform()
    {
        wall.wallTransform = transform;
    }
}
