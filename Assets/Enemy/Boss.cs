using System.Collections;
using UnityEngine;
using TMPro;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] TMP_Text text;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer enemy;

    SpriteRenderer[] bodyParts;

    int level = 1;
    bool spawnboss = true;

    IEnumerator Start()
    {          
        bodyParts = enemy.GetComponentsInChildren<SpriteRenderer>();
        while (spawnboss) // as long as the bosses should spawn
        {
            yield return new WaitForSeconds(5); // spawn a boss every 5 seconds
            spawnBoss();
            animator.SetTrigger("isIncrease"); // play level animation
        }   
    }
    void spawnBoss()
    {

        GameObject b1 = Instantiate(boss, EnemySpawner.spawnLocation(), Quaternion.identity); // spawns the boss game object

        b1.transform.localScale = new Vector2(1.2f, 1.2f); // makes the boss supersized

        if (EnemyController.speed < 4.0f && level < 15)
        {
            text.text = $"Level {level.ToString()}"; // show the user their current level
            level++;   

            animator.SetTrigger("isIncrease");

            EnemyController.speed *= 1.1f;  
        }
        else if (level == 15)
        {
            text.text = $"Good luck surviving from here...";
            text.color = Color.red;
            
            animator.SetTrigger("isIncrease");
            
            enemy.color = Color.red;
            foreach (var child in bodyParts) // change the colour of the enemies to red
            {
                child.color = Color.red;
            }
            EnemySpawner.spawnRate /= 1.5f; 
            spawnboss = !spawnboss;
        }
    }
}