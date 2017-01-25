using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour {
    private float nextTime = 0.0f;
    private float deltaTime = 0.01f;

    public static float doorSpeed = 0.003f;

    public static DoorMover Instance = null;

    void Start() {
        Instance = this;

        transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);
    }

    void Update() {

        if (transform.localScale.x<=0.3f && transform.localScale.y<=0.3f && transform.localScale.z <= 1.0f) {
            if(Time.time > nextTime) {
                nextTime = Time.time + deltaTime * 0.003f / (doorSpeed); //normal interval / interval of increased speed(=normal speed + increase speed)
                transform.localScale += new Vector3(1.0f, 1.0f, 0.0f) * (doorSpeed); //normal speed + increase speed
            }
        }
    }

    void OnDestroy() {
        if (DoorSpawn.Instance.isCorrect == true) {
            doorSpeed += 0.0003f;
        }
        if(DoorSpawn.Instance.isCorrect == false) {
            doorSpeed = 0.003f;
        }
        TestByMouse.Instance.swipeDirection = SwipeDirectionbyMouse.NONE;
        DoorSpawn.Instance.isCorrect = false;
    }

    public float DoorSpeed()
    {
        return doorSpeed;
    }
}
