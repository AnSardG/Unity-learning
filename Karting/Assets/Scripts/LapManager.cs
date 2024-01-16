using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    //PUBLIC
    public int playerNumber;

    //PRIVATE    
    private bool[] playersCheckpoints;

    //REFERENCES
    public GameManager gm;

    //public int[] players;

    
    void Start()
    {
        playersCheckpoints = new bool[playerNumber];   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCheckpoint(int playerNumber, string tag)
    {        
        if (tag == "Checkpoint")
        {            
            playersCheckpoints[playerNumber] = true;
        } else if (tag == "Meta" && playersCheckpoints[playerNumber])
        {
            playersCheckpoints[playerNumber] = false;
            gm.UpdatePlayerLap(playerNumber);            
        }        
    }
   
}
