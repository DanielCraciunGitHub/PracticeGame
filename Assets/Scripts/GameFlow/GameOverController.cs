using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFlow
{
    public class GameOverController : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private void Start()
        {
            if (ScoreManager.playerScore > PlayerPrefs.GetInt("highscore")) 
            {
                text.text = $"Your final score is: {ScoreManager.playerScore} (NEW HIGHSCORE)";
                PlayerPrefs.SetInt("highscore", ScoreManager.playerScore);

                int temp = ScoreManager.playerScore + PlayerPrefs.GetInt("credits");
                PlayerPrefs.SetInt("credits", temp);
            }
            else
            {
                text.text = $"Your final score is: {ScoreManager.playerScore}";

                int temp = ScoreManager.playerScore + PlayerPrefs.GetInt("credits");
                PlayerPrefs.SetInt("credits", temp);
            
            }
        }
        public void ReturnMenu() 
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
