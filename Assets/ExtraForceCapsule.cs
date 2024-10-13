using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraForceCapsule : MonoBehaviour
{
    // Start is called before the first frame update
    public float forceAmount = 20f;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);  // Add upward force on start
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
