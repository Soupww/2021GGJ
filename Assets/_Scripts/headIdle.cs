using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class headIdle : MonoBehaviour
{
    private Transform initTrans;

    public float range = 0.01f;

    public float speed = 15;

    private Vector3 upwRange;
    // Start is called before the first frame update
    void Start()
    {
        initTrans = transform;
        upwRange = transform.up * range;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initTrans.position + upwRange * Mathf.Sin(Time.time*speed);
    }
}
