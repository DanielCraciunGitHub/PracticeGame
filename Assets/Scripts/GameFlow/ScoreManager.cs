using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int playerScore;

    [SerializeField] TMP_Text orbCountText;
    [SerializeField] TMP_Text scoreText;
    

    void Start()
    {
        playerScore = 0;
    }

    void Update()
    {
        scoreText.text = $"Score: {playerScore}";
        orbCountText.text = $"Orbs: x{PlayerPrefs.GetInt("orbCount")}";
    }
    public static void decrementOrbCount()
    {
        int orbs = PlayerPrefs.GetInt("orbCount") - 1;
        PlayerPrefs.SetInt("orbCount", orbs);
    }
}
