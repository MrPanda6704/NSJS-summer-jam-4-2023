using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DarkPlayerMovementScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    public float moveSpeed = 5f;

    // connecting to rb
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
    //moving the player
    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(movement.x, movement.y) * moveSpeed;
    }

    //taking player input
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
