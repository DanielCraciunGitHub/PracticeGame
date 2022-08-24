using System.Collections;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject boss;

    private bool keepSpawnBoss = true;

    IEnumerator Start()
    {
        while (keepSpawnBoss)
        {
            yield return new WaitForSeconds(5);

            if (LevelController.isLvl15())
            {
                keepSpawnBoss = false;
            }
            else
            {
                createBoss();
            }
        }
    }

    void createBoss()
    {
        GameObject bossClone = Instantiate(boss, EnemySpawner.randomSpawnLocation(), Quaternion.identity);
        superSize(bossClone);
    }

    void superSize(GameObject boss)
    {
        boss.transform.localScale = new Vector2(1.2f, 1.2f);
    }
}