using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour {
    private float nextTime = 0.0f;
    private float deltaTime = 0.01f;

    public Transform tf;
    public static TestByMouse mouseTest;
    public static Hunger hunger;

    void Start() { 
        tf = GetComponent<Transform>();
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
            Debug.Log("isHit");
            hunger.hunger -= 100;
            hunger.hungerbar.rectTransform.sizeDelta -= new Vector2(40, 0);
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        mouseTest.swipeDirection = SwipeDirectionbyMouse.NONE;
    }
}
