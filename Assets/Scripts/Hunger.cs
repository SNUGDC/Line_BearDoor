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
                if (GameObject.Find("LeftSwipeArrow") != null || GameObject.Find("RightSwipeArrow") != null || GameObject.Find("UpSwipeArrow") != null)
                {
                    Debug.Log("isHit");
                    hunger -= 100;
                    hungerbar.rectTransform.sizeDelta -= new Vector2(76, 0);
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
