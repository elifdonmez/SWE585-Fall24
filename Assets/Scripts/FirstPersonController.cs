using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Movement speed
    public float gravity = -9.8f; // Gravity strength
    public float jumpHeight = 1.5f; // Jump height

    [Header("Mouse Settings")]
    public float mouseSensitivity = 2f; // Mouse sensitivity
    public Transform playerCamera; // Assign your camera in the Inspector
    public float maxLookAngle = 80f; // Limit vertical look angle

    private CharacterController characterController;
    private Vector3 velocity; // Current velocity for gravity
    private float verticalLookRotation; // Vertical rotation angle

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();

        // Optional: Unlock the cursor with Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void HandleMovement()
    {
        // Get input
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Calculate movement direction relative to player’s orientation
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Apply movement
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Handle gravity
        if (characterController.isGrounded)
        {
            velocity.y = -2f; // Reset gravity when grounded

            // Handle jumping
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // Apply gravity when in the air
        }

        // Apply vertical velocity (gravity)
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleMouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;

        // Horizontal rotation (player rotation)
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation (camera rotation)
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -maxLookAngle, maxLookAngle);
        playerCamera.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
    }
}
