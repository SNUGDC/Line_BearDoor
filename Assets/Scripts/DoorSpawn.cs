using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawn : MonoBehaviour {
    public GameObject leftDoor;
    public GameObject rightDoor;
    public GameObject upDoor;
    public GameObject newDoor;

    TestByMouse swipe = new TestByMouse();
    //SpriteRenderer s_renderer = new SpriteRenderer();

    void Start() {
        StartCoroutine(SpawnWaves());
    }

    void Update() {
        SwipeDoor();
    }

    IEnumerator SpawnWaves() {
        float SpawnWait = 2.0f;
        GameObject[] Door = new GameObject[3];
        Door[0] = leftDoor;
        Door[1] = rightDoor;
        Door[2] = upDoor;

        while (true) { //Input Spawn Requirements 
            newDoor = Instantiate(Door[Random.Range(0, 3)], new Vector3(0,0,0), Quaternion.identity);
            yield return new WaitForSeconds(SpawnWait);
        }
    }

    void SwipeDoor()
    {
        //newDoor = GameObject.FindWithTag("Door");
        if (swipe.swipeDirection == SwipeDirectionbyMouse.LEFT 
            /*&&newDoor == leftDoor*/) {
            //newDoor.SetActive(false);
            Destroy(newDoor);
            Debug.Log("Left Door Destroyed");
        }
        else if (swipe.swipeDirection == SwipeDirectionbyMouse.RIGHT 
            /*&& newDoor == rightDoor*/) {
            //newDoor.SetActive(false);
            Destroy(newDoor);
            Debug.Log("Right Door Destroyed");
        }
        else if (swipe.swipeDirection == SwipeDirectionbyMouse.UP 
            /*&& newDoor == upDoor*/) {
            //newDoor.SetActive(false);
            Destroy(newDoor);
            Debug.Log("Up Door Destroyed");
        }
        /*else if (swipe.IsSwiping(SwipeDirectionbyMouse.DOWN)) {
            Destroy(ds.downDoor);
        }*/
    }
}

