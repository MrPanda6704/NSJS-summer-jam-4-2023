using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class movementScript : MonoBehaviour
{
    private bool isGrounded = true;
    private bool isFlying = false;
    public bool on = false;
    public int oreo = 1;
    public bool flys = true;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    private Vector2 movement;
    [SerializeField]
    private float jumpHeight = 8f;
    [SerializeField]
    float movespeed = 5f;
    [SerializeField]
    float wingStrength = 50f;
    public bool isFacingRight;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (on == false)
        {
            return;
        }
        rigidBody.velocity = new Vector2(movement.x * movespeed, rigidBody.velocity.y);
        if (isGrounded && movement.y >0)
        {
            rigidBody.velocity += Vector2.up * jumpHeight * oreo;
            isGrounded = false;
        }

        else if (movement.y > 0f && isFlying == false && rigidBody.velocity.y <=0 && flys == true)
        {
            rigidBody.gravityScale = wingStrength * 0.01f * oreo;
            isFlying = true;
        }

        else if (movement.y < 0f)
        {
            rigidBody.gravityScale = 1 * oreo;
            isFlying = false;
        }



    }

    private void Update()
    {
        if(on == false)
        {
            return;
        }

        if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
            isFacingRight = true;
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
            isFacingRight = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "Ground")
        {
            isGrounded = true;
            isFlying = false;
            rigidBody.gravityScale = 1 * oreo;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }


}
