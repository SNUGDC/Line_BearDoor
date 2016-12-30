using UnityEngine;
using System.Collections;

public class SwipeManager : MonoBehaviour {
	public Vector2 startPos;
	public Vector2 direction;
	public bool directionChosen;

	public GameObject tester;

	void Start(){
	}

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
		}
		// Swipe by Touch

		/*if (Input.GetMouseButtonDown (0)) {
			startPos = Input.mousePosition;
			directionChosen = false;
		}

		if (Input.GetMouseButtonUp(0)) {
			Vector2 mousePositionV2 = Input.mousePosition;

			direction = mousePositionV2 - startPos;
			directionChosen = true;
		}*/
        // Mouse Test

		if (directionChosen) {
			if (direction.x > 0 && direction.x > direction.y) {
				tester.transform.Translate (5,0,0); // Move Tester object right
				Debug.Log ("Swiped Right");

				// Swiped Right
			}
			if (direction.x < 0 && direction.x > direction.y) {
				tester.transform.Translate (-5,0,0); // Move Tester object left
				Debug.Log ("Swiped Left");
				// Swiped Left
			}
		}
	}
}