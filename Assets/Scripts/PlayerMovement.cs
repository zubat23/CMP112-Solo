using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    // Speed at which the player moves.
    public float speed = 10f;
    public float jumpForce = 5f;
    public float rotateSensitivity = 200f;

    public TextMeshProUGUI healthText;
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;
    private float MouseX;

    private float health = Global.maxHealth;
    private bool invulnerable = false;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        
        healthText.text = "Health: " + health.ToString() + "/" + Global.maxHealth.ToString();
    }
    private void Update()
    {
        if (Global.waveActive)
        {
            MouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, MouseX * rotateSensitivity * Time.deltaTime, 0);
        }
        else
        { 
            health = Global.maxHealth;
            healthText.text = "Health: " + health.ToString() + "/" + Global.maxHealth.ToString();
        }
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        if (Global.waveActive)
        {
            // Create a 3D movement vector using the X and Y inputs

            Vector3 fwdMovement = transform.forward * movementY;
            Vector3 rightMovement = transform.right * movementX;

            Vector3 movement = fwdMovement + rightMovement;
            movement.Normalize();

            // Apply force to the Rigidbody to move the player.
            rb.MovePosition(rb.position + movement * speed * Global.playerSpeedMult * Time.fixedDeltaTime);
        }
    }


    // This function is called when a move input is detected.
    public void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();
        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    public void OnJump()
    {
        if (isGrounded() && Global.waveActive)
        {
            rb.AddForce(transform.up * (jumpForce * Global.playerJumpForceMult), ForceMode.Impulse);
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyHitbox") && !invulnerable)
        {
            health--;
            healthText.text = "Health: " + health.ToString() + "/" + Global.maxHealth.ToString();
            StartCoroutine(IFrames());
            Debug.Log("Player Health: " + health);

            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Sea"))
        {
            transform.position = new Vector3(0, 20, 0);
        }
    }

    IEnumerator IFrames()
    {
        invulnerable = true;
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }
}