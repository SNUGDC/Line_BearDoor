using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") + 1000);
    }

    public void CheatHoney()
    {
        PlayerPrefs.SetInt("Honey", PlayerPrefs.GetInt("Honey") + 100);
    }

    public void CanBuyPinkBearByBlueberry()
    {
        if (PlayerPrefs.GetString("Pink Bear") != "Bought")
        {
            if (Blueberry >= BearPrice_Bb[0])
            {
                PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") - BearPrice_Bb[0]);
                PlayerPrefs.SetString("Pink Bear", "Bought");
                Debug.Log("너는 핑꾸곰을 블루베리로 샀다!");
            }
            else
            {
                Debug.Log("너는 핑꾸곰을 사기에는 블루베리가 부족하다...");
            }
        }
        else
        {
            Debug.Log("이미 길들인 곰이다.");
        }
    }

    public void CanBuyPinkBearByHoney()
    {
        if (PlayerPrefs.GetString("Pink Bear") != "Bought")
        {
            if (Honey >= BearPrice_H[0])
            {
                PlayerPrefs.SetInt("Honey", PlayerPrefs.GetInt("Honey") - BearPrice_H[0]);
                PlayerPrefs.SetString("Pink Bear", "Bought");
                Debug.Log("너는 핑꾸곰을 꿀로 샀다!");
            }
            else
            {
                Debug.Log("너는 핑꾸곰을 사기에는 꿀이 부족하다...");
            }
        }
        else
        {
            Debug.Log("이미 길들인 곰이다.");
        }
    }

    public void CanBuyAngryBearByBlueberry()
    {
        if (PlayerPrefs.GetString("Angry Bear") != "Bought")
        {
            if (Blueberry >= BearPrice_Bb[1])
            {
                PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") - BearPrice_Bb[1]);
                PlayerPrefs.SetString("Angry Bear", "Bought");
                Debug.Log("너는 화난곰을 블루베리로 샀다!");
            }
            else
            {
                Debug.Log("너는 화난곰을 사기에는 블루베리가 부족하다...");
            }
        }
        else
        {
            Debug.Log("이미 길들인 곰이다.");
        }
    }

    public void CanBuyAngryBearByHoney()
    {
        if (PlayerPrefs.GetString("Angry Bear") != "Bought")
        {
            if (Honey >= BearPrice_H[1])
            {
                PlayerPrefs.SetInt("Honey", PlayerPrefs.GetInt("Honey") - BearPrice_H[1]);
                PlayerPrefs.SetString("Angry Bear", "Bought");
                Debug.Log("너는 화난곰을 꿀로 샀다!");
            }
            else
            {
                Debug.Log("너는 화난곰을 사기에는 꿀이 부족하다...");
            }
        }
        else
        {
            Debug.Log("이미 길들인 곰이다.");
        }
    }

    public void CanBuyHoneyBearByBlueberry()
    {
        if (PlayerPrefs.GetString("Honey Bear") != "Bought")
        {
            if (Blueberry >= BearPrice_Bb[2])
            {
                PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") - BearPrice_Bb[2]);
                PlayerPrefs.SetString("Honey Bear", "Bought");
                Debug.Log("너는 허니곰을 블루베리로 샀다!");
            }
            else
            {
                Debug.Log("너는 허니곰을 사기에는 블루베리가 부족하다...");
            }
        }
        else
        {
            Debug.Log("이미 길들인 곰이다.");
        }
    }

    public void CanBuyHoneyBearByHoney()
    {
        if (PlayerPrefs.GetString("Honey Bear") != "Bought")
        {
            if (Honey >= BearPrice_H[2])
            {
                PlayerPrefs.SetInt("Honey", PlayerPrefs.GetInt("Honey") - BearPrice_H[2]);
                PlayerPrefs.SetString("Honey Bear", "Bought");
                Debug.Log("너는 허니곰을 꿀로 샀다!");
            }
            else
            {
                Debug.Log("너는 허니곰을 사기에는 꿀이 부족하다...");
            }
        }
        else
        {
            Debug.Log("이미 길들인 곰이다.");
        }
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("Start");
    }
}