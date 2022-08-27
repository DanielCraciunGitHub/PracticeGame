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
        score.text = $"Your current high score is: {PlayerPrefs.GetInt("highscore")}"; // displays the current highscore
    }
    public void onClickPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void onClickShop()
    {
        SceneManager.LoadScene("Shop");
    }
}