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
    Hunger hg;
    GameController gameController;

    public int combo = 0;

    public static DoorSpawn Instance = null;

    public void Initialize() {
        Instance = this;

        swipe = GetComponent<SwipeManager>();
        Debug.Assert(swipe != null);
        hg = GetComponent<Hunger>();
        Debug.Assert(hg != null);
        gameController = GetComponent<GameController>();
        Debug.Assert(gameController != null);
        SpawnWaves();
    }

    public void SpawnWaves()
    {
        if (hg.hunger > 0)
        {
            Door randomDoor = null;
            if(combo < 5)
            {
                randomDoor = doors[UnityEngine.Random.Range(7, 9)];
            }
            else if(combo < 10)
            {
                randomDoor = doors[UnityEngine.Random.Range(7, 9)];
            }
            else
            {
                randomDoor = doors[UnityEngine.Random.Range(7, 9)];
            }

            newDoor = Instantiate(randomDoor.door, new Vector3(0, 1.3f, 0), Quaternion.identity) as DoorComponent;
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
                Destroy(newDoor.arrow);
                gameController.AddScore(newDoor.direction);
                combo += 1;
                isCorrect = true;
                swipe.directionChosen = false;
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
                return;
            }
            else if (swipe.swipeDirection != doorDir)
            {
                Debug.Log("Fail");
                combo = 0;
                isCorrect = false;
                swipe.directionChosen = false;
                if (newDoor.direction == SwipeDirectionbyMouse.NONE)
                {
                    Destroy(newDoor.arrow);
                }
                swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            }
            //Flag Failure if Incorrectly Reverse Swiped

        }
    }
}