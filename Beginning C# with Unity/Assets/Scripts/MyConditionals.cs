using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MyConditionals : MonoBehaviour
{
    public int myGuess;
    private int previousGuess, secretNumber;

    void Start()
    {
        secretNumber = Random.Range(1, 10);
    }

    void OnDisable()
    {
        Debug.Log("Secret number: " + secretNumber);
        if (myGuess != previousGuess && myGuess == secretNumber)
        {
            Debug.Log("You win!");
        } else if (myGuess > secretNumber)
        {
            Debug.Log("Too high");
        }
        else
        {
            Debug.Log("Too low");
        }

        previousGuess = myGuess;
    }
}
