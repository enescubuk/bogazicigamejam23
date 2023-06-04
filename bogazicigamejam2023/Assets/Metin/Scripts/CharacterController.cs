using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float movementSpeed = 5f;  // Movement speed of the character

    private Rigidbody rb;             // Reference to the character's Rigidbody

    private void Start()
    {
        // Get the Rigidbody component attached to the character
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // Apply movement to the character
        rb.velocity = movement * movementSpeed;
    }
}
