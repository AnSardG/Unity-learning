using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //PUBLIC
    public int playerNumber;
    public int maxLaps = 3;
    public Text[] lapTexts;

    //PRIVATE
    private int[] playerLaps;
    private bool gameOver = false;


    void Start()
    {
        playerLaps = new int[playerNumber];

        foreach (var text in lapTexts)
        {
            text.text = "0 / " + maxLaps;
        }
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }

    public void UpdatePlayerLap(int playerNum)
    {        
        playerLaps[playerNum]++;        
        CheckLaps();
    }

    private void CheckLaps()
    {
        int i = 0;

        UpdateLapsText();

        while (!gameOver && i < playerLaps.Length)
        {            
            gameOver = playerLaps[i] >= maxLaps;
            i++;
        }

        if (gameOver)
        {
            Time.timeScale = 0;            
        }
    }

    private void UpdateLapsText()
    {
        for (int i = 0; i < lapTexts.Length; i++)
        {
            lapTexts[i].text = playerLaps[i] + " / " + maxLaps;
        }
    }
}
