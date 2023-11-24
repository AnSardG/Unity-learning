using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEnemy : MonoBehaviour
{
    //Public    
    public int damage = 1;
    public float damageCountdown = 2f;

    private float lastTimeDamaged = 0f;

    void Update()
    {
        lastTimeDamaged += Time.deltaTime;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && lastTimeDamaged > damageCountdown)
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
            lastTimeDamaged = 0f;
        }
    }
}
