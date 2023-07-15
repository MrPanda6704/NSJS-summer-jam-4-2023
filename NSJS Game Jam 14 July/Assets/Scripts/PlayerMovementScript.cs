using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class movementScript : MonoBehaviour
{
    public bool isGrounded = true;
    public bool isFlying = false;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private Vector2 movement;
    [SerializeField]
    private float jumpHeight = 8f;
    [SerializeField]
    float movespeed = 5f;
    [SerializeField]
    float wingStrength = 50f;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(movement.x * movespeed, rigidBody.velocity.y);
        if (isGrounded && movement.y >0)
        {
            rigidBody.velocity += Vector2.up * jumpHeight;
            isGrounded = false;
        }

        else if (movement.y > 0f && isFlying == false && rigidBody.velocity.y <=0 )
        {
            rigidBody.gravityScale = wingStrength * 0.01f;
            isFlying = true;
        }

        else if (movement.y < 0f)
        {
            rigidBody.gravityScale = 1;
            isFlying = false;
        }



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

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Ground")
        {
            isGrounded = true;
            isFlying = false;
            rigidBody.gravityScale = 1;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }


}
