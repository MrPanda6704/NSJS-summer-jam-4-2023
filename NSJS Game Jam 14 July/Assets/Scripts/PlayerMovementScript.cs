using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    private Vector3 spawn;
    public GameObject other_character;
    public int killbox_distance;
    public GameObject goal;
    public float goal_range;
    public string nextscene;

    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawn = transform.position;
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
        Vector3 target = goal.transform.position;
        Vector3 diff = target - transform.position;
        float distance = diff.magnitude;
        Vector3 other = other_character.transform.position;
        Vector3 diff2 = target - other;
        float distance2 = diff2.magnitude;
        if (distance < goal_range && distance2 < goal_range)
        {
            print("here");
            SceneManager.LoadScene(nextscene);
        }

        if (transform.position.y > killbox_distance || transform.position.y < -killbox_distance)
        {
            transform.position = spawn;
            other_character.transform.position = other_character.GetComponent<movementScript>().spawn;
        }

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
        //if (collider.gameObject.name == "Ground")
        //{
            isGrounded = true;
            isFlying = false;
            rigidBody.gravityScale = 1 * oreo;
        //}
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }


}
