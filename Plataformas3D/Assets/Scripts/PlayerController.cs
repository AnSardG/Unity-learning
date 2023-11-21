using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //References
    CharacterController characterController;

    //Public
    public float playerSpeed = 5f, jumpForce = 10f, gravity = 50f;
    public int health = 3;
    
    Vector3 movement;
    float moveX, moveY, moveZ;    
    private int vecesSalto;
    float yHeight;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        characterController.Move(movement * Time.deltaTime);
    }

    private void Jump()
    {
       
            if (characterController.isGrounded)
            {
                vecesSalto = 0;
                yHeight = -10;

                if (Input.GetButtonDown("Jump"))
                {
                    //Capturo la potencia del salto
                    yHeight = jumpForce;
                    vecesSalto++;
                }

            }
            else
            {
                if (Input.GetButtonDown("Jump") && vecesSalto < 2)
                {
                    yHeight = jumpForce;
                    vecesSalto++;
                }
                //Si no estoy en el suelo, baja según la gravedad
                yHeight -= gravity * Time.deltaTime;
            }

            //Salta según la potencia de salto que tiene
            movement.y = yHeight;
  
    }

    private void Move()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
  
        movement = new Vector3(moveX, 0, moveZ);

        //Para moverme en diagonal a la misma velocidad que en un eje
        movement = movement.normalized;
        movement *= playerSpeed;

    }

}
