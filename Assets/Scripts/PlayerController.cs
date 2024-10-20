using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;   // Speed at which the object moves
    public Camera mainCamera;       // Reference to the main camera (drag the camera here in the Inspector)
    
    private Rigidbody rb;           // Rigidbody component

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the player
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
        float moveVertical = Input.GetAxis("Vertical");     // W/S or Up/Down Arrow

        // Get the camera's forward and right vectors
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        // Remove any vertical component (we only want movement on the XZ plane)
        forward.y = 0f;
        right.y = 0f;

        // Normalize the vectors to ensure consistent movement speed
        forward.Normalize();
        right.Normalize();

        // Calculate the movement direction based on input and the camera's orientation
        Vector3 movement = forward * moveVertical + right * moveHorizontal;

        // Apply force in the direction of the movement vector
        rb.AddForce(movement * moveSpeed);
    }
}
