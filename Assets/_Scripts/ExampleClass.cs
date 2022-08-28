using System;
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    private float evokeTime;

    void Start()
    {
        evokeTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - evokeTime > 5)
        {
            Destroy(gameObject);
        }
    }
}