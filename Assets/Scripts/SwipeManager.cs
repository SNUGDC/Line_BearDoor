using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public enum SwipeDirectionbyMouse
{
    NONE=0, LEFT, RIGHT, UP, DOWN , ClockWise, CounterClockWise
}

public class SwipeManager : MonoBehaviour {
    public SwipeDirectionbyMouse swipeDirection;
    public bool directionChosen;
    public Vector2 startPos;
    public Vector2 direction;
    public bool isSwiping;

    public static SwipeManager Instance = null;

    Vector3 direction1 = Vector3.zero;
    Vector3 direction2 = Vector3.zero;
    public List<Vector3> circleDirection = new List<Vector3>();
    Vector3 mousePos = Vector3.zero;
    float angle = 0;
    public float minAngle = 0f;
    float swipeTerm = 0;
    public int framePerSwipeTerm;

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
            mousePos = Input.mousePosition;
            return;
        }

        if (Input.GetMouseButton(0))
        {
            swipeTerm += Time.deltaTime;
            if(swipeTerm > Time.deltaTime * framePerSwipeTerm)
            {
                swipeTerm = 0;
                Vector3 tempPos = Input.mousePosition;
                if (direction1 != Vector3.zero)
                {
                    angle += Vector2.Angle(direction1, direction2);
                    circleDirection.Add(Vector3.Cross(direction1, direction2).normalized);
                }
                direction1 = direction2;
                direction2 = tempPos - mousePos;
                mousePos = tempPos;
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            int dirCount = circleDirection.Count();
            if (angle >= minAngle)
            {
                IGrouping<bool, Vector3> registeredGroup = circleDirection
                    .GroupBy(a => IsClockWise(a))
                    .Where(g => g.Count() > 0.8 * dirCount).FirstOrDefault();
                if (registeredGroup != null)
                {
                    if (registeredGroup.Key)
                    {
                        swipeDirection = SwipeDirectionbyMouse.ClockWise;
                        ResetDirection();
                        GetComponent<DoorSpawn>().SwipeDoor();
                        return;
                    }
                    else
                    {
                        swipeDirection = SwipeDirectionbyMouse.CounterClockWise;
                        ResetDirection();
                        GetComponent<DoorSpawn>().SwipeDoor();
                        return;
                    }
                }
            }

            ResetDirection();
            DirectionChoose();
            GetComponent<DoorSpawn>().SwipeDoor();
        }
    }
    
    bool IsClockWise(Vector3 normalVector)
    {
        return normalVector == new Vector3(0, 0, -1);
    }

    void ResetDirection()
    {
        Vector2 mousePositionV2 = Input.mousePosition;
        angle = 0;
        swipeTerm = 0;
        direction1 = Vector3.zero;
        direction2 = Vector3.zero;
        mousePos = Vector3.zero;
        circleDirection.Clear();
        direction = mousePositionV2 - startPos;
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
}
    

