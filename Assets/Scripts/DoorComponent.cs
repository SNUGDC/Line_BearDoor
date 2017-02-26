using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorComponent : MonoBehaviour {
    public SwipeDirectionbyMouse direction = SwipeDirectionbyMouse.NONE;
    public GameObject arrow;
    public bool isReverseDoor;

    public void Correct()
    {
        if(direction == SwipeDirectionbyMouse.ClockWise || direction == SwipeDirectionbyMouse.CounterClockWise)
        {
            GetComponent<Animator>().SetTrigger("Correct");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
