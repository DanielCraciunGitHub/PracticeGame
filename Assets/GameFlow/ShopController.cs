using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShopController : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] TMP_Text count;

    int credits;
    int orbs;

    void Start()
    {
        credits = PlayerPrefs.GetInt("credits");
        orbs = PlayerPrefs.GetInt("orbCount");

        text.text = credits.ToString();
        count.text = $"Orb count: x{orbs}\nCost: 120 credits";

    }
    public void onClickReturn()
    {
        SceneManager.LoadScene("Menu");
    }

    public void onClickBuy1(Button button) // handle orb buying [price = 120]
    {
        var color = button.colors;
        if (credits >= 120) // if rich enough
        {
            credits -= 120; // change quantitative values
            orbs++;

            PlayerPrefs.SetInt("credits", credits);
            PlayerPrefs.SetInt("orbCount", orbs); // store credits/orb values

            text.text = credits.ToString(); // display corresponding text
            count.text = $"Orb count: x{orbs}\nCost: 120 credits";

            color.pressedColor = Color.green; // change button colour depending on player credit
            button.colors = color;
        }
        else
        {
            color.pressedColor = Color.red;
            button.colors = color;
        }
    }
}
