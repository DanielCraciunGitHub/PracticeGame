using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    float curHealth;
    float maxHealth = 100;

    void Start()
    {
        curHealth = maxHealth;
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;        
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.collider.CompareTag("enemy")) 
        {
            if (curHealth == 0) 
            {
                SceneManager.LoadScene("GameOver"); 
            }
            else
            {
                sendDamage(20); 
            }
        }
        
        if (other.collider.CompareTag("boss")) 
        {
            SceneManager.LoadScene("GameOver"); 
        }
    }
    void sendDamage(float damage) 
    {
        curHealth -= damage;
        healthBar.value = curHealth;
    }
}
