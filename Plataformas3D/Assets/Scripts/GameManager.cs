using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //References
    public GameObject playerSpawnPoint, player;


    void Start()
    {
        RespawnPlayer();
    }   

    public void RespawnPlayer()
    {
        player.transform.position = playerSpawnPoint.transform.position;
    }
    
}
