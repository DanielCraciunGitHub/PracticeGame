using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    private int enemyCount = 0;
    
    IEnumerator Start()
    {
         Statics.enemySpawnRate = 0.5f;
         
         while(true)
         {
            yield return new WaitForSeconds(Statics.enemySpawnRate);
            enemy.SetActive(true);
            Instantiate (enemy, Statics.randomSpawnLocation(), Quaternion.identity);
         }
    }

    void spawnEnemy()
    {
        if (enemyCount < 24)
        {
            Instantiate(enemy, Statics.randomSpawnLocation(), Quaternion.identity);
            enemy.transform.localScale = new Vector2(0.3f, 0.3f);
            enemyCount++;
        }
    }    
    public void decrement()
    {
        enemyCount--;
    }
}
