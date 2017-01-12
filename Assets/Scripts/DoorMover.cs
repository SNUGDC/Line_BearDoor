using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour {
    private float nextTime = 0.0f;
    private float deltaTime = 0.01f;

    public static float doorSpeed = 0.003f;

    public Transform tf;
    public static DoorSpawn doorSpawn;
    public static TestByMouse mouseTest;
    public static Hunger hunger;

    void Start() {
        tf = GetComponent<Transform>();
        tf.localScale = new Vector3(0.1f, 0.1f, 1.0f);
    }

    void Update() {

        if (tf.localScale.x<=0.3f && tf.localScale.y<=0.3f && tf.localScale.z <= 1.0f) {
            if(Time.time > nextTime) {
                nextTime = Time.time + deltaTime * 0.003f / (doorSpeed); //normal interval / interval of increased speed(=normal speed + increase speed)
                tf.localScale += new Vector3(1.0f, 1.0f, 0.0f) * (doorSpeed); //normal speed + increase speed
            }
        }
        if(//tf.localScale == new Vector3(0.3f, 0.3f, 1.0f)
            tf.localScale.x >= 0.3f && tf.localScale.y >= 0.3f && tf.localScale.z >= 1.0f) {
            Debug.Log("isHit");
            hunger.hunger -= 100;
            hunger.hungerbar.rectTransform.sizeDelta -= new Vector2(76, 0);
            Destroy(this.gameObject);
            doorSpawn.SpawnWaves();
        }
    }

    void OnDestroy() {
        if (doorSpawn.isCorrect == true) {
            doorSpeed += 0.0006f;
        }
        if(doorSpawn.isCorrect == false) {
            doorSpeed = 0.003f;
        }
        mouseTest.swipeDirection = SwipeDirectionbyMouse.NONE;
        doorSpawn.isCorrect = false;
    }

    public float DoorSpeed()
    {
        return doorSpeed;
    }
}
