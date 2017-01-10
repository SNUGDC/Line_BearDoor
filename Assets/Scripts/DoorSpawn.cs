﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSpawn : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject upDoor;
    public GameObject newDoor;

    public int score;
    public bool isCorrect;
    public Text scoreText;
    public Text gameoverText;

    public TestByMouse swipe;
    public Hunger hg;
    public DoorMover doorMover;
    public IEnumerator coroutine;

    void Start() {
        DoorMover.doorSpawn = gameObject.GetComponent<DoorSpawn>();
        scoreText.text = "Score: 0";
        gameoverText.text = "0";
        SpawnWaves();
    }

    void Update() {
        newDoor = GameObject.FindWithTag("Door");
        SwipeDoor();
    }

    public void SpawnWaves()
    {
        GameObject[] Door = new GameObject[3];
        Door[0] = leftDoor;
        Door[1] = rightDoor;
        Door[2] = upDoor;
        
        if (hg.hunger > 0)
        {
            Instantiate(Door[Random.Range(0, 3)], new Vector3(0, 0, 0), Quaternion.identity);
        }
        
    }

    void SwipeDoor()
    {
        if(newDoor != null)
        {
            DestroyDoor(SwipeDirectionbyMouse.LEFT, "Left");
            DestroyDoor(SwipeDirectionbyMouse.RIGHT, "Right");
            DestroyDoor(SwipeDirectionbyMouse.UP, "Up");
            //Destroy and AddScore if Correctly Swiped

            DestroyDoorifIncorrect(SwipeDirectionbyMouse.LEFT, "Left");
            DestroyDoorifIncorrect(SwipeDirectionbyMouse.RIGHT, "Right");
            DestroyDoorifIncorrect(SwipeDirectionbyMouse.UP, "Up");
            //Destroy if Incorrectly Swiped
        }
    }

    void DestroyDoor(SwipeDirectionbyMouse dir, string door)
    {
        if ((swipe.swipeDirection == dir) && (newDoor.name == door+"SwipeDoor(Clone)"))
        {
            Debug.Log ("Correct!");
            Destroy(newDoor);
            swipe.directionChosen = false;
            isCorrect = true;
            AddScore();
            SpawnWaves();
        }
    }

    void DestroyDoorifIncorrect(SwipeDirectionbyMouse dir, string door)
    {
        if ((swipe.swipeDirection != dir) && (newDoor.name == door + "SwipeDoor(Clone)") && (swipe.swipeDirection != SwipeDirectionbyMouse.NONE))
        {
            Debug.Log ("Fail");
            Destroy(newDoor);
            swipe.directionChosen = false;
            isCorrect = false;
            SpawnWaves();
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        gameoverText.text = score.ToString();
    }

    void AddScore()
    {
        score += 1 ; // Set different score value for different doors
        UpdateScore();
    }

}

