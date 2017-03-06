using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour {

    enum MoveDirection { None, Left, Right, Up, Down}
    public SwipeDirectionbyMouse direction = SwipeDirectionbyMouse.NONE;
    public GameObject arrow;
    public bool isReverseDoor;

    MoveDirection moveDirection = MoveDirection.None;

    public void Correct()
    {
        if (direction == SwipeDirectionbyMouse.ClockWise || direction == SwipeDirectionbyMouse.CounterClockWise)
        {
            GetComponent<Animator>().SetTrigger("Correct");
            Destroy(arrow);
        }
        else if (direction == SwipeDirectionbyMouse.LEFT)
        {
            Destroy(arrow);
            moveDirection = MoveDirection.Left;
        }

        else if (direction == SwipeDirectionbyMouse.RIGHT)
        {
            Destroy(arrow);
            moveDirection = MoveDirection.Right;
        }
        else if (direction == SwipeDirectionbyMouse.UP)
        {
            Destroy(arrow);
            moveDirection = MoveDirection.Up;
        }
        else if (direction == SwipeDirectionbyMouse.DOWN)
        {
            Destroy(arrow);
            moveDirection = MoveDirection.Down;
        }
    }

    void Update()
    {
        switch(moveDirection)
        {
            case MoveDirection.None:
                break;
            case MoveDirection.Left:
                transform.Translate(-4 * Time.deltaTime, 0, 0);
                break;
            case MoveDirection.Right:
                transform.Translate(4 * Time.deltaTime, 0, 0);
                break;
            case MoveDirection.Up:
                transform.Translate(0, 4 * Time.deltaTime, 0);
                break;
            case MoveDirection.Down:
                transform.Translate(0, -4 * Time.deltaTime, 0);
                break;
        }
    }
}
