using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject boss;

    void Start()
    {  
        InvokeRepeating("spawnBoss", 5, 7);   
    }
    void spawnBoss()
    {
        GameObject b1 = Instantiate(boss, EnemySpawner.spawnLocation(), Quaternion.identity); // spawns the boss game object

        b1.transform.localScale = new Vector2(1.2f, 1.2f); // makes the boss supersized

        if (EnemyController.speed < 4.5f)
        {
            EnemyController.speed *= 1.1f;
        }
    }
}