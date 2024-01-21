using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //PUBLIC
    public float travelSpeed = 5f;



    void Start()
    {
        Destroy(gameObject, 3f);
    }
    
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * travelSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().SlowPlayer();
        }
    }
}
