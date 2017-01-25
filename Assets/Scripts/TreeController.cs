using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public Position TreePosition;

    private float MoveSpeed;
    private float MoveDistance;

    public static TreeController Instance = null;

    public enum Position
    {
        Right,
        Left
    }

    private void Start()
    {
        Instance = this;

        MoveSpeed = 2.8f;
    }

    void Update()
    {
        MoveDistance = MoveSpeed * Time.deltaTime;

        switch (TreePosition)
        {
        case Position.Left:
            transform.position = new Vector3 (transform.position.x + 4 * MoveDistance / 7, transform.position.y - MoveDistance, transform.position.z - 50 * MoveDistance / 7);
            break;
        case Position.Right:
            transform.position = new Vector3 (transform.position.x - 4 * MoveDistance / 7, transform.position.y - MoveDistance, transform.position.z - 50 * MoveDistance / 7);
            break;
        }

        if (transform.position.y < -2f)
            Destroy (this.gameObject);
    }
}
