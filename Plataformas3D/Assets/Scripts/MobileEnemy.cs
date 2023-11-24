using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileEnemy : MonoBehaviour
{
    //References
    public Transform waypointA, waypointB;

    //Public    
    public int damage = 1;
    public float damageCountdown = 2f;
    public float speed = 5f;

    private float lastTimeDamaged = 0f;    
    private bool movingRight = true;


    void Update()
    {
        lastTimeDamaged += Time.deltaTime;
        moveEnemy();
        transform.Rotate(Vector3.up);        
    }

    void moveEnemy()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        movingRight = other.gameObject == waypointB.gameObject;

        if (other.gameObject.CompareTag("Player") && lastTimeDamaged > damageCountdown)
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
            lastTimeDamaged = 0f;
            movingRight = !movingRight;
        }
    }
}
