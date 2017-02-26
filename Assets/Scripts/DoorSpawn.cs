using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Door
{
    public SwipeDirectionbyMouse direction;
    public DoorComponent door;
}

public class DoorSpawn : MonoBehaviour {
    
    public DoorComponent newDoor;

    public List<Door> doors;

    public bool isCorrect;

    SwipeManager swipe;
    GameController gameController;

    public int combo = 0;

    public static DoorSpawn Instance = null;

    public void Initialize() {
        Instance = this;

        swipe = GetComponent<SwipeManager>();
        Debug.Assert(swipe != null);
        gameController = GetComponent<GameController>();
        Debug.Assert(gameController != null);
        SpawnWaves();
    }

    public void SpawnWaves()
    {
        if (GameController.Instance.currentLevel.Hunger > 0)
        {
            Door randomDoor = null;
            if(GameController.Instance.currentLevel.combo < 5)
            {
                randomDoor = doors[UnityEngine.Random.Range(7, 9)];
            }
            else if(GameController.Instance.currentLevel.combo < 10)
            {
                randomDoor = doors[UnityEngine.Random.Range(7, 9)];
            }
            else
            {
                randomDoor = doors[UnityEngine.Random.Range(7, 9)];
            }

            newDoor = Instantiate(randomDoor.door, new Vector3(0, 1.3f, 0), Quaternion.identity) as DoorComponent;
            newDoor.GetComponent<DoorMover>().Initialize(GameController.Instance.currentLevel.Doorspeed);
        }
    }

    public void SwipeDoor()
    {
        if(newDoor != null)
        {
            SwipeDirectionbyMouse doorDir = newDoor.direction;
            if (swipe.swipeDirection == doorDir)
            {
                Debug.Log("Correct!");
                newDoor.Correct();
                gameController.AddScore(newDoor.direction);
                isCorrect = true;
                swipe.directionChosen = false;
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
                return;
            }
            else if (swipe.swipeDirection != doorDir)
            {
                Debug.Log("Fail");
                isCorrect = false;
                swipe.directionChosen = false;
                if (newDoor.direction == SwipeDirectionbyMouse.NONE)
                {
                    newDoor.Correct();
                }
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            }
            //Flag Failure if Incorrectly Reverse Swiped
        }
    }
}