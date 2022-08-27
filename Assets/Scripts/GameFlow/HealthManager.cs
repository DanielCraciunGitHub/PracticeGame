using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    static Slider healthBar;
    static float maxHealth = 100;
    public static float curHealth;

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