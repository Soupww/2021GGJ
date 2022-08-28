using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yunsuzou : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.0f;
    private Vector3 speeed;
    void Start()
    {
        speeed = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speeed;
    }
}
