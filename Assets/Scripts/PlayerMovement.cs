using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;
    private float MouseX;
    private Vector3 angleVelocity;

    // Speed at which the player moves.
    public float speed = 10f;
    public float jumpForce = 20f;
    public float rotateSensitivity = 200f;

    // Start is called before the first frame update.
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();
        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void OnJump()
    {
        if (isGrounded())
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void Update()
    {
        MouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, MouseX * rotateSensitivity * Time.deltaTime, 0);
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs

        Vector3 fwdMovement = transform.forward * movementY;
        Vector3 rightMovement = transform.right * movementX;

        Vector3 movement = fwdMovement + rightMovement;
        movement.Normalize();
        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.3f);
    }
}