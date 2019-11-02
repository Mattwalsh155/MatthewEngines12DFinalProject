using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rigidbodyPlayer;
    public Animator animatorPlayer;
    private float horizontalMovement;
    private float verticalMovement;
    public float moveSpeed;
    static int defaultMoveSpeed = 5;
    public bool isMoving = false;

    public Vector3 startingPosPlayer;

    // Start is called before the first frame update
    void Start()
    {
        startingPosPlayer = transform.position;

        PauseGame();
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
    }

    private void Update() 
    {
        moveSpeed = defaultMoveSpeed;

        ResetAnimDirection(); 

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            //UnpauseGame();
            isMoving = true;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (horizontalMovement < 0)
                {
                    animatorPlayer.SetBool("West", true);
                }
                else 
                {
                    animatorPlayer.SetBool("East", true);
                }
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (verticalMovement > 0)
                {
                    animatorPlayer.SetBool("North", true);
                }
                else 
                {
                    animatorPlayer.SetBool("South", true);
                }
            }
            else 
            {
                isMoving = false;
            }
        }  

        if (Input.GetKeyDown(KeyCode.Return))
        {
            UnpauseGame();
        }
    }

   private void FixedUpdate() 
   {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        rigidbodyPlayer.velocity = new Vector2(horizontalMovement * moveSpeed, verticalMovement * moveSpeed);    
   }

   private void ResetAnimDirection()
   {
       animatorPlayer.SetBool("North", false);
       animatorPlayer.SetBool("South", false);
       animatorPlayer.SetBool("East", false);
       animatorPlayer.SetBool("West", false);
   }

   public void PauseGame()
   {
       Time.timeScale = 0;
   }

   public void UnpauseGame()
   {
       gameManager.startText.enabled = false;
       Time.timeScale = 1;
   }
}
