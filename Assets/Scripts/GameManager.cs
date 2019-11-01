using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Text startText;
    public Text winText;
    public Text loseText;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        startText.enabled = true;
        winText.enabled = false;
        loseText.enabled = false;
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
}
