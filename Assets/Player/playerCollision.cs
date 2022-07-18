using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    float curHealth;
    float maxHealth = 140;

    PlayerController player;
    public static int score;

    void Start()
    {
        player = GetComponent<PlayerController>();
        curHealth = maxHealth;
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;        
    }
    void OnCollisionEnter2D(Collision2D other) // for bullet-wall collisions, and bullet enemy collisions
    {
        if (other.collider.tag == "enemy") // if the player touches an enemy
        {
            if (curHealth == 0) // if the player dies
            {
                score = player.getScore();
                SceneManager.LoadScene("GameOver"); // load game over scene
            }
            else if ((Vector2)other.collider.gameObject.transform.localScale == new Vector2(1.2f, 1.2f)) // if the size of the enemy corresponds to the size of the boss
            {
                score = player.getScore();
                SceneManager.LoadScene("GameOver"); // load game over scene
            }
            else
            {
                sendDamage(20); // take 1/5 of damage
            }
        }
    }
    void sendDamage(float damage) // sends damage to the player upon collision with an enemy
    {
        curHealth -= damage;
        healthBar.value = curHealth;
    }
}
