using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public Sprite[] BearImage;

    public GameObject NotBuyBear;
    public GameObject RightArrow;
    public GameObject LeftArrow;
    public GameObject StartButton;
    public Image Bear;

    private int BearNumber = 0;

    private void Start()
    {
        LeftArrow.SetActive(false);
    }

    private void Update()
    {
        DidYouBuyThisBear();
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
    }

    public void IncreaseBearNumber()
    {
        RightArrow.SetActive(true);
        LeftArrow.SetActive(true);

        BearNumber = BearNumber + 1;

        Bear.sprite = BearImage[BearNumber];

        if (BearNumber == 3)
        {
            RightArrow.SetActive(false);
        }
    }

    public void DecreaseBearNumber()
    {
        RightArrow.SetActive(true);
        LeftArrow.SetActive(true);

        BearNumber = BearNumber - 1;

        Bear.sprite = BearImage[BearNumber];

        if (BearNumber == 0)
        {
            LeftArrow.SetActive(false);
        }
    }

    private void DidYouBuyThisBear()
    {
        switch (BearNumber)
        {
            case 0:
                NotBuyBear.SetActive(false);
                break;
            case 1:
                if (PlayerPrefs.GetString("Pink Bear") != "Bought")
                {
                    NotBuyBear.SetActive(true);
                    StartButton.SetActive(false);
                }
                else
                {
                    NotBuyBear.SetActive(false);
                    StartButton.SetActive(true);
                }
                break;
            case 2:
                if (PlayerPrefs.GetString("Angry Bear") != "Bought")
                {
                    NotBuyBear.SetActive(true);
                    StartButton.SetActive(false);
                }
                else
                {
                    NotBuyBear.SetActive(false);
                    StartButton.SetActive(true);
                }
                break;
            case 3:
                if (PlayerPrefs.GetString("Honey Bear") != "Bought")
                {
                    NotBuyBear.SetActive(true);
                    StartButton.SetActive(false);
                }
                else
                {
                    NotBuyBear.SetActive(false);
                    StartButton.SetActive(true);
                }
                break;
            default:
                Debug.Log("Something is Wrong");
                break;
        }
    }

    public void GameStart()
    {
        PlayerPrefs.SetInt("Bear Number", BearNumber);
        SceneManager.LoadScene("Game");
    }
}
