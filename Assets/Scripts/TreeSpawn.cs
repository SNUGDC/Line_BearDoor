using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public GameObject LeftTree;
    public GameObject RightTree;

    private float LeftDelay = 0;
    private float RightDelay = 0;
    private float CreateLeftTreeTime = 0;
    private float CreateRightTreeTime = 0;
    private float GameTime;

    private void Start()
    {
        Instantiate(LeftTree);
        Instantiate(RightTree);

        LeftDelay = Random.Range(1f, 3f);
        RightDelay = Random.Range(1f, 3f);
    }

    private void Update()
    {
        GameTime = GameTime + Time.deltaTime;

        if (GameTime - CreateLeftTreeTime >= LeftDelay)
        {
            Instantiate(LeftTree);
            LeftDelay = Random.Range(1f, 3f);
            CreateLeftTreeTime = GameTime;
        }

        if (GameTime - CreateRightTreeTime >= RightDelay)
        {
            Instantiate(RightTree);
            RightDelay = Random.Range(1f, 3f);
            CreateRightTreeTime = GameTime;
        }
    }
}
