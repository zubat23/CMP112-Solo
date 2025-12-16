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

    public AudioClip damageSound;

    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;
    private float MouseX;

    //Stores health and if the player is vulnerable
    [SerializeField] float health = Global.maxHealth;
    [SerializeField] bool invulnerable = false;

    [SerializeField] float currentMaxHealth = Global.maxHealth;


    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();

        //Set up health UI appropriately
        healthText.text = "Health: " + health.ToString() + "/" + Global.maxHealth.ToString();
    }
    private void Update()
    {
        if (Global.waveActive)
        {
            //Update health UI and rotate the player, if there are enemies.
            healthText.text = "Health: " + health.ToString() + "/" + Global.maxHealth.ToString();
            MouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, MouseX * rotateSensitivity * Time.deltaTime, 0);
        }
        else
        {
            //Reset health between waves.
            health = Global.maxHealth;
        }
        if (currentMaxHealth != Global.maxHealth)
        {
            health = Global.maxHealth;
            currentMaxHealth = Global.maxHealth;
        }
    }

    private void FixedUpdate()
    {
        if (Global.waveActive)
        {
            // Create a 3D movement vector using the X and Y inputs

            Vector3 fwdMovement = transform.forward * movementY;
            Vector3 rightMovement = transform.right * movementX;

            Vector3 movement = fwdMovement + rightMovement;
            movement.Normalize();

            // Move the position of the Rigidbody based on the movement vector, speed, and time.
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
        //Check if the player is able to jump, if yes then apply force.
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
        //If the player is hit whilst vulnerable, make them take damage.
        if (other.gameObject.CompareTag("EnemyHitbox") && !invulnerable)
        {
            health -= other.gameObject.GetComponentInParent<EnemyAI>().damage;
            healthText.text = "Health: " + health.ToString() + "/" + Global.maxHealth.ToString();

            SfxManager.Instance.PlaySound(damageSound, transform, 1f);
            StartCoroutine(IFrames());
            Debug.Log("Player Health: " + health);

            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Sea"))
        {
            //Ensure the player is repositioned if they clip out of bounds.
            transform.position = new Vector3(transform.position.x, 20, transform.position.z);
        }
    }

    IEnumerator IFrames()
    {
        //Make the player invulnerable for 0.5 seconds after being hit.
        invulnerable = true;
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }
}