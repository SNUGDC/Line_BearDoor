using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirectionbyMouse
{
    NONE=0, LEFT, RIGHT, UP, DOWN
}

public class TestByMouse : MonoBehaviour {
    public SwipeDirectionbyMouse swipeDirection;
    public bool directionChosen;
    public Vector2 startPos;
    public Vector2 direction;
    public bool isSwiping;

    void Start() {
        DoorMover.mouseTest = GameObject.Find("GameController").GetComponent<TestByMouse>();
    }

    void Update() {
        Swipe();
    }

    void Swipe() {

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePositionV2 = Input.mousePosition;

            direction = mousePositionV2 - startPos;
            directionChosen = true;
        }

        if (directionChosen) {
            if ((direction.x > 0) && (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))) {
                swipeDirection = SwipeDirectionbyMouse.RIGHT;
                //Debug.Log("Swiped Right");
            }
            else if ((direction.x < 0) && (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))) {
                swipeDirection = SwipeDirectionbyMouse.LEFT;
                //Debug.Log("Swiped Left");
            }
            else if ((direction.y > 0) && (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))) {
                swipeDirection = SwipeDirectionbyMouse.UP;
                //Debug.Log("Swiped Up");
            }
            else if ((direction.y < 0) && (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))) {
                swipeDirection = SwipeDirectionbyMouse.DOWN;
                //Debug.Log("Swiped Down");
            }
        } // Set SwipeDirection
    }

    /*public bool IsSwiping(SwipeDirectionbyMouse dir) {
        return dir == swipeDirection;
    }*/
}
    

