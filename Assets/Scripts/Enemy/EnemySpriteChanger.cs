using UnityEngine;
using System.Collections;

public class EnemySpriteChanger : MonoBehaviour
{
    [SerializeField] SpriteRenderer enemySprite;
    private SpriteRenderer[] enemySpriteBodyParts;
    
    void Awake()
    {
        enemySpriteBodyParts = enemySprite.GetComponentsInChildren<SpriteRenderer>();
    }

    IEnumerator Start()
    {
        while (!LevelController.isLvl15())
        {
            yield return null;
        }
        changeEnemyColor();

    }

    public void changeEnemyColor()
    {
        enemySprite.color = Color.red;
        foreach (SpriteRenderer bodyPart in enemySpriteBodyParts)
        {
            bodyPart.color = Color.red;
        }
    }
}