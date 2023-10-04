using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int coins = 0;
    private Health playerHealth;
    [SerializeField] private Text coinText;
    [SerializeField] private Image wingsImage;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            if (playerHealth.IsDamaged())
            {
                Destroy(collision.gameObject);
                playerHealth.HealDamage(1);
            }            
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins = coins + (int)Random.Range(1, 5); ;            
            coinText.text = "x " + coins;            
        }
        if (collision.gameObject.CompareTag("FlyBuff"))
        {
            Destroy(collision.gameObject);
            wingsImage.enabled = true;
            GetComponent<PlayerMovement>().IncrementFlyTime();
        }
    }
}
