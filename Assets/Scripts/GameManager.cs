using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject game;
    public GameObject enemy;
    public GameObject playerTwo;
    public Text startText;
    public Text winText;
    public Text loseText;

    public Toggle playerCount;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        game.SetActive(false);

        startText.enabled = true;
        winText.enabled = false;
        loseText.enabled = false;
        SinglePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerWin()
    {
        startText.enabled = false;
        winText.enabled = true;
        loseText.enabled = false;
    }

    public void EnemyWin()
    {
        startText.enabled = false;
        winText.enabled = false;
        loseText.enabled = true;
    }

    public void PlayGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
    }

    public void SinglePlayer()
    {
        bool temp = (playerCount.isOn) ? MultiPlayer() : Single();
        playerTwo.SetActive(temp);
        enemy.SetActive(!temp);
    }

    public bool Single(){
        
        return false;
    }

    public bool MultiPlayer()
    {
        return true;
    }
}
