using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hunger : MonoBehaviour {
    
    public Image hungerbar;
    public Button restart_button;
    public Button home_button;
    public Button hunger_text;
    public GameObject gameover;
    public float HpLosePerSec;

    private int BearNumber;

    DoorSpawn doorSpawn;
    
    void Start()
    {
        BearNumber = PlayerPrefs.GetInt("Bear Number");
        doorSpawn = GetComponent<DoorSpawn>();
		restart_button.onClick.AddListener(RestartOnClick);
		home_button.onClick.AddListener(HomeOnClick);
    }

    void Update()
    {
        if(doorSpawn.newDoor != null)
        {
            if (GetComponent<GameController>().isStoped == false)
            {
                GameController.Instance.currentLevel.hungerPoint -= HpLosePerSec * Time.deltaTime;
            }
        }
        if(doorSpawn.newDoor == null)
        {
            doorSpawn.SpawnWaves();
        }

        if(GameController.Instance.currentLevel.hungerPoint <= 0)
        {
            OnGameOver();
        }
        hungerbar.rectTransform.sizeDelta = new Vector2(GameController.Instance.currentLevel.hungerPoint, hungerbar.rectTransform.sizeDelta.y);
    }

    void OnGameOver()
    {
        gameover.gameObject.SetActive(true);
        GetComponent<GameController>().Bear[BearNumber].GetComponent<Animator>().enabled = false;
        GetComponent<RoadSpawn>().enabled = false;
        GetComponent<TreeSpawn>().enabled = false;
    }

    void RestartOnClick()
    {
        SceneManager.LoadScene("Game");

        float score = GetComponent<GameController>().score;
        PlayerPrefs.SetInt("Blueberry", PlayerPrefs.GetInt("Blueberry") + ((int)score / 100));
    }

    void HomeOnClick()
    {

    }
}
