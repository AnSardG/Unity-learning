using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollector : MonoBehaviour
{
    //VAR

    //METHODS
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyParent") || collision.CompareTag("HeartParent") || collision.CompareTag("CoinParent")){
            Destroy(collision.gameObject);
        }
    }
}
