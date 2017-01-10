using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hunger : MonoBehaviour {

    public float hunger = 1000;
    public Image hungerbar;
    public Button restart_button;
    public Button home_button;
    public Button hunger_text;
    public GameObject gameover;
    public bool isHit = false;

    float nextTime = 0;
    float deltaTime = 1;

    public DoorSpawn doorSpawn;
    
    void Start()
    {
        DoorMover.hunger = GameObject.Find("GameController").GetComponent<Hunger>();
    }

    void Update()
    {
        if(doorSpawn.newDoor != null)
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + deltaTime;
                hunger -= 1;
                hungerbar.rectTransform.sizeDelta -= new Vector2(1.0f, 0) * 0.76f;
            }
        }

        hunger_text.onClick.RemoveAllListeners();
        hunger_text.onClick.AddListener(HungerOnClick);

        OnGameOver();
    }

    void OnGameOver()
    {
        if (hunger <= 0)
        {
            gameover.gameObject.SetActive(true);
            restart_button.onClick.RemoveAllListeners();
            restart_button.onClick.AddListener(RestartOnClick);
            home_button.onClick.RemoveAllListeners();
            home_button.onClick.AddListener(HomeOnClick);
        }
    }

    void RestartOnClick()
    {
        SceneManager.LoadScene("testScene");
    }

    void HomeOnClick()
    {

    }

    void HungerOnClick()
    {
        hunger = 0;
    }
}
