using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //References
    CharacterController characterController;
    public GameObject gorrito, gameManager;

    //Public
    public float playerSpeed = 5f, jumpForce = 10f, gravity = 50f;

    public int health = 3;
    public int coinsEarned;

    //Movement management
    Vector3 movement;
    float moveX, moveY, moveZ;    
    private int vecesSalto;
    float yHeight;

    //Immunity management
    bool immune = false;
    public float immunityTime = 2f;

    //Growth management;
    bool grown = false;
    public float grownTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RestartLevel(health <= 0);

        Move();
        Jump();
        
        //Powerups logic
        ManageScale(grown);
        gorrito.SetActive(immune);
        
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

    private void RestartLevel(bool isDead)
    {
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {            
            SceneManager.LoadScene(0);            
            Time.timeScale = 1;
            gameManager.GetComponent<GameManager>().RespawnPlayer();
        }
    }

    private void DeactivateImmunity()
    {
        immune = false;
    }

    private void DeactivateGrowth()
    {
        grown = false;
    }

    private void ManageScale(bool grown)
    {
        if (grown)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * 2, Time.deltaTime * grownTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, Time.deltaTime * grownTime);
        }
    }


    //Public Methods
    public void TakeDamage(int dmg)
    {
        if (!immune)
        {
            health -= dmg;

            if (health <= 0)
            {
                Time.timeScale = 0;
            }
        }        
    }

    public void EarnCoins(int coinValue)
    {
        coinsEarned += coinValue;
    }

    public void Immunity()
    {
        immune = true;

        Invoke("DeactivateImmunity", immunityTime);
    }

    public void GrowUp()
    {
        grown = true;

        Invoke("DeactivateGrowth", grownTime);
    }
    
}
