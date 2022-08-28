using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public bool applyForce = false;
    public float forceFactor = 50.0f;
    public bool forceDirection = true;
    private void FixedUpdate() {
        if(applyForce) {
            if(forceDirection) {
                GetComponent<Rigidbody>().AddForce(transform.up * forceFactor, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(transform.right * forceFactor, ForceMode.Impulse);
            } else {
                GetComponent<Rigidbody>().AddForce(transform.up * forceFactor, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(-transform.right * forceFactor, ForceMode.Impulse);
            }
        }
    }
}
