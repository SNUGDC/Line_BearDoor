using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public Text BlueberryText;
    public Text HoneyText;

    private void Update()
    {
        BlueberryText.text = HowMuchBlueberryHave().ToString();
        HoneyText.text = HowMuchHoneyHave().ToString();
    }

    private int HowMuchBlueberryHave()
    {
        if (!PlayerPrefs.HasKey("Blueberry"))
        {
            PlayerPrefs.SetInt("Blueberry", 0);
        }

        return PlayerPrefs.GetInt("Blueberry");
    }

    private int HowMuchHoneyHave()
    {
        if (!PlayerPrefs.HasKey("Honey"))
        {
            PlayerPrefs.SetInt("Honey", 0);
        }

        return PlayerPrefs.GetInt("Honey");
    }

    public void CheatBlueberry()
    {
        PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") + 100);
    }

    public void CheatHoney()
    {
        PlayerPrefs.SetInt("Honey", PlayerPrefs.GetInt("Honey") + 100);
    }

    public void TryToBuy1stBearByBlueberry()
    {

    }
}