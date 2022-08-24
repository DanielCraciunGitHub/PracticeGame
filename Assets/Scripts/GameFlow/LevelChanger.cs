using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] TMP_Text levelChangeText;
    [SerializeField] Animator animatorForLevelChange;

    private bool keepChangeLevel = true;
    
    IEnumerator Start()
    {
        Statics.enemySpeed = 1.0f;
        Statics.currentLevel = 1;

        while (keepChangeLevel)
        {
            yield return new WaitForSeconds(5);

            if (!isLvl15())
            {
                increaseLevel();
            }
            else
            {
                showLvl15Text();
                keepChangeLevel = false;
            }
        }
    }

    void increaseLevel()
    {
        levelChangeText.text = $"Level {Statics.currentLevel.ToString()}";
        Statics.currentLevel++;

        animatorForLevelChange.SetTrigger("isIncrease");

        Statics.enemySpeed *= 1.1f;
    }

    public static bool isLvl15()
    {
         return Statics.currentLevel == 15;
    }
    void showLvl15Text()
    {
        levelChangeText.text = $"Good luck surviving from here...";
        levelChangeText.color = Color.red;
        animatorForLevelChange.SetTrigger("isIncrease");
    }
}
