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

    public static TestByMouse Instance = null;

    Vector2 direction1 = Vector2.zero;
    Vector2 direction2 = Vector2.zero;
    float angle = 0;

    void Start() {
        Instance = this;
    }

    void Update() {
        Swipe();
    }

    void Swipe()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            if(direction1 == Vector2.zero && direction2 == Vector2.zero)
            {

            }
            else if (direction2 == Vector2.zero)
            {
                Vector2 currentPos = Input.mousePosition;
                direction1 = currentPos - startPos;
            }
            else
            {
                angle += Vector2.Angle(direction2, direction1);
                direction1 = direction2;
                direction2 = Vector2.zero;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousePositionV2 = Input.mousePosition;

            direction = mousePositionV2 - startPos;
            DirectionChoose();
        }
    }

    void DirectionChoose()
    {
        if ((direction.x > 0) && (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)))
        {
            swipeDirection = SwipeDirectionbyMouse.RIGHT;
            //Debug.Log("Swiped Right");
        }
        else if ((direction.x < 0) && (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)))
        {
            swipeDirection = SwipeDirectionbyMouse.LEFT;
            //Debug.Log("Swiped Left");
        }
        else if ((direction.y > 0) && (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)))
        {
            swipeDirection = SwipeDirectionbyMouse.UP;
            //Debug.Log("Swiped Up");
        }
        else if ((direction.y < 0) && (Mathf.Abs(direction.x) < Mathf.Abs(direction.y)))
        {
            swipeDirection = SwipeDirectionbyMouse.DOWN;
            //Debug.Log("Swiped Down");
        }
    }

    /*public bool IsSwiping(SwipeDirectionbyMouse dir) {
        return dir == swipeDirection;
    }*/
}
    

