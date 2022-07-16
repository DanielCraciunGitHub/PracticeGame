using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text score; // serialized to allow use of TMP object
    void Start()
    {
        score.enabled = false; // initially disables the score text
    }
    public void onClickPlay()
    {
        // loads the game
        SceneManager.LoadScene("Game");
    }

    public void onClickHighScore()
    {
        // retrieves the current high score from internal storage, and displays it
        float highScore = PlayerPrefs.GetInt("highscore");
        displayScore();
    }
    private void displayScore()
    {
        // displays the text
        score.enabled = true;
        score.text = $"Your current high score is: {PlayerPrefs.GetInt("highscore")}";
    }
}
