using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour {

    float doorSpeed;
    public static DoorMover Instance = null;

    public void Initialize(float doorSpeed)
    {
        this.doorSpeed = doorSpeed;
    }

    void Start() {
        Instance = this;
    }

    void Update() {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.0f) * (1+doorSpeed*Time.deltaTime) + new Vector3(0f,0f,1f);
        if(transform.localScale.x >= 0.3f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy() {
        if (DoorSpawn.Instance.isCorrect == true)
        {
            GameController.Instance.currentLevel.IncreaseLevel();
        }
        else if(DoorSpawn.Instance.isCorrect == false)
        {
            GameController.Instance.currentLevel.ResetLevel();
        }
        SwipeManager.Instance.swipeDirection = SwipeDirectionbyMouse.NONE;
        DoorSpawn.Instance.isCorrect = false;
    }
}
