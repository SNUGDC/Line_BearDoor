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
    public Text game_over_text;
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
                hungerbar.rectTransform.sizeDelta -= new Vector2(0.4f, 0);
                /*if (isHit == true)
                {
                    hunger -= 100;
                    hungerbar.rectTransform.sizeDelta -= new Vector2(40, 0);
                }*/
            }
        }

        if(hunger <= 0)
        {
            StopCoroutine(doorSpawn.coroutine);
            restart_button.gameObject.SetActive(true);
            home_button.gameObject.SetActive(true);
            game_over_text.gameObject.SetActive(true);
            restart_button.onClick.AddListener(RestartOnClick);
            home_button.onClick.AddListener(HomeOnClick);
        }
        hunger_text.onClick.AddListener(HungerOnClick);
    }

    void RestartOnClick()
    {
        doorSpawn.scoreText.text = "Score: ";
        doorSpawn.score = 0;
        hunger = 1000;
        hungerbar.rectTransform.sizeDelta = new Vector2(400, 12.5f);
        restart_button.gameObject.SetActive(false);
        home_button.gameObject.SetActive(false);
        game_over_text.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void HomeOnClick()
    {

    }

    void HungerOnClick()
    {
        hunger = 0;
    }
}
