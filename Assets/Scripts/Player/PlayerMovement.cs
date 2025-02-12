using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float distanceCheckJump;
    [SerializeField] private LayerMask ground;

    [SerializeField] private float rotationSpeed;

    private float xRotation;
    private float yRotation;

    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    bool isGrounded;
    Vector3 direction;
    Vector3 velocity;

    [SerializeField] private Camera cam;
    CharacterController controller;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, distanceCheckJump, ground);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        CameraRotation();
    }

    private void Movement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        direction = (hInput * cam.transform.right + vInput * cam.transform.forward).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Quaternion toRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

        }

        animator.SetFloat("velocity", direction.magnitude);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("velocity", direction.magnitude * 2);
        }
    }

    private void Jump()
    {
        animator.SetTrigger("isJumping");
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
    }


    private void CameraRotation()
    {
        // Input Mouse while move with direction X & Y
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Set value mouseX plus for direction Y and mouse Y minus for direction X (If  it's opposite, it will reverse direction)
        yRotation += mouseX;
        xRotation -= mouseY;

        // Limited xRotation between -90 and 90
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        // Camera Rotate follow X & Y direction
        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

}
