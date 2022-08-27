using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelController : MonoBehaviour
{
    public static int currentLevel;
    
    [SerializeField] TMP_Text levelChangeText;
    [SerializeField] Animator animatorForLevelChange;

    private bool keepChangeLevel = true;
    
    IEnumerator Start()
    {
        PlayerChaser.chaseSpeed = 1.0f;
        currentLevel = 1;

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
        levelChangeText.text = $"Level {currentLevel}";
        currentLevel++;

        animatorForLevelChange.SetTrigger("isIncrease");

        PlayerChaser.chaseSpeed *= 1.1f;
    }
    void showLvl15Text()
    {
        levelChangeText.text = $"Good luck surviving from here...";
        levelChangeText.color = Color.red;
        animatorForLevelChange.SetTrigger("isIncrease");
    }
    public static bool isLvl15()
    {
        return currentLevel == 15;
    }
}
