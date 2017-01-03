using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour {
    private Transform tf;
    private float nextTime = 0.0f;
    private float deltaTime = 0.01f;

    public static TestByMouse mouseTest;

    void Start() { 
        tf = GetComponent<Transform>();
        //mouseTest = gameObject.AddComponent<TestByMouse>();
        tf.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    void Update() {
        if(tf.localScale.x<=1.3f && tf.localScale.y<=1.3f && tf.localScale.z <= 1.3f) {
            if(Time.time > nextTime) {
                nextTime = Time.time + deltaTime;
                tf.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
        if(tf.localScale == new Vector3(1.3f, 1.3f, 1.3f)) {
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        mouseTest.swipeDirection = SwipeDirectionbyMouse.NONE;
    }
}
