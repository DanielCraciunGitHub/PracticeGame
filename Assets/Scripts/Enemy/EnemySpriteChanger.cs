using System.Collections;
using GameFlow;
using UnityEngine;

namespace Enemy
{
    public class EnemySpriteChanger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer enemySprite;
    
        private SpriteRenderer[] _enemySpriteBodyParts;
    
        private void Awake()
        {
            _enemySpriteBodyParts = enemySprite.GetComponentsInChildren<SpriteRenderer>();
        }

        private IEnumerator Start()
        {
            while (!LevelController.IsLvl15())
            {
                yield return null;
            }
            ChangeEnemyColor();
        }

        private void ChangeEnemyColor()
        {
            enemySprite.color = Color.red;
            foreach (SpriteRenderer bodyPart in _enemySpriteBodyParts)
            {
                bodyPart.color = Color.red;
            }
        }
    }
}