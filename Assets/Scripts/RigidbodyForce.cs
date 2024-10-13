using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyForce : MonoBehaviour
{
    // Public field to assign the Rigidbody via Unity's GUI (Inspector)
    public Rigidbody rb;

    // Public variable to control the amount of force applied (adjustable in Inspector)
    public Vector3 forceDirection = new Vector3(1, 0, 0);  // Default force direction (x-axis)
    public float forceAmount = 10f;  // Adjustable force amount
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if Rigidbody is assigned
        if (rb != null)
        {
            // Apply a continuous force every frame in the specified direction
            rb.AddForce(forceDirection * forceAmount * Time.deltaTime, ForceMode.Force);
        }
    }
}
