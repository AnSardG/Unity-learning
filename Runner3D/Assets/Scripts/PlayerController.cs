using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //References
    CharacterController cc;
    //Variables
    Vector3 moveTo, move;

    //Public
    public int health = 3;

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
        MovePlayer();
            
    }
    
    void MovePlayer()
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

        move = IsGrounded(move);

        cc.Move(move * Time.deltaTime);
    }
    Vector3 IsGrounded(Vector3 move)
    {
        if (!cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                move.y = -jumpForce;
            }
            else
            {
                move.y -= gravity * Time.deltaTime;
            }
        }
        return move;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Hit detected with: " + hit.gameObject.name);

        if (hit.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy hit!");
            if (health > 0)
            {
                health--;
                if (health <= 0)
                {
                    Time.timeScale = 0;
                }
            }
        }
    }

}
