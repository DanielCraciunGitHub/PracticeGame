using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameFlow
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private TMP_Text count;

        private int _credits;
        private int _orbs;

        private void Start()
        {
            _credits = PlayerPrefs.GetInt("credits");
            _orbs = PlayerPrefs.GetInt("orbCount");

            text.text = _credits.ToString();
            count.text = $"Orb count: x{_orbs}\nCost: 120 credits";

        }
        public void OnClickReturn()
        {
            SceneManager.LoadScene("Menu");
        }

        public void OnClickBuy1(Button button)
        {
            var color = button.colors;
            if (_credits >= 120)
            {
                _credits -= 120;
                _orbs++;

                PlayerPrefs.SetInt("credits", _credits);
                PlayerPrefs.SetInt("orbCount", _orbs); 

                text.text = _credits.ToString(); 
                count.text = $"Orb count: x{_orbs}\nCost: 120 credits";

                color.pressedColor = Color.green;
                button.colors = color;
            }
            else
            {
                color.pressedColor = Color.red;
                button.colors = color;
            }
        }
    }
}
