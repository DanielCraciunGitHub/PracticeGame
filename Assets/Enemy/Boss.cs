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

    void Start()
    {          
        bodyParts = enemy.GetComponentsInChildren<SpriteRenderer>();
        animator.SetTrigger("isIncrease");
        InvokeRepeating("spawnBoss", 5, 5);
        level++;   
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

            CancelInvoke(); // stop boss spawns
        }
    }
}