using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class niulego : MonoBehaviour
{
    public float range = 0.01f;

    public float speed = 15;
    
    private Quaternion initRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        initRotation = transform.localRotation;
        // transform.RotateAround(transform.position, transform.forward, range * -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(range * Mathf.Sin(Time.time*speed), initRotation.y, initRotation.z);
        // transform.RotateAround(transform.position, transform.forward, range * Mathf.Sin(Time.time*speed));
    }
}
