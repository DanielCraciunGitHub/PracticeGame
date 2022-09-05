using System.Collections;
using Packages.PlayerChasing;
using TMPro;
using UnityEngine;

namespace GameFlow
{
    public class LevelController : MonoBehaviour
    {
        private static int _currentLevel;
    
        [SerializeField] private TMP_Text levelChangeText;
        [SerializeField] private Animator animatorForLevelChange;

        private bool _keepChangeLevel = true;
        private static readonly int IsIncrease = Animator.StringToHash("isIncrease");

        private IEnumerator Start()
        {
            PlayerChaser.chaseSpeed = 1.0f;
            _currentLevel = 1;

            while (_keepChangeLevel)
            {
                yield return new WaitForSeconds(5);

                if (!IsLvl15())
                {
                    IncreaseLevel();
                }
                else
                {
                    ShowLvl15Text();
                    _keepChangeLevel = false;
                }
            }
        }

        private void IncreaseLevel()
        {
            levelChangeText.text = $"Level {_currentLevel}";
            _currentLevel++;

            animatorForLevelChange.SetTrigger(IsIncrease);

            PlayerChaser.chaseSpeed *= 1.1f;
        }

        private void ShowLvl15Text()
        {
            levelChangeText.text = $"Good luck surviving from here...";
            levelChangeText.color = Color.red;
            animatorForLevelChange.SetTrigger(IsIncrease);
        }
        public static bool IsLvl15()
        {
            return _currentLevel == 15;
        }
    }
}
