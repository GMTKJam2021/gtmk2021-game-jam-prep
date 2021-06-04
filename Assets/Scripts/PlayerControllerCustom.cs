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
    bool isJumping;

    void Awake()
    {
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
        Debug.Log(buttonPressed);
    }

    private void FixedUpdate()
    {
        if (buttonPressed == RIGHT)
        {
            transform.Translate(Vector2.right * (Time.fixedDeltaTime * moveSpeed), space);
        }
        else if (buttonPressed == LEFT)
        {
            transform.Translate(Vector2.left * (Time.fixedDeltaTime * moveSpeed), space);
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
