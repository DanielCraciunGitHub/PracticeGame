using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static float enemySpawnRate;

    [SerializeField] GameObject enemy;

    private int enemyCount = 0;
    
    IEnumerator Start()
    {
         enemySpawnRate = 0.5f;
         
         while(true)
         {
            yield return new WaitForSeconds(enemySpawnRate);
            enemy.SetActive(true);
            Instantiate (enemy, randomSpawnLocation(), Quaternion.identity);
         }
    }

    void spawnEnemy()
    {
        if (enemyCount < 24)
        {
            Instantiate(enemy, randomSpawnLocation(), Quaternion.identity);
            enemy.transform.localScale = new Vector2(0.3f, 0.3f);
            enemyCount++;
        }
    }    
    public void decrement()
    {
        enemyCount--;
    }
    public static Vector2 randomSpawnLocation()
    {
        float x = 0.0f; 
        float y = 0.0f;

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
        Vector2 location = new Vector2(x, y);
        return location;
    }
}
