using UnityEngine;
using UnityEngine.UI;

namespace GameFlow
{
    public class HealthManager : MonoBehaviour
    {
        private const float MaxHealth = 100;
        private static Slider _healthBar;
        public static float curHealth;
        private void Start()
        {
            _healthBar = FindObjectOfType<Slider>();

            curHealth = MaxHealth;
            _healthBar.value = curHealth;
            _healthBar.maxValue = MaxHealth;        
        }

        public static void SendDamage(float damage) 
        {
            curHealth -= damage;
            _healthBar.value = curHealth;
        }
    }
}