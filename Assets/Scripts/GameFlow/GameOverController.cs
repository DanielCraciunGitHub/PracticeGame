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
        if (playerCollision.score > PlayerPrefs.GetInt("highscore")) 
        {
            text.text = $"Your final score is: {playerCollision.score} (NEW HIGHSCORE)";
            PlayerPrefs.SetInt("highscore", playerCollision.score);

            int temp = playerCollision.score + PlayerPrefs.GetInt("credits"); // update cumulative score
            PlayerPrefs.SetInt("credits", temp);
        }
        else
        {
            text.text = $"Your final score is: {playerCollision.score}";

            int temp = playerCollision.score + PlayerPrefs.GetInt("credits"); // update cumulative score
            PlayerPrefs.SetInt("credits", temp);
            
        }
    }
    public void returnMenu() // upon clicking the return to menu button
    {
        SceneManager.LoadScene("Menu");
    }
}
