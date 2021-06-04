using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerKinematic : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    private float moveSpeed = 3;

    public const string RIGHT = "right";
    public const string LEFT = "left";

    string buttonPressed;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
    }

    private void FixedUpdate()
    {
        if (buttonPressed == RIGHT)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0f);
        }
        else if (buttonPressed == LEFT)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0f);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
