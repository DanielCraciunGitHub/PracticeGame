using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFlow
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private TMP_Text score;

        private void Start()
        {
            score.text = $"Your current high score is: {PlayerPrefs.GetInt("highscore")}";
        }
        public void OnClickPlay()
        {
            SceneManager.LoadScene("Game");
        }

        public void OnClickShop()
        {
            SceneManager.LoadScene("Shop");
        }
    }
}