using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //References
    public Transform waypointA, waypointB;

    //Public
    public float speed = 5f;

    
    // Update is called once per frame
    void Update()
    {        
        
        transform.position = Vector3.forward * speed * Time.deltaTime;        
        
    }
}
