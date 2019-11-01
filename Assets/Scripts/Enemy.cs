using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform ball;
    public Transform net;
    public Transform enemyTransform;
    public Transform ballMarker;
    public Vector3 newBallPos;
    public Rigidbody2D rigidbodyBall;
    public Rigidbody2D rigidbodyEnemy;
    public BoxCollider2D colliderEnemy;
    public Animator animatorEnemy;
    public int enemyMoveSpeed = 3;
    public int force;
    private float horizontalMovement;
    private float verticalMovement;
    private bool hasMadeContact = false;
    public Vector3 startingPosEnemy;
    // Start is called before the first frame update
    void Start()
    {
        //newBallPos = ballMarker.transform.position;
        startingPosEnemy = transform.position;

        net = GameObject.FindGameObjectWithTag("PlayerNet").transform;
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
        //ball.GetComponent<Transform>();
        rigidbodyBall = gameObject.GetComponent<Rigidbody2D>();
        colliderEnemy = gameObject.GetComponent<BoxCollider2D>();
        animatorEnemy = gameObject.GetComponent<Animator>();
        rigidbodyEnemy = gameObject.GetComponent<Rigidbody2D>();
        enemyTransform = gameObject.GetComponent<Transform>();
        ballMarker = gameObject.GetComponent<Transform>();


    }

    private void FixedUpdate() 
    {
        horizontalMovement = rigidbodyEnemy.velocity.x;
        verticalMovement = rigidbodyEnemy.velocity.y;    
    }
    // Update is called once per frame
    void Update()
    {
        if (!hasMadeContact)
        {
            float speed = enemyMoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, ball.position, speed);
            
        }
        else
        {
            float speed = enemyMoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, net.position, speed);
            //rigidbodyBall.AddForce(Vector2.down * 100);
            // colliderEnemy.enabled = false;
            // ball.transform.position = ballMarker.transform.position;
            // colliderEnemy.enabled = true;
            
        }

        ResetAnimation();
       
    //    if (horizontalMovement > 0)
    //    {
    //        animatorEnemy.SetBool("East", true);
    //    }
    //    else 
    //    {
    //        animatorEnemy.SetBool("West", true);
    //    }

       if (verticalMovement > 0)
       {
           animatorEnemy.SetBool("North", true);
       }
       else
       {
           animatorEnemy.SetBool("South", true);
       }
       
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.gameObject.tag == "Ball")
        {
            //rigidbodyBall.AddForce(Vector2.down * 100);
            hasMadeContact = true;   
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        hasMadeContact = false;
    }

    private void ResetAnimation()
    {
        animatorEnemy.SetBool("North", false);
        animatorEnemy.SetBool("South", false);
        animatorEnemy.SetBool("East", false);
        animatorEnemy.SetBool("West", false);
    }
}
