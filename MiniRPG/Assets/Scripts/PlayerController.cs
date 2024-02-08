using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PRIVATE VARS
    float vertical, horizontal, time, elapsedTime, stepTime;
    bool canFire, canMove = true, isMoving;
    private DirectionChecker dCheck;
    private Vector3 targetPosition;

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

    // PUBLIC VARS
    public float speed = 10f, fireArrowCd = 2f, stepInterval = 1f, stepCooldown = 1f;
    public int health = 3, arrowDamage = 1;
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

    
    void Start()
    {
        dCheck.ResetDirections();
        dCheck.up = true;
        targetPosition = transform.position;
    }

    
    void Update()
    {
        Move();
        ChangeDirectionChecker();
        CheckCooldowns();
        GetFireInput();
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

        if (!isMoving && canMove)
        {
            stepTime = 0;
            // Fijamos la posición objetivo dependiendo del input y las colisiones.
            if (vertical > 0 && !cCheck.up)
            {
                targetPosition += Vector3.up * speed * Time.deltaTime;
            }
            else if (vertical < 0 && !cCheck.down)
            {
                targetPosition += Vector3.down * speed * Time.deltaTime;
            }
            else if (horizontal > 0 && !cCheck.right)
            {
                targetPosition += Vector3.right * speed * Time.deltaTime ;
            }
            else if (horizontal < 0 && !cCheck.left)
            {
                targetPosition += Vector3.left * speed * Time.deltaTime;
            }

            // Comenzamos a mover al personaje is la dirección objetivo se ha visto modificada en relación a la posición del personaje.
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

    private void ChangeDirectionChecker()
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
            Instantiate(arrow, firePointPosition.transform.position, ManageArrowDirection());
            GameObject.FindWithTag("Arrow").GetComponent<Projectile>().SetDamage(arrowDamage);
        }        
    }    
}
