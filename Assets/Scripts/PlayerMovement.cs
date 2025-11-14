using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private InputAction playerMove;

    private void OnEnable()
    {
        playerMove.Enable();
    }

    private void OnDisable()
    {
        playerMove.Disable();
    }

    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerM
    }
}
