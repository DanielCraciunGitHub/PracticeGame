using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class WallMove : MonoBehaviour
    {
        private struct WallDetails
        {
            public Rigidbody2D rb;
            public BoxCollider2D boxCol;
            public Transform wallTransform;
            public Vector3 wallStartPos;
        }

        private WallDetails _wall;

        private string _positionToSpawn = string.Empty;

        private void Awake()
        {
            _wall.rb = GetComponent<Rigidbody2D>();
            _wall.boxCol = GetComponent<BoxCollider2D>();
            CacheTransform();
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(8.5f);
                SpawnWall();
            }
        }

        private void Update()
        {
            CheckWallLocation();
        }
        private void CheckWallLocation()
        {
            switch (_positionToSpawn)
            {
                case "right":
                    StopWall(position: _wall.wallTransform.position.x, stoppingPos: -0.01f); 
                    break;
                case "left":          
                    StopWall(position: _wall.wallTransform.position.x, stoppingPos: 0.01f); 
                    break;
                case "up":
                    StopWall(position: _wall.wallTransform.position.y, stoppingPos: -0.01f);
                    break;
                case "down":
                    StopWall(position: _wall.wallTransform.position.y, stoppingPos: 0.01f); 
                    break;

            }
        }

        private void SpawnWall()
        {
            int sideToSpawn = Random.Range(0, 4);

            switch (sideToSpawn)
            {
                case 0:
                    InitWall("left", position: new Vector2(-12f, -0.25f), velocity: new Vector2(3, 0), rotation: new Vector3(0, 0, 0));
                    break;
                case 1:
                    InitWall("right", position: new Vector2(12f, 0.25f), velocity: new Vector2(-3, 0), rotation: new Vector3(0, 0, 0));
                    break;
                case 2:
                    InitWall("up", position: new Vector2(0, 7.45f), velocity: new Vector2(0, -3), rotation: new Vector3(0, 0, 90));
                    break;
                case 3:
                    InitWall("down", position: new Vector2(0, -7.45f), velocity: new Vector2(0, 3), rotation: new Vector3(0, 0, 90));
                    break;
            }
        }
        private void InitWall(string sideToSpawn, Vector2 position, Vector2 velocity, Vector3 rotation)
        {
            _wall.wallTransform.position = position;
            _wall.rb.velocity = velocity;
            _positionToSpawn = sideToSpawn;
            _wall.wallTransform.rotation = Quaternion.Euler(rotation);
        }
        private void StopWall(float position, float stoppingPos)
        {
            if (stoppingPos < 0)
            {
                if (position < stoppingPos) _wall.rb.velocity = Vector2.zero;
            }
            else
            {
                if (position > stoppingPos) _wall.rb.velocity = Vector2.zero;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("wall"))
            {
                Physics2D.IgnoreCollision(other.collider, _wall.boxCol);
            }
            else if (other.collider.CompareTag("bullet"))
            {
                Destroy(other.gameObject);
            }
        }

        private void CacheTransform()
        {
            _wall.wallTransform = transform;
        }
    }
}
