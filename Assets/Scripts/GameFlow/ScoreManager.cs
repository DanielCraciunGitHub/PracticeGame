using TMPro;
using UnityEngine;

namespace GameFlow
{
    public class ScoreManager : MonoBehaviour
    {

        public static int playerScore;

        [SerializeField] private TMP_Text orbCountText;
        [SerializeField] private TMP_Text scoreText;


        private void Start()
        {
            playerScore = 0;
        }

        private void Update()
        {
            scoreText.text = $"Score: {playerScore}";
            orbCountText.text = $"Orbs: x{PlayerPrefs.GetInt("orbCount")}";
        }
        public static void DecrementOrbCount()
        {
            int orbs = PlayerPrefs.GetInt("orbCount") - 1;
            PlayerPrefs.SetInt("orbCount", orbs);
        }
    }
}
