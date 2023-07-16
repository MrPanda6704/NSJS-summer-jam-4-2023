using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class bulletMoveScript : MonoBehaviour
{
    private fireballSFX soundScript;
    private movementScript player;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    float bulletSpeed;
    public float dir;
    private string tag = "PlayerDevil";

    // Start is called before the first frame update
    void Awake()
    {
        soundScript = GetComponent<fireballSFX>();
        soundScript.playShoot();
        player = GameObject.FindGameObjectWithTag(tag).GetComponent<movementScript>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (player.isFacingRight == true)
        {
            spriteRenderer.flipX = false;
            dir = 1;
        }
        else if (player.isFacingRight == false)
        {
            spriteRenderer.flipX = true;
            dir = -1;
        }
        rigidBody.velocity = new Vector2(dir * bulletSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        soundScript.playCollision();
        if (collider.gameObject.tag == "Destructible")
        {
            collider.gameObject.SetActive(false);
        }
        Destroy(gameObject);
        
    }

}
