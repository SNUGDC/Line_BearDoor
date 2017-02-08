﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSpawn : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject upDoor;
    public GameObject newDoor;
    public GameObject blankDoor;
    public GameObject reverseleftDoor;
    public GameObject reverserightDoor;
    public GameObject reverseupDoor;

    public bool isCorrect;

    TestByMouse swipe;
    Hunger hg;
    GameController gameController;

    private int combo = 0;

    public static DoorSpawn Instance = null;

    public void Initialize() {
        Instance = this;

        swipe = GetComponent<TestByMouse>();
        hg = GetComponent<Hunger>();
        gameController = GetComponent<GameController>();

        SpawnWaves();
    }

    public void SpawnWaves()
    {
        GameObject[][] Door = new GameObject[3][];
        Door[0][0] = leftDoor;
        Door[0][1] = rightDoor;
        Door[0][2] = upDoor;
        Door[1][0] = blankDoor;
        Door[2][0] = reverseleftDoor;
        Door[2][1] = reverserightDoor;
        Door[2][2] = reverseupDoor;

        if (hg.hunger > 0)
        {
            if(combo < 5)
            {
                newDoor = Instantiate(Door[0][Random.Range(0, 7)], new Vector3(0, 1.3f, 0), Quaternion.identity) as GameObject;
            }
            else if(combo < 10)
            {
                newDoor = Instantiate(Door[Random.Range(0,2)][Random.Range(0, 7)], new Vector3(0, 1.3f, 0), Quaternion.identity) as GameObject;
            }
            else if(combo >= 10)
            {
                newDoor = Instantiate(Door[Random.Range(0,3)][Random.Range(0, 7)], new Vector3(0, 1.3f, 0), Quaternion.identity) as GameObject;
            }
        }
    }

    void Update()
    {
        SwipeDoor();
    }

    void SwipeDoor()
    {
        if(newDoor != null)
        {
            CorrectlySwiped(SwipeDirectionbyMouse.LEFT, "Left");
            CorrectlySwiped(SwipeDirectionbyMouse.RIGHT, "Right");
            CorrectlySwiped(SwipeDirectionbyMouse.UP, "Up");
            //Destroy Arrow and AddScore if Correctly Swiped

            ReverseCorrectlySwiped(SwipeDirectionbyMouse.LEFT, "Left");
            ReverseCorrectlySwiped(SwipeDirectionbyMouse.RIGHT, "Right");
            ReverseCorrectlySwiped(SwipeDirectionbyMouse.UP, "Up");
            //Destroy Arrow and AddScore if Correctly Reverse Swiped

            IncorrectlySwiped(SwipeDirectionbyMouse.LEFT, "Left");
            IncorrectlySwiped(SwipeDirectionbyMouse.RIGHT, "Right");
            IncorrectlySwiped(SwipeDirectionbyMouse.UP, "Up");
            IncorrectlySwiped(SwipeDirectionbyMouse.NONE, "Blank");
            //Flag Failure if Incorrectly Swiped

            ReverseIncorrectlySwiped(SwipeDirectionbyMouse.LEFT, "Left");
            ReverseIncorrectlySwiped(SwipeDirectionbyMouse.RIGHT, "Right");
            ReverseIncorrectlySwiped(SwipeDirectionbyMouse.UP, "Up");
            //Flag Failure if Incorrectly Reverse Swiped

        }
    }

    void CorrectlySwiped(SwipeDirectionbyMouse dir, string door)
    {
        if ((swipe.swipeDirection == dir) && (newDoor.name == door + "SwipeDoor(Clone)") && (GameObject.Find(door + "SwipeArrow") != null))
        {
            Debug.Log("Correct!");
            Destroy(GameObject.Find(door + "SwipeArrow"));
            gameController.AddScore();
            combo += 1;
            isCorrect = true;
            swipe.directionChosen = false;
            swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
        }
    }


    void ReverseCorrectlySwiped(SwipeDirectionbyMouse dir, string door)
    {
        if(newDoor.name == "Reverse" + door + "SwipeDoor_Dummy(Clone)" && GameObject.Find(door + "SwipeArrow") != null)
        {
            if(door == "Left" && swipe.swipeDirection == SwipeDirectionbyMouse.RIGHT)
            {
                Debug.Log("Correct!");
                Destroy(GameObject.Find(door + "SwipeArrow"));
                gameController.AddScore();
                combo += 1;
                isCorrect = true;
                swipe.directionChosen = false;
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            }
            else if(door == "Right" && swipe.swipeDirection == SwipeDirectionbyMouse.LEFT)
            {
                Debug.Log("Correct!");
                Destroy(GameObject.Find(door + "SwipeArrow"));
                gameController.AddScore();
                combo += 1;
                isCorrect = true;
                swipe.directionChosen = false;
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            }
            else if (door == "Up" && swipe.swipeDirection == SwipeDirectionbyMouse.DOWN)
            {
                Debug.Log("Correct!");
                Destroy(GameObject.Find(door + "SwipeArrow"));
                gameController.AddScore();
                combo += 1;
                isCorrect = true;
                swipe.directionChosen = false;
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            }
        }
    }

    void IncorrectlySwiped(SwipeDirectionbyMouse dir, string door)
    {
        if(swipe.swipeDirection != SwipeDirectionbyMouse.NONE && newDoor.name == "BlankSwipeDoor_Dummy(Clone)" && GameObject.Find("BlankDoorFlag") != null)
        {
            Debug.Log("Fail");
            combo = 0;
            isCorrect = false;
            swipe.directionChosen = false;
            swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            Destroy(GameObject.Find("BlankDoorFlag"));
        } 
        // for BlankDoor

        else if ((swipe.swipeDirection != dir) && (newDoor.name == door + "SwipeDoor(Clone)") && (swipe.swipeDirection != SwipeDirectionbyMouse.NONE))
        {
            Debug.Log("Fail");
            combo = 0;
            isCorrect = false;
            swipe.directionChosen = false;
            swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
        }
    }

    void ReverseIncorrectlySwiped(SwipeDirectionbyMouse idr, string door)
    {
        if (newDoor.name == "Reverse" + door + "SwipeDoor_Dummy(Clone)" && GameObject.Find(door + "SwipeArrow") != null && swipe.swipeDirection != SwipeDirectionbyMouse.NONE)
        {
            if (door == "Left" && swipe.swipeDirection != SwipeDirectionbyMouse.RIGHT)
            {
                Debug.Log("Fail");
                combo = 0;
                isCorrect = false;
                swipe.directionChosen = false;
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            }
            else if (door == "Right" && swipe.swipeDirection == SwipeDirectionbyMouse.LEFT)
            {
                Debug.Log("Fail");
                combo = 0;
                isCorrect = false;
                swipe.directionChosen = false;
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            }
            else if (door == "Up" && swipe.swipeDirection == SwipeDirectionbyMouse.DOWN)
            {
                Debug.Log("Fail");
                combo = 0;
                isCorrect = false;
                swipe.directionChosen = false;
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            }
        }
    }
}