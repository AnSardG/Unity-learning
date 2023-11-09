using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    //References
    CharacterController cc;
    //Variables
    Vector3 moveTo, move;

    //Public
    public float speed = 5f;    
    public float gravity = 20f;
    public float jumpForce = 15f;

    public float laneSize = 3f;
    int currentLane = 0;


    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Capturo inputs
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane != -1)
        {
            moveTo += Vector3.left * laneSize;
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane != 1)
        {
            moveTo += Vector3.right * laneSize;
            currentLane++;
        }

        if (Input.GetKeyDown(KeyCode.Space) && cc.isGrounded)
        {
            move.y = jumpForce;
        }

        //Restamos la posición actual a la que nos queremos mover para no salirnos del límite
        move.x = (moveTo - transform.position).x * speed;

        if (!cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                move.y = -jumpForce;
            } else
            {
                move.y -= gravity * Time.deltaTime;
            }            
        }

        cc.Move(move * Time.deltaTime);
    }
}
