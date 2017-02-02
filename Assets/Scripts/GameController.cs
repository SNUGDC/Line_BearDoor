﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
    
    public Text countdown;
    public Image pause_popup;
    public Button leavebutton;
    public Text scoreText;
    public Text gameoverText;
    public float score;
    public bool isStoped = false; //for Debugging
    public GameObject Bear;

    TestByMouse mouseTest;
    DoorSpawn doorspawn;
    TreeSpawn treespawn;
    RoadSpawn roadspawn;

    Scene currentscene;

    public static GameController Instance;

	void Start()
    {
        Instance = this;

        mouseTest = GetComponent<TestByMouse>();
        doorspawn = GetComponent<DoorSpawn>();
        treespawn = GetComponent<TreeSpawn>();
        roadspawn = GetComponent<RoadSpawn>();
        
        scoreText.text = "0";
        gameoverText.text = "0";

        currentscene = SceneManager.GetActiveScene();
        if (currentscene.name == "Game")
        {
            doorspawn.Initialize();
            StopWorld();
            StartCoroutine(Countdown());
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void OpenPopup()
	{
		StopWorld();
		Debug.Log("Open popup called");
	}

	public void ClosePopup()
    {
        StartCoroutine(Countdown());
        Debug.Log("Close popup called");
    }

    public IEnumerator Countdown()
    {
        int i = 3;
        float wait = 1.0f;

        mouseTest.swipeDirection = SwipeDirectionbyMouse.NONE;
        countdown.gameObject.SetActive(true);
        Bear.GetComponent<Animator>().enabled = false;
        while (i>0)
        {
            countdown.text = i.ToString();
            i--;
            yield return new WaitForRealSeconds(wait);
        }
        if (i == 0)
		{
			countdown.gameObject.SetActive(false);
            Bear.GetComponent<Animator>().enabled = true;
            ResumeWorld();
		}
	}

	void StopWorld()
	{
		mouseTest.enabled = false;
		doorspawn.enabled = false;
        treespawn.enabled = false;
        roadspawn.enabled = false;
		if (doorspawn.newDoor != null)
		{
			doorspawn.newDoor.GetComponent<DoorMover>().enabled = false;
        }
        if(GameObject.FindGameObjectsWithTag("Tree") != null)
        {
            GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
            for(int i=0; i < trees.Length; i++)
            {
                trees[i].GetComponent<TreeController>().enabled = false;
            }
        }
        isStoped = true;
	}

	void ResumeWorld()
	{
		mouseTest.enabled = true;
		doorspawn.enabled = true;
        treespawn.enabled = true;
        roadspawn.enabled = true;
        if (doorspawn.newDoor != null)
		{
			doorspawn.newDoor.GetComponent<DoorMover>().enabled = true;
        }
        if (GameObject.FindGameObjectsWithTag("Tree") != null)
        {
            GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i].GetComponent<TreeController>().enabled = true;
            }
        }
        isStoped = false;
	}
    
    public void AddScore()
    {
        if (DoorSpawn.Instance.newDoor.name == "LeftSwipeDoor(Clone)")
        {
            score += (DoorMover.Instance.DoorSpeed() * 100000 / 3) * 1;
        }
        else if (DoorSpawn.Instance.newDoor.name == "RightSwipeDoor(Clone)")
        {
            score += (DoorMover.Instance.DoorSpeed() * 100000 / 3) * 2;
        }
        else if (DoorSpawn.Instance.newDoor.name == "UpSwipeDoor(Clone)")
        {
            score += (DoorMover.Instance.DoorSpeed() * 100000 / 3) * 3;
        }
        else if (DoorSpawn.Instance.newDoor.name == "BlankSwipeDoor_Dummy(Clone)")
        {
            score += (DoorMover.Instance.DoorSpeed() * 100000 / 3) * 4;
        }
        // score += 1 ; 
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = " " + score;
        gameoverText.text = score.ToString();
        Debug.Log(score);
    }
}

public class WaitForRealSeconds : CustomYieldInstruction
{
    private float m_FinishTime;

    public WaitForRealSeconds(float seconds)
    {
        m_FinishTime = seconds + Time.realtimeSinceStartup;
    }

    public override bool keepWaiting
    {
        get
        {
            return m_FinishTime > Time.realtimeSinceStartup;
        }
    }
} // Additional WaitForSeconds Class by realtime