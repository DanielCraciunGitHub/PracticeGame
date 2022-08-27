using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static float curHealth;
    static Slider healthBar;
    static float maxHealth = 100;

    void Start()
    {
        healthBar = FindObjectOfType<Slider>();

        curHealth = maxHealth;
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;        
    }
    public static void sendDamage(float damage) 
    {
        curHealth -= damage;
        healthBar.value = curHealth;
    }
}