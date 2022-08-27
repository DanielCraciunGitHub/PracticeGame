using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    // simply gets the current score and displays it
    void Start()
    {        
        // if the players score is their new highscore
        if (ScoreManager.playerScore > PlayerPrefs.GetInt("highscore")) 
        {
            text.text = $"Your final score is: {ScoreManager.playerScore} (NEW HIGHSCORE)";
            PlayerPrefs.SetInt("highscore", ScoreManager.playerScore);

            int temp = ScoreManager.playerScore + PlayerPrefs.GetInt("credits"); // update cumulative score
            PlayerPrefs.SetInt("credits", temp);
        }
        else
        {
            text.text = $"Your final score is: {ScoreManager.playerScore}";

            int temp = ScoreManager.playerScore + PlayerPrefs.GetInt("credits"); // update cumulative score
            PlayerPrefs.SetInt("credits", temp);
            
        }
    }
    public void returnMenu() // upon clicking the return to menu button
    {
        SceneManager.LoadScene("Menu");
    }
}
