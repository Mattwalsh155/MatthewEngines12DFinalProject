using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Ball : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameManager gameManager;
    public PlayerController playerRef;
    public Enemy enemyRef;
    public GameObject playerNet;
    public GameObject enemyNet;
    public GameObject player;
    public GameObject enemy;
    public GameObject ball;
    public Rigidbody2D rigidbodyBall;
    public bool isGameOver = false;
    public int forceRange; 

    public Vector3 startingPosBall;

    // Start is called before the first frame update
    void Start()
    {
        startingPosBall = transform.position;

        forceRange = Random.Range(-1,2);
        rigidbodyBall.AddForce(Vector2.left * forceRange * 100);
        //Debug.Log(forceRange);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.x > 10 || ball.transform.position.x < -10)
        {
            ResetGamePos();
        }
        else if (ball.transform.position.y > 10 || ball.transform.position.y < -10)
        {
            ResetGamePos();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!isGameOver)
        {
            if (other.gameObject.tag == "EnemyNet")
            {
                scoreManager.playerScore++;
                Debug.Log("EnemyNet");
                scoreManager.UpdateScore();
                ResetGamePos();
                
            }
            else if (other.gameObject.tag == "PlayerNet")
            {
                scoreManager.enemyScore++;
                Debug.Log("PlayerNet");
                scoreManager.UpdateScore();
                ResetGamePos();
            }
        }
    }

    private void ResetGamePos()
    {
        ball.transform.position = startingPosBall;
        player.transform.position = playerRef.startingPosPlayer;
        enemy.transform.position = enemyRef.startingPosEnemy;
        rigidbodyBall.velocity = new Vector2(0,0);
        gameManager.startText.enabled = true;
        playerRef.PauseGame();

        forceRange = Random.Range(-1,2);
        rigidbodyBall.AddForce(Vector2.left * forceRange * 100);
    }
}
