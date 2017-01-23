using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    public GameObject Road1;
    public GameObject Road2;
    public float MoveSpeed;

    private Transform Road1Transform;
    private Transform Road2Transform;
    private float MoveDistance;

    private void Start()
    {
        Instantiate (Road1);
        Instantiate (Road2);

        Road1Transform = GameObject.Find ("Road 1(Clone)").transform;
        Road2Transform = GameObject.Find ("Road 2(Clone)").transform;
    }

    private void Update()
    {
        MoveDistance = MoveSpeed * Time.deltaTime;

        Road1Transform.position = new Vector3 (0, Road1Transform.position.y - MoveDistance, Road1Transform.position.z - MoveDistance * Mathf.Tan (7 * Mathf.PI / 18));
        Road2Transform.position = new Vector3 (0, Road2Transform.position.y - MoveDistance, Road2Transform.position.z - MoveDistance * Mathf.Tan (7 * Mathf.PI / 18));

        if (Road1Transform.position.y <= -4.83f)
        {
            Road1Transform.position = new Vector3 (0, 8.84f, 20.27f);
        }

        if (Road2Transform.position.y <= -4.83f)
        {
            Road2Transform.position = new Vector3 (0, 8.84f, 20.27f);
        }
    }
}
