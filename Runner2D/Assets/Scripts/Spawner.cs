using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //VAR
    float timePassed;
    [Range(0, 100)]
    public int rewardProbability, heartProbability;
    

    public float timeToSpawn = 2f;
    public GameObject[] enemies;
    public GameObject[] coins;
    public GameObject[] hearts;

    //METHODS
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > timeToSpawn)
        {
            int c = Random.Range(0, 101);
            if(c > rewardProbability)
            {
                int r = Random.Range(0, enemies.Length);
                int r2, r3;
                Instantiate(enemies[r], transform.position, Quaternion.identity);
                do
                {
                    r2 = Random.Range(0, enemies.Length);
                    r3 = Random.Range(0, enemies.Length);
                } while (r2 == r || r2 == r3 || r3 == r);
                Instantiate(enemies[r2], transform.position, Quaternion.identity);
                Instantiate(enemies[r3], transform.position, Quaternion.identity);
            } else
            {
                c = Random.Range(0, 101);
                if (c > heartProbability)
                {
                    int r = Random.Range(0, coins.Length);
                    Instantiate(coins[r], transform.position, Quaternion.identity);
                } else
                {
                    int r = Random.Range(0, hearts.Length);
                    Instantiate(hearts[r], transform.position, Quaternion.identity);
                }
                
            }
            timePassed = 0;

        }
    }
}
