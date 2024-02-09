using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //PRIVATE VARS
    float vertical, horizontal, time, elapsedTime, stepTime;
    bool canFire, canMove = true, isMoving, dead = false, attacking = false;
    private DirectionChecker dCheck;
    private Vectors vectors;
    private Vector3 targetPosition;
    private int maxHealth;    

    // Objeto donde guardamos la dirección a la que está mirando el personaje.
    private struct DirectionChecker
    {
        public bool up, down, left, right;
        
        public void ResetDirections()
        {
            up = false;
            down = false;
            left = false;
            right = false;
        }
    }   
    
    private struct Vectors
    {
        public Vector3 left, right, up, down;

        public void __Vectors()
        {
            left = Vector3.left;
            right = Vector3.right;
            up = Vector3.up;
            down = Vector3.down;
        }
    }

    // PUBLIC VARS
    public float speed = 10f, fireArrowCd = 2f, stepInterval = 1f, stepCooldown = 1f;
    public int health = 3, arrowDamage = 1, moneyEarned;
    public CollisionChecker cCheck;

    // Objeto donde guardamos las colisiones con paredes del personaje.
    public struct CollisionChecker
    {
        public bool up, down, left, right;

        public void ResetCollisions()
        {
            up = false;
            down = false;
            left = false;
            right = false;
        }
    }

    //REFERENCES
    public GameObject arrow, firePointPosition;
    public Animator anim;

    //PRIVATE Methods
    
    void Start()
    {
        dCheck.ResetDirections();
        vectors.__Vectors();
        dCheck.up = true;
        maxHealth = health;
        targetPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            Move();
            ChangeDirectionChecks();
            ManageAnimations();
        }        
    }

    void Update()
    {
        if (!dead)
        {                        
            
            CheckCooldowns();
            GetFireInput();            
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);            
        }
    }

    private void ManageAnimations(bool attack = false)
    {
        if (attack)
        {
            attacking = true;

            ResetAllIdleAnim();
            ResetAllRunAnim();

            if (dCheck.up)
            {
                anim.SetTrigger("AttackUp");
            }
            else if (dCheck.down)
            {
                anim.SetTrigger("AttackDown");
            }
            else if (dCheck.right)
            {
                anim.SetTrigger("AttackRight");
            }
            else if (dCheck.left)
            {
                anim.SetTrigger("AttackLeft");
            }

            Invoke("ResetAttackTrigger", 1f);
        }

        if (vertical == 0 && horizontal == 0)
        {
            ResetAllRunAnim();
            anim.SetBool("IdleUp", dCheck.up);
            anim.SetBool("IdleDown", dCheck.down);
            anim.SetBool("IdleRight", dCheck.right);
            anim.SetBool("IdleLeft", dCheck.left);            
        } else
        {
            ResetAllIdleAnim();
            anim.SetBool("MovingUp", dCheck.up);
            anim.SetBool("MovingDown", dCheck.down);
            anim.SetBool("MovingRight", dCheck.right);
            anim.SetBool("MovingLeft", dCheck.left);            
        }        
    }

    private void ResetAllIdleAnim()
    {
        anim.SetBool("IdleDown", false);
        anim.SetBool("IdleUp", false);
        anim.SetBool("IdleRight", false);
        anim.SetBool("IdleLeft", false);
    }

    private void ResetAllRunAnim()
    {
        anim.SetBool("MovingDown", false);
        anim.SetBool("MovingUp", false);
        anim.SetBool("MovingRight", false);
        anim.SetBool("MovingLeft", false);
    }    

    private void ResetAttackTrigger()
    {
        anim.SetTrigger("StopAttack");
        attacking = false;
    }

    private void CheckCooldowns()
    {
        time += Time.deltaTime;
        stepTime += Time.deltaTime;
        canFire = time >= fireArrowCd;
        canMove = stepTime >= stepCooldown;
    }

    void Move()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (!isMoving && canMove && !attacking)
        {
            stepTime = 0;
            // Fijamos la posición objetivo dependiendo del input y las colisiones.
            if (vertical > 0 && !cCheck.up)
            {
                targetPosition += vectors.up * speed * Time.deltaTime;
            }
            else if (vertical < 0 && !cCheck.down)
            {
                targetPosition += vectors.down * speed * Time.deltaTime;
            }
            else if (horizontal > 0 && !cCheck.right)
            {
                targetPosition += vectors.right * speed * Time.deltaTime ;
            }
            else if (horizontal < 0 && !cCheck.left)
            {
                targetPosition += vectors.left * speed * Time.deltaTime;
            }

            // Comenzamos a mover al personaje si la dirección objetivo se ha visto modificada en relación a la posición del personaje.
            if (transform.position != targetPosition)
            {
                isMoving = true;
            }
        }
        else
        {                
            // Con movetowards movemos al personaje a dicha dirección con un límite fijo especificado
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime / stepInterval);
            // Guardamos el tiempo que está tardando en llegar a dicha posición objetivo.
            elapsedTime += Time.deltaTime;

            // Si llega a la posición objetivo o ha cumplido el intervalo de pasos, deja de moverse.
            if (transform.position == targetPosition || elapsedTime >= stepInterval)
            {
                isMoving = false;
                elapsedTime = 0f;
            }            
        }
    }    

    private void ChangeDirectionChecks()
    {
        // Solo se reinician las direcciones si hay algún movimiento
        if (horizontal != 0 || vertical != 0)
        {
            dCheck.ResetDirections();

            if (horizontal > 0)
            {
                dCheck.right = true;
            }
            else if (horizontal < 0)
            {
                dCheck.left = true;
            }
            else if (vertical > 0)
            {
                dCheck.up = true;
            }
            else if (vertical < 0)
            {
                dCheck.down = true;
            }

            MoveFirePointPosition();
        }
    }

    private void MoveFirePointPosition()
    {
        if(dCheck.up)
        {
            firePointPosition.transform.position = new Vector3(transform.position.x, transform.position.y + .11f, transform.position.z);
        } else if (dCheck.down)
        {
            firePointPosition.transform.position = new Vector3(transform.position.x, transform.position.y + -.171f, transform.position.z);
        } else if (dCheck.left)
        {
            firePointPosition.transform.position = new Vector3(transform.position.x - .12f, transform.position.y - .06f, transform.position.z);
        } else if (dCheck.right)
        {
            firePointPosition.transform.position = new Vector3(transform.position.x + .12f, transform.position.y - .06f, transform.position.z);
        }
    }

    private Quaternion ManageArrowDirection()
    {
        Quaternion arrowDirection = Quaternion.identity;

        if(dCheck.down)
        {
            arrowDirection = Quaternion.Euler(0, 0, 180f);
        } else if (dCheck.left)
        {
            arrowDirection = Quaternion.Euler(0, 0, 90f);
        } else if (dCheck.right)
        {
            arrowDirection = Quaternion.Euler(0, 0, -90f);
        }

        return arrowDirection;
    }

    private void GetFireInput()
    {
        if (Input.GetAxis("Fire1") > 0 && canFire)
        {
            time = 0;
            ManageAnimations(true);
            Invoke("FireArrow", .4f);                  
        }        
    }    

    private void FireArrow()
    {
        Instantiate(arrow, firePointPosition.transform.position, ManageArrowDirection());
        GameObject.FindWithTag("Arrow").GetComponent<Projectile>().SetDamage(arrowDamage);
    }


    //PUBLIC Methods
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if(health < 1)
        {
            Time.timeScale = 0;
            dead = true;
        }
    }

    public void Heal(int hpRestorage)
    {
        if(health < maxHealth)
        {
            health += hpRestorage;            
            while(health > maxHealth)
            {
                health--;
            }
        }
    }

    internal void EarnMoney(int coinValue)
    {
        moneyEarned += coinValue;
    }
}
