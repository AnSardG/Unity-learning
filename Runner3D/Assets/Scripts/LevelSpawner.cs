using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject lastLevelSpawned, levelToSpawn;


    // Lo llamar� deletelevel
    public void Spawn()
    {
        // Instanciar nuevo nivel en el spawnpoint del �ltimo nivel instanciado
        lastLevelSpawned = Instantiate(levelToSpawn, 
            lastLevelSpawned.GetComponent<LevelController>().GetSpawnPointPosition(), 
            Quaternion.identity);
    }
}
