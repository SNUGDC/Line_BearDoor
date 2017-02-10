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

    float nextTime = 0;
    float deltaTime = 1;

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
                if (Time.time > nextTime)
                {
                    nextTime = Time.time + deltaTime;
                    hunger -= 1;
                    hungerbar.rectTransform.sizeDelta -= new Vector2(1.0f, 0) * 0.76f;
                }
            }

            if (doorSpawn.newDoor.transform.localScale.x >= 0.3f && doorSpawn.newDoor.transform.localScale.y >= 0.3f && doorSpawn.newDoor.transform.localScale.z >= 1.0f)
            {
                if (GameObject.Find("LeftSwipeArrow") != null || GameObject.Find("RightSwipeArrow") != null || GameObject.Find("UpSwipeArrow") != null 
                    && DoorSpawn.Instance.newDoor.name != "BlankSwipeDoor_Dummy(Clone)")
                {
                    Debug.Log("isHit");
                    hunger -= 100;
                    hungerbar.rectTransform.sizeDelta -= new Vector2(76, 0);
                    doorSpawn.combo = 0;
                }
                if (doorSpawn.newDoor.name == "BlankSwipeDoor_Dummy(Clone)" && GameObject.Find("BlankDoorFlag") != null)
                {
                    GameController.Instance.AddScore();
                }
                Destroy(doorSpawn.newDoor);
                DoorSpawn.Instance.SpawnWaves();
            }
        }

        OnGameOver();
    }

    void OnGameOver()
    {
        if (hunger <= 0)
        {
            gameover.gameObject.SetActive(true);
            GetComponent<GameController>().Bear.GetComponent<Animator>().enabled = false;
            GetComponent<RoadSpawn>().enabled = false;
            GetComponent<TreeSpawn>().enabled = false;
        }
    }

    void RestartOnClick()
    {
        SceneManager.LoadScene("Game");
    }

    void HomeOnClick()
    {

    }
}
