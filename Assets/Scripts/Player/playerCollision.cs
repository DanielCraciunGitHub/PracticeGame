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

    PlayerController player;
    public static int score;

    void Start()
    {
        player = GetComponent<PlayerController>();
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
                score = player.getScore();
                SceneManager.LoadScene("GameOver"); 
            }
            else if ((Vector2)other.collider.gameObject.transform.localScale == new Vector2(1.2f, 1.2f)) 
            {
                score = player.getScore();
                SceneManager.LoadScene("GameOver"); 
            }
            else
            {
                sendDamage(20); 
            }
        }
    }
    void sendDamage(float damage) 
    {
        curHealth -= damage;
        healthBar.value = curHealth;
    }
}
