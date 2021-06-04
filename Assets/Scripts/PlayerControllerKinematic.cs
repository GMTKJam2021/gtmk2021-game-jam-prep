using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerKinematic : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    private float moveSpeed = 3;
    [SerializeField]
    private float jumpHeight = 2f;
    [SerializeField]
    private float timeToJumpApex = 0.5f;

    private float gravity, jumpVelocity;

    public const string RIGHT = "right";
    public const string LEFT = "left";

    string buttonPressed;
    bool isJumping = true;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        gravity = 2 * jumpHeight / (timeToJumpApex * timeToJumpApex);
        jumpVelocity = gravity * timeToJumpApex;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            buttonPressed = RIGHT;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            buttonPressed = LEFT;
        }
        else
        {
            buttonPressed = null;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpVelocity);
        }
    }

    private void FixedUpdate()
    {
        if (buttonPressed == RIGHT)
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        else if (buttonPressed == LEFT)
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }

        if (isJumping)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y - (gravity * Time.fixedDeltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            isJumping = false;
        }
    }
}
