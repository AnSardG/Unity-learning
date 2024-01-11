using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //VARS
    float horizontal, vertical, speed;
    Vector3 rot;

    //PUBLIC
    public float rotationSpeed = 0.5f, aceleracion, desaceleracion;
    public int playerNumber;

    //REFERENCES
    Rigidbody rb;

    //METHODS

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        GetHorizontalInput();
        GetVerticalInput();
    }

    void FixedUpdate()
    {
        if(Math.Abs(speed) > 0)
        {
            rb.AddForce(transform.forward * speed);


            if(speed > 0)
            {
                rb.AddTorque(rot);
            } else
            {
                rb.AddTorque(-rot);
            }
        }
    }

    private void GetVerticalInput()
    {
        speed = 0;
        vertical = Input.GetAxis("Vertical" + playerNumber) ;
        speed = vertical > 0 ? aceleracion * vertical : desaceleracion * vertical;

        //if(vertical > 0 )
        //{ 
        //    speed = aceleracion * vertical;
        //} else
        //{
        //    speed = desaceleracion * vertical;
        //}

    }

    private void GetHorizontalInput()
    {
        float newRot;

        horizontal = Input.GetAxis("Horizontal" + playerNumber);
        newRot = horizontal * rotationSpeed;
        rot = new Vector3(0f, newRot, 0f);

    }
}
