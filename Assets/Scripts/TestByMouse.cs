using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirectionbyMouse
{
    NONE = 0,
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8
}

public class TestByMouse : MonoBehaviour {
    public SwipeDirectionbyMouse swipeDirection { set; get; }
    public bool directionChosen;
    public Vector2 startPos;
    public Vector2 direction;
    public bool isSwiping;

    void Update() {
        swipeDirection = SwipeDirectionbyMouse.NONE;
        Swipe();
    }

    void Swipe() {

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            //directionChosen = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePositionV2 = Input.mousePosition;

            direction = mousePositionV2 - startPos;
            //directionChosen = true;

            if (direction.x > 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
                swipeDirection = SwipeDirectionbyMouse.RIGHT;
                //Debug.Log("Swiped Right");
            }
            if (direction.x < 0 && Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
                swipeDirection = SwipeDirectionbyMouse.LEFT;
                //Debug.Log("Swiped Left");
            }
            if (direction.y > 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
                swipeDirection = SwipeDirectionbyMouse.UP;
                //Debug.Log("Swiped Up");
            }
            if (direction.y < 0 && Mathf.Abs(direction.x) < Mathf.Abs(direction.y)) {
                swipeDirection = SwipeDirectionbyMouse.DOWN;
                //Debug.Log("Swiped Down");
            }
        } // Set SwipeDirection
    }
    /*public bool IsSwiping(SwipeDirectionbyMouse dir) {
        if (dir == swipeDirection) {
            isSwiping = true;
        }
        return dir == swipeDirection;
    } // Return if Swiped or not */
}
    

