using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public enum CollectableType { Heart, Coin }
    public CollectableType collectableType = CollectableType.Heart;
    public int hpRestorage = 1;
    public int coinValue = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if(collectableType == CollectableType.Heart)
            {
                collision.gameObject.GetComponent<PlayerController>().Heal(hpRestorage);
            } else if (collectableType == CollectableType.Coin)
            {
                collision.gameObject.GetComponent<PlayerController>().EarnMoney(coinValue);
            }
        }
    }
}
