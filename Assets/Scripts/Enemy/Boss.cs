using System.Collections;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] TMP_Text levelChangeText;
    [SerializeField] Animator animatorForLevelChange;
    [SerializeField] SpriteRenderer enemySprite;

    private SpriteRenderer[] bodyParts;
    private int level = 1;
    private bool keepSpawnBoss = true;
    
    void Awake()
    {
        bodyParts = enemySprite.GetComponentsInChildren<SpriteRenderer>();
    }
    IEnumerator Start()
    {
        while (keepSpawnBoss)
        {
            yield return new WaitForSeconds(5);
            spawnBoss();
            animatorForLevelChange.SetTrigger("isIncrease");
        }
    }
    void spawnBoss()
    {

        GameObject b1 = Instantiate(boss, EnemySpawner.randomSpawnLocation(), Quaternion.identity);

        b1.transform.localScale = new Vector2(1.2f, 1.2f); // makes the boss supersized

        if (EnemyController.enemySpeed < 4.0f && level < 15)
        {
            levelChangeText.text = $"Level {level.ToString()}";
            level++;

            animatorForLevelChange.SetTrigger("isIncrease");

            EnemyController.enemySpeed *= 1.1f;
        }
        else if (level == 15)
        {
            levelChangeText.text = $"Good luck surviving from here...";
            levelChangeText.color = Color.red;

            animatorForLevelChange.SetTrigger("isIncrease");

            enemySprite.color = Color.red;
            foreach (SpriteRenderer bodyPart in bodyParts)
            {
                bodyPart.color = Color.red;
            }
            EnemySpawner.spawnRate /= 1.5f;
            keepSpawnBoss = !keepSpawnBoss;
        }
    }
}