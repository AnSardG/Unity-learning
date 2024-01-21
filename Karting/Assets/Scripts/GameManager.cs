using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //PUBLIC
    public int playerNumber;
    public int maxLaps = 3;

    //PRIVATE
    private int[] playerLaps;
    private bool gameOver = false;


    void Start()
    {
        playerLaps = new int[playerNumber];
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
}
