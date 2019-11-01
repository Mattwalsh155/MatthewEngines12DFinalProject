using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public PlayerController player;
    public GameManager gameManager;
    public Ball ball;
    public TextMeshProUGUI scoreTextPlayer;
    public TextMeshProUGUI scoreTextEnemy;
    public int playerScore = 0;
    public int enemyScore = 0;

    //public GameObject player;
    //public GameObject enemy;
    //public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        // scoreTextPlayer = GetComponent<TextMeshProUGUI>();
        // scoreTextEnemy = GetComponent<TextMeshProUGUI>();
        UpdateScore();
    }

    public void UpdateScore()
    {
        //Debug.Log("working");
        scoreTextPlayer.text = "Player Score: " + playerScore.ToString();
        scoreTextEnemy.text = "Enemy Score: " + enemyScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateScore();

        if (playerScore >= 10)
        {
            gameManager.PlayerWin();
            ball.isGameOver = true;
            //Debug.Log("You Win");
            //you win!
            //display win screen
            player.PauseGame();
            gameManager.winText.enabled = true;
        }
        else if (enemyScore >= 10)
        {
            gameManager.EnemyWin();
            ball.isGameOver = true;
            //Debug.Log("You Lose");
            //opponent wins
            //display lose screen
            player.PauseGame();
            gameManager.loseText.enabled = true;
        }

        for (int i = 0; i <= 10; i++)
        {

        }
    }
}
