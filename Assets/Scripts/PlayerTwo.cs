using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rigidbodyPlayerTwo;
    public Animator animatorPlayerTwo;
    private float horizontalMovement;
    private float verticalMovement;
    public float moveSpeed;
    static int defaultMoveSpeed = 5;
    public bool isMoving = false;

    public Vector3 startingPosPlayerTwo;
    // Start is called before the first frame update
    void Start()
    {
        startingPosPlayerTwo = transform.position;

        rigidbodyPlayerTwo = GetComponent<Rigidbody2D>();
        animatorPlayerTwo = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = defaultMoveSpeed;

        ResetAnimDirection();

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            isMoving = true;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (horizontalMovement < 0)
                {
                    animatorPlayerTwo.SetBool("West", true);
                }
                else
                {
                    animatorPlayerTwo.SetBool("East", true);
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                if (verticalMovement > 0)
                {
                    animatorPlayerTwo.SetBool("North", true);
                }
                else
                {
                    animatorPlayerTwo.SetBool("South", true);
                }
            }
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate() 
    {
        horizontalMovement = Input.GetAxisRaw("HorizontalTwo");
        verticalMovement = Input.GetAxisRaw("VerticalTwo");

        rigidbodyPlayerTwo.velocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);
    }

    private void ResetAnimDirection()
    {
        animatorPlayerTwo.SetBool("North", false);
        animatorPlayerTwo.SetBool("South", false);
        animatorPlayerTwo.SetBool("East", false);
        animatorPlayerTwo.SetBool("West", false);
    }
}
