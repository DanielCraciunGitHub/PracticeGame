using System.Collections;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] SpriteRenderer enemySprite;
    
    private SpriteRenderer[] enemySpriteBodyParts;
    private bool keepSpawnBoss = true;

    IEnumerator Start()
    {
        enemySpriteBodyParts = enemySprite.GetComponentsInChildren<SpriteRenderer>();
        while (keepSpawnBoss)
        {
            yield return new WaitForSeconds(5);

            if (LevelChanger.isLvl15())
            {
                createSuperEnemies();
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
        if (LevelChanger.isLvl15())
        {
            createSuperEnemies();
        }
        else
        {
            GameObject bossClone = Instantiate(boss, Statics.randomSpawnLocation(), Quaternion.identity);
            superSize(bossClone);
        }
    }

    void superSize(GameObject boss)
    {
        boss.transform.localScale = new Vector2(1.2f, 1.2f);
    }

    void createSuperEnemies()
    {
        enemySprite.color = Color.red;
        foreach (SpriteRenderer bodyPart in enemySpriteBodyParts)
        {
            bodyPart.color = Color.red;
        }
        Statics.enemySpawnRate /= 1.5f;
    }
}