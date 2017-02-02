using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSpawn : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject upDoor;
    public GameObject newDoor;
    public GameObject blankDoor;

    public bool isCorrect;

    TestByMouse swipe;
    Hunger hg;
    GameController gameController;

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
        GameObject[] Door = new GameObject[4];
        Door[0] = leftDoor;
        Door[1] = rightDoor;
        Door[2] = upDoor;
        Door[3] = blankDoor;

        if (hg.hunger > 0)
        {
            newDoor = Instantiate(Door[Random.Range(0, 4)], new Vector3(0, 1.3f, 0), Quaternion.identity) as GameObject;
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
            //Destroy and AddScore if Correctly Swiped

            IncorrectlySwiped(SwipeDirectionbyMouse.LEFT, "Left");
            IncorrectlySwiped(SwipeDirectionbyMouse.RIGHT, "Right");
            IncorrectlySwiped(SwipeDirectionbyMouse.UP, "Up");
            //Destroy if Incorrectly Swiped
        }
    }

    void CorrectlySwiped(SwipeDirectionbyMouse dir, string door)
    {
        if ((swipe.swipeDirection == dir) && (newDoor.name == door + "SwipeDoor(Clone)") && (GameObject.Find(door + "SwipeArrow") != null))
        {
            Debug.Log("Correct!");
            Destroy(GameObject.Find(door + "SwipeArrow"));
            gameController.AddScore();
            isCorrect = true;
            swipe.directionChosen = false;
            swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
        }
    }

    void IncorrectlySwiped(SwipeDirectionbyMouse dir, string door)
    {
        if(swipe.swipeDirection != dir && newDoor.name == "BlankSwipeDoor(Clone)")
        {
            Debug.Log("Fail");
            isCorrect = false;
            swipe.directionChosen = false;
            swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
            Destroy(GameObject.Find("BlankDoorFlag"));
        }

        if ((swipe.swipeDirection != dir) && (newDoor.name == door + "SwipeDoor(Clone)") && (swipe.swipeDirection != SwipeDirectionbyMouse.NONE))
        {
            Debug.Log("Fail");
            isCorrect = false;
            swipe.directionChosen = false;
            swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
        }
    }
}

//update -> swipeDoor -> DestroyDoor -> AddScore -> newDoor.name == ~~~ -> UpdateScore