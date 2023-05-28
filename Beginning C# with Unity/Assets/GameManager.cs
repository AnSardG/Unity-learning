using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearningObjects;
using Beginning.CSharp;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnDisable()
    {
        Alien alien = new Alien();
        alien.HitPoints = 100;

        Alien anotherAlien = alien;
        alien.HitPoints = 150;
        
        Debug.Log("Alien 1 hit points: " + alien.HitPoints);
        Debug.Log("Alien 2 hit points: " + anotherAlien.HitPoints);

        Player playerOne = new Player();
        playerOne.Name = "Brian";

        Player playerTwo = playerOne;
        playerTwo.Name = "Max";
        
        Debug.Log("Player 1 name: " + playerOne.Name);
        Debug.Log("Player 2 name: " + playerTwo.Name);

        playerOne = null;
        Debug.Log("Player 2 name: " + playerTwo.Name);
    }
}
