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

    DoorSpawn doorSpawn;
    
    void Start()
    {
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
                GameController.Instance.currentLevel.Hunger -= HpLosePerSec * Time.deltaTime;
            }
        }
        if(doorSpawn.newDoor == null)
        {
            doorSpawn.SpawnWaves();
        }

        if(GameController.Instance.currentLevel.Hunger <= 0)
        {
            OnGameOver();
        }
        hungerbar.rectTransform.sizeDelta = new Vector2(GameController.Instance.currentLevel.Hunger, hungerbar.rectTransform.sizeDelta.y);
    }

    void OnGameOver()
    {
        gameover.gameObject.SetActive(true);
        GetComponent<GameController>().Bear.GetComponent<Animator>().enabled = false;
        GetComponent<RoadSpawn>().enabled = false;
        GetComponent<TreeSpawn>().enabled = false;
    }

    void RestartOnClick()
    {
        SceneManager.LoadScene("Game");
    }

    void HomeOnClick()
    {

    }
}
