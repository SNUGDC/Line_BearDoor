using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSpawn : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject upDoor;
    public GameObject newDoor;

    public float score;
    public bool isCorrect;
    public Text scoreText;
    public Text gameoverText;

    public TestByMouse swipe;
    public Hunger hg;
    public DoorMover doorMover;
    public IEnumerator coroutine;

    public static DoorSpawn Instance = null;

    public void Initialize() {
        Instance = this;
        scoreText.text = "0";
        gameoverText.text = "0";
        SpawnWaves();
    }

    public void SpawnWaves()
    {
        GameObject[] Door = new GameObject[3];
        Door[0] = leftDoor;
        Door[1] = rightDoor;
        Door[2] = upDoor;

        if (hg.hunger > 0)
        {
            newDoor = Instantiate(Door[Random.Range(0, 3)], new Vector3(0, 1.3f, 0), Quaternion.identity) as GameObject;
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
        if ((swipe.swipeDirection == dir) && (newDoor.name == door + "SwipeDoor(Clone)"))
        {
            Debug.Log("Correct!");
            Destroy(GameObject.Find(door + "SwipeArrow"));
            AddScore();
            isCorrect = true;
            swipe.directionChosen = false;
            swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
        }
    }

    void IncorrectlySwiped(SwipeDirectionbyMouse dir, string door)
    {
        if ((swipe.swipeDirection != dir) && (newDoor.name == door + "SwipeDoor(Clone)") && (swipe.swipeDirection != SwipeDirectionbyMouse.NONE))
        {
            Debug.Log("Fail");
            isCorrect = false;
            swipe.directionChosen = false;
            swipe.swipeDirection = SwipeDirectionbyMouse.NONE;
        }
    }
	void AddScore()
	{
		if (newDoor.name == "LeftSwipeDoor(Clone)")
		{
			score += (doorMover.DoorSpeed() * 100000 / 3) * 1;
		}
		else if (newDoor.name == "RightSwipeDoor(Clone)")
		{
			score += (doorMover.DoorSpeed() * 100000 / 3) * 2;
		}
		else if (newDoor.name == "UpSwipeDoor(Clone)")
		{
			score += (doorMover.DoorSpeed() * 100000 / 3) * 3;
		}
		// score += 1 ; 
		UpdateScore();
	}

    void UpdateScore()
    {
        scoreText.text = " " + score;
        gameoverText.text = score.ToString();
        Debug.Log(score);
    }
}

//update -> swipeDoor -> DestroyDoor -> AddScore -> newDoor.name == ~~~ -> UpdateScore