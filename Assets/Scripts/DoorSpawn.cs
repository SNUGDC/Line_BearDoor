using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSpawn : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject upDoor;
    public GameObject newDoor;

    public int score;
    public Text scoreText;

    public TestByMouse swipe;
    public Hunger hg;
    public IEnumerator coroutine;

    void Start() {
        scoreText.text = "Score:";
        coroutine = SpawnWaves();
        StartCoroutine(coroutine);
    }

    void Update() {
        newDoor = GameObject.FindWithTag("Door");
        SwipeDoor();
    }

    IEnumerator SpawnWaves()
    {
        float SpawnWait = 2.0f;
        GameObject[] Door = new GameObject[3];
        Door[0] = leftDoor;
        Door[1] = rightDoor;
        Door[2] = upDoor;

        while (hg.hunger >= 0)
        { //Input Spawn Requirements 
            Instantiate(Door[Random.Range(0, 3)], new Vector3(0, 0, 0), Quaternion.identity);
            yield return new WaitForSeconds(SpawnWait);
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
        if ((swipe.swipeDirection == dir) && (newDoor.name == door+"SwipeDoor_Dummy(Clone)"))
        {
            Debug.Log ("Correct!");
            Destroy(newDoor);
            swipe.directionChosen = false;
            AddScore();
            StopCoroutine(coroutine);
            StartCoroutine(coroutine);
        }
    }

    void DestroyDoorifIncorrect(SwipeDirectionbyMouse dir, string door)
    {
        if ((swipe.swipeDirection != dir) && (newDoor.name == door + "SwipeDoor_Dummy(Clone)") && (swipe.swipeDirection != SwipeDirectionbyMouse.NONE))
        {
            Debug.Log ("Fail");
            Destroy(newDoor);
            swipe.directionChosen = false;
            StopCoroutine(coroutine);
            StartCoroutine(coroutine);
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void AddScore()
    {
        score += 1;
        UpdateScore();
    }

}

