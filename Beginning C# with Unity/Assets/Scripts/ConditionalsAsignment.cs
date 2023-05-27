using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class ConditionalsAsignment : MonoBehaviour
{
    public string[] name;
    private int[] score = new int[3];
    public bool[] playerAlive;
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void CalculateScores()
    {
        string message;
        textMesh.text = "";
        for (int i = 0; i < name.Length; i++)
        {
            score[i] = Random.Range(1, 10);
            message = name[i] + "'s score is: " + score[i]+". The player is ";
            if (playerAlive[i])
            {
                message += "alive.";
            }
            else
            {
                message += "dead.";
            }

            textMesh.text += message+"\n";
        }
    }
}
