using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject lastLevelSpawned, levelToSpawn;
    public GameObject[] levels;

    // Lo llamará deletelevel
    public void Spawn()
    {
        int r = Random.Range(0, levels.Length);
        // Instanciar nuevo nivel en el spawnpoint del último nivel instanciado
        lastLevelSpawned = Instantiate(levels[r], 
            lastLevelSpawned.GetComponent<LevelController>().GetSpawnPointPosition(), 
            Quaternion.identity);
    }
}
