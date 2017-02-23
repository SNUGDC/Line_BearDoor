using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public int[] BearPrice_Bb;
    public int[] BearPrice_H;

    public Text BlueberryText;
    public Text HoneyText;

    private int Blueberry;
    private int Honey;

    private void Update()
    {
        BlueberryText.text = HowMuchBlueberryHave().ToString();
        Blueberry = HowMuchBlueberryHave();
        HoneyText.text = HowMuchHoneyHave().ToString();
        Honey = HowMuchHoneyHave();
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

    public void CanBuy1stBearByBlueberry()
    {
        if (Blueberry >= BearPrice_Bb[0])
        {
            PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") - BearPrice_Bb[0]);
            Debug.Log("너는 첫번째 곰을 샀다!");
        }
        else
        {
            Debug.Log("너는 첫번째 곰을 사기에는 돈이 부족하다...");
        }
    }
}