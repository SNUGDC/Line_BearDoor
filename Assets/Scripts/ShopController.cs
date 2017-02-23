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
            Debug.Log("너는 첫번째 곰을 블루베리로 샀다!");
        }
        else
        {
            Debug.Log("너는 첫번째 곰을 사기에는 블루베리가 부족하다...");
        }
    }

    public void CanBuy1stBearByHoney()
    {
        if (Honey >= BearPrice_H[0])
        {
            PlayerPrefs.SetInt("Honey", PlayerPrefs.GetInt("Honey") - BearPrice_H[0]);
            Debug.Log("너는 첫번째 곰을 꿀로 샀다!");
        }
        else
        {
            Debug.Log("너는 첫번째 곰을 사기에는 꿀이 부족하다...");
        }
    }

    public void CanBuy2stBearByBlueberry()
    {
        if (Blueberry >= BearPrice_Bb[1])
        {
            PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") - BearPrice_Bb[1]);
            Debug.Log("너는 두번째 곰을 블루베리로 샀다!");
        }
        else
        {
            Debug.Log("너는 두번째 곰을 사기에는 블루베리가 부족하다...");
        }
    }

    public void CanBuy2stBearByHoney()
    {
        if (Honey >= BearPrice_H[1])
        {
            PlayerPrefs.SetInt("Honey", PlayerPrefs.GetInt("Honey") - BearPrice_H[1]);
            Debug.Log("너는 두번째 곰을 꿀로 샀다!");
        }
        else
        {
            Debug.Log("너는 두번째 곰을 사기에는 꿀이 부족하다...");
        }
    }

    public void CanBuy3stBearByBlueberry()
    {
        if (Blueberry >= BearPrice_Bb[2])
        {
            PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") - BearPrice_Bb[2]);
            Debug.Log("너는 세번째 곰을 블루베리로 샀다!");
        }
        else
        {
            Debug.Log("너는 세번째 곰을 사기에는 블루베리가 부족하다...");
        }
    }

    public void CanBuy3stBearByHoney()
    {
        if (Honey >= BearPrice_H[2])
        {
            PlayerPrefs.SetInt("Honey", PlayerPrefs.GetInt("Honey") - BearPrice_H[2]);
            Debug.Log("너는 세번째 곰을 꿀로 샀다!");
        }
        else
        {
            Debug.Log("너는 세번째 곰을 사기에는 꿀이 부족하다...");
        }
    }

    public void CanBuyBear(int WhatBear, int BlueberryPrice, bool IsBlueberry)
    {
        switch (WhatBear)
        {
            case 1:
                if (IsBlueberry)
                {
                    if (Blueberry >= BlueberryPrice)
                    {
                        PlayerPrefs.SetInt("Blueberry", Blueberry - BlueberryPrice);
                    }
                }
                else
                {
                    if (Honey >= BlueberryPrice / 20)
                    {
                        PlayerPrefs.SetInt("Honey", Honey - BlueberryPrice / 20);
                    }
                }
                break;
            case 2:
                if (IsBlueberry)
                {
                    if (Blueberry >= BlueberryPrice)
                    {
                        PlayerPrefs.SetInt("Blueberry", Blueberry - BlueberryPrice);
                    }
                }
                else
                {
                    if (Honey >= BlueberryPrice / 20)
                    {
                        PlayerPrefs.SetInt("Honey", Honey - BlueberryPrice / 20);
                    }
                }
                break;
            case 3:
                if (IsBlueberry)
                {
                    if (Blueberry >= BlueberryPrice)
                    {
                        PlayerPrefs.SetInt("Blueberry", Blueberry - BlueberryPrice);
                    }
                }
                else
                {
                    if (Honey >= BlueberryPrice / 20)
                    {
                        PlayerPrefs.SetInt("Honey", Honey - BlueberryPrice / 20);
                    }
                }
                break;
            default:
                Debug.Log("Something wrong with buying Bear");
                break;
        }
    }
}