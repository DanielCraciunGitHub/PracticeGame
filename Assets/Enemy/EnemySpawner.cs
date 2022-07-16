using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy; // holds the enemy object, can be respawned etc.
    int enemyCount = 0;
    
    void Start()
    {
        enemy.SetActive(true); // enables the game object
        InvokeRepeating("spawnEnemy", 1, 0.5f); // spawns an enemy at a given location after 1 second, repeating every other 2 seconds.
    }
    void spawnEnemy()
    {
        if (enemyCount < 24)
        {
            Instantiate(enemy, spawnLocation(), Quaternion.identity); // spawns the enemy at a random location on the edge of the map
            enemy.transform.localScale = new Vector2(0.3f, 0.3f);
            enemyCount++;
        }
    }
    public static Vector2 spawnLocation() // [-6,5] in the y direction // [-11, 11] in the x direction
    {
        float x = 0.0f;
        float y = 0.0f;
        // decides whether to spawn enemy on the left, right, up or down
        switch(Random.Range(0,4))
        {
            case 0: // left
                x = -12.0f;
                y = Random.Range(-6.0f, 5.0f);
                break;
            case 1: // right
                x = 12.0f;
                y = Random.Range(-6.0f, 5.0f);
                break;
            case 2: // up
                x = Random.Range(-11.0f, 11.0f);
                y = 6.0f;
                break;
            case 3: // down
                x = Random.Range(-11.0f, 11.0f);
                y = -6.0f;
                break;
        }
        Vector2 location = new Vector2(x, y); // creates the vector for the current enemy object instantiated
        return location;
    }
    public void decrement()
    {
        enemyCount--;
    }
}
