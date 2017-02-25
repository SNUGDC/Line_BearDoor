using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    public Sprite[] BearImage;

    public GameObject RightArrow;
    public GameObject LeftArrow;
    public Image Bear;

    private int BearNumber = 0;

    private void Start()
    {
        LeftArrow.SetActive(false);
    }

    private void Update()
    {
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
}
