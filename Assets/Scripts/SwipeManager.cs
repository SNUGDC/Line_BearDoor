using UnityEngine;
using System.Collections;

public enum SwipeDirection {
    NONE = 0,
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8
}

public class SwipeManager : MonoBehaviour {
    public SwipeDirection swipeDirection;
	public Vector2 startPos;
	public Vector2 direction;
	public bool directionChosen;

	void Update() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);

			switch (touch.phase) {
			case TouchPhase.Began:
				Debug.Log ("Touch Began");
				startPos = touch.position;
				directionChosen = false;
				break;

			case TouchPhase.Moved:
				direction = touch.position - startPos;
				break;

			case TouchPhase.Ended:
				Debug.Log ("Touch Ended");
				directionChosen = true;
				break;
			}
		} // Swipe by Touch
        
		if (directionChosen) {
			if (direction.x > 0 && direction.x > direction.y) {
                swipeDirection = SwipeDirection.RIGHT;
				Debug.Log ("Swiped Right");
			}
			else if (direction.x < 0 && direction.x > direction.y) {
                swipeDirection = SwipeDirection.LEFT;
                Debug.Log ("Swiped Left");
			}
            else if (direction.y > 0 && direction.y > direction.x) {
                swipeDirection = SwipeDirection.UP;
                Debug.Log("Swiped Up");
            }
            else if (direction.y < 0 && direction.y > direction.x) {
                swipeDirection = SwipeDirection.DOWN;
                Debug.Log("Swiped Down");
            }
        } // Set SwipeDirection
	}

    public bool IsSwiping(SwipeDirection dir)  {
        return dir == swipeDirection;
    } // Return if Swiped or not
}