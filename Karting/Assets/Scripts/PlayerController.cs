using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //VARS
    float horizontal, vertical, speed, aceleracionOriginal, speedBoosted, timePassed;
    bool slowed, boosted, canFire;
    Vector3 rot;

    //PUBLIC
    public float rotationSpeed = 0.5f, aceleracion, desaceleracion, slowQnty, fireRate = .5f;
    public int playerNumber;
    public Transform firePointPosition;
    public GameObject projectilePrefab;    

    //REFERENCES
    Rigidbody rb;

    //METHODS

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aceleracionOriginal = aceleracion;
    }
    
    void Update()
    {
        GetHorizontalInput();
        GetVerticalInput();
        GetFireInput();
        CheckSlows();

        
    }

    private void GetFireInput()
    {
        timePassed += Time.deltaTime;               

        canFire = timePassed >= fireRate;

        if (canFire 
            && (playerNumber == 1 && Input.GetKeyDown(KeyCode.Space) 
            || playerNumber == 2 && Input.GetKeyDown(KeyCode.Mouse0)))
        {
            timePassed = 0;

            Instantiate(projectilePrefab, firePointPosition.transform.position, firePointPosition.transform.rotation);                       
        }
    }

    private void CheckSlows()
    {
        aceleracion = slowed ? Mathf.Lerp(aceleracion, slowQnty, 2f) : aceleracionOriginal;        
    }

    void FixedUpdate()
    {
        if(Math.Abs(speed) > 0)
        {
            if (!boosted)
            {
                rb.AddForce(transform.forward * speed);
            } else
            {
                rb.AddForce(transform.forward * speedBoosted);
            }            

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

        if(vertical > 0)
        {
            if (slowed)
            {
                speed = slowQnty * vertical;
            } else
            {
                speed = aceleracion * vertical;
            }
        } else
        {
            speed = desaceleracion * vertical;
        }
        
    }

    private void GetHorizontalInput()
    {
        float newRot;

        horizontal = Input.GetAxis("Horizontal" + playerNumber);
        newRot = horizontal * rotationSpeed;
        rot = new Vector3(0f, newRot, 0f);

    }

    public void SlowPlayer()
    {
        slowed = true;
        Invoke("StopSlow", 3f);
    }

    private void StopSlow()
    {
        slowed = false;
    }

    public void BoostSpeed(float boost)
    {
        boosted = true;
        speedBoosted = boost;
        Invoke("ResetBoost", .5f);
    }

    private void ResetBoost()
    {
        boosted = false;
    }
}
