using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public int[] scores;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        int average = 0;
        foreach (int i in scores)
        {
            average += i;
        }

        average /= scores.Length;
        Debug.Log("The average of the scores is: " + average);
    }
}
