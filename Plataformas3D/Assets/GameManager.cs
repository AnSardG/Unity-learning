using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //References
    public GameObject playerSpawnPoint, player;


    void Start()
    {
        player.transform.position = playerSpawnPoint.transform.position;
    }
    
    void Update()
    {
        
    }
    
}
