using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDynamic : MonoBehaviour
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
    bool isJumping;

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

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
            rb2d.AddForce(new Vector2(0f, jumpVelocity), ForceMode2D.Impulse);
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
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isJumping = false;
        }
    }
}
