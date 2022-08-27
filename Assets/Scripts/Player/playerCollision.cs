using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.collider.CompareTag("enemy")) 
        {
            if (HealthManager.curHealth == 0) 
            {
                SceneManager.LoadScene("GameOver"); 
            }
            else
            {
                HealthManager.sendDamage(20); 
            }
        }
        if (other.collider.CompareTag("boss")) 
        {
            SceneManager.LoadScene("GameOver"); 
        }
    }
}
