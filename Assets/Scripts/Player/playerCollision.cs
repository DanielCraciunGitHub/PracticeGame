using GameFlow;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("enemy"))
            {
                if (HealthManager.curHealth == 0)
                    SceneManager.LoadScene("GameOver");
                else
                    HealthManager.SendDamage(20);
            }
            if (other.collider.CompareTag("boss")) 
                SceneManager.LoadScene("GameOver");
        }
    }
}
