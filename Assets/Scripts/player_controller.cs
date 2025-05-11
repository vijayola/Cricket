using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float move_speed = 2f;
    
    private CharacterController controller;
    [SerializeField] private Transform cam;

    private float xRotation = 0f;

    [SerializeField] private float gravity = -9.81f;
    
    Vector3 velocity;
    
    bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    
    float groundRadius = 0.4f;
    
    
    [SerializeField] float jumpHeight = 2f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Lock cursor to center
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        Jump();
        
        // change velocity according to gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        // check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        //Debug.Log("is_grounded :" + isGrounded);
    }

    void Jump()
    {
        if (isGrounded & Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    
    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    
    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal") * mouseSensitivity * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * mouseSensitivity * Time.deltaTime;
        
       Vector3 move = transform.right * x + transform.forward * y;
       
       controller.Move(move * move_speed);
    }
}
