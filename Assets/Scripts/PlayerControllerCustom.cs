using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerCustom : MonoBehaviour
{
    [SerializeField]
    private Space space = Space.Self;
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
    [SerializeField]
    bool isJumping = true;
    Vector2 velocity;

    void Awake()
    {
        gravity = 2 * jumpHeight / (timeToJumpApex * timeToJumpApex);
        jumpVelocity = gravity * timeToJumpApex;
        velocity = Vector2.zero;
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

        // Reenable once separation is coded
        /*if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            isJumping = true;
        }*/
    }

    private void FixedUpdate()
    {

        if (buttonPressed == RIGHT)
        {
            velocity = Vector2.right * (Time.fixedDeltaTime * moveSpeed);
        }
        else if (buttonPressed == LEFT)
        {
            velocity = -Vector2.right * (Time.fixedDeltaTime * moveSpeed);
        }
        else
        {
            velocity = Vector2.zero;
        }

        // Reenable once separation is coded
        /*if (isJumping)
        {
            velocity -= Vector2.up * (Time.fixedDeltaTime * gravity);
        }*/

        transform.Translate(velocity, space);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            velocity = new Vector2(velocity.x, 0f);
            isJumping = false;

            // TODO: Resolve collision
        }
    }
}
