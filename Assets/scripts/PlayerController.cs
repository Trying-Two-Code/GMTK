using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Character Properties")]
    [SerializeField] private float maxSprintSpeed = 8f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float friction = 5f;
    [SerializeField] private float gravity = 9.81f;

    [Header("Camera Properties")]
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float maxLookUp = -90f;
    [SerializeField] private float maxLookDown = 90f;

    private CharacterController characterController;
    private Transform gimbalTransform;

    private Vector2 moveInput = Vector2.zero;
    private Vector2 mouseInput = Vector2.zero;
    private bool sprinting = false;

    private float xRotation = 0f;
    
    private Vector3 velocity = Vector2.zero;

    [Header("Components")]
    [SerializeField] private PlayerStats stats;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        gimbalTransform = transform.Find("Gimbal");
        if (gimbalTransform == null)
        {
            Debug.LogError("Gimbal not found. Please ensure there is a child GameObject named 'Gimbal'.");
        }

        // keep mouyse confined to center of screen
        Cursor.lockState = CursorLockMode.Locked;   
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        sprinting = Input.GetKey(KeyCode.LeftShift);

        CharacterUpdate();
        GimbalUpdate();
    }

    private void CharacterUpdate()
    {   
        transform.Rotate(mouseInput.x * sensitivity * Vector3.up);

        Vector3 moveDirection = (moveInput.x * transform.right + moveInput.y * transform.forward).normalized;
        velocity += acceleration * Time.deltaTime * moveDirection;
        characterController.Move(velocity * Time.deltaTime);

        if (characterController.isGrounded)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }

        velocity -= friction * Time.deltaTime * velocity;

        if (sprinting)
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSprintSpeed);
        }
        else
        {
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        
    }

    private void GimbalUpdate()
    {
        xRotation -= mouseInput.y * sensitivity;
        xRotation = Mathf.Clamp(xRotation, maxLookUp, maxLookDown);

        gimbalTransform.localEulerAngles = new Vector3(xRotation, 0f, 0f);
    }
}