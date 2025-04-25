using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float laneChangeSpeed = 5f; // How fast player switches lanes
    public float[] lanes = { -2f, 0f, 2f }; // X-positions for lanes
    public int currentLane = 1; // Start in middle lane (0 = left, 1 = middle, 2 = right)
    public float moveSpeedZ = 4f;

    [Header("Gravity")]
    public float gravityScale = 2f;
    float terminalVelocity = -20f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private Vector3 targetPosition; // Target X-position for lane
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        targetPosition = transform.position;    
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
        // Reset velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // Lane switching input
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0) currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < lanes.Length - 1) currentLane++;
        }

        // Calculate target X position (smoothly move toward lane)
        targetPosition.x = lanes[currentLane];
        Vector3 newPosition = new Vector3(
            Mathf.Lerp(transform.position.x, targetPosition.x, laneChangeSpeed * Time.deltaTime),
            transform.position.y,
            transform.position.z + moveSpeedZ * Time.deltaTime // Auto-forward
        );

        // Apply movement
        controller.Move(newPosition - transform.position);
       
        
        
        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity * 2);
            animator.SetBool("IsJumping", true);

        }

        // Apply gravity
        float appledGravity = -9.81f * gravityScale;
        velocity.y += appledGravity * Time.deltaTime;

        velocity.y = Mathf.Max(velocity.y, terminalVelocity);
        controller.Move(velocity * Time.deltaTime);
    }
}