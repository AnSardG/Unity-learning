using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxJumpHeight = 5;
    [SerializeField] float minJumpHeight = 1;
    [SerializeField] float timeToJumpApex = .4f;
    [SerializeField] float moveSpeed = 9;
    [SerializeField] float flySpeed = 10;
    [SerializeField] float flyTime = 50f;
    [SerializeField] Slider flyEnergyBar;

    float accelerationTimeAirborne = .1f;
    float accelerationTimeGrounded = .04f;
    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    float flyEnergy = 100f;
    float flyRecovery;
    Vector3 velocity;
    float velocityXSmoothing;
    bool flyInputPressed = true;

    Controller2D controller;
    Vector2 directionalInput;

    void Start()
    {
        controller = GetComponent<Controller2D>();        
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);        
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        flyRecovery = flyTime;
    }

    private void Update()
    {
        CalculateVelocity();
        if(Input.GetKeyDown(KeyCode.E) && flyEnergy > 20f)
        {
            flyEnergy -= 10;
        }
        if (Input.GetKey(KeyCode.E) && flyEnergy > 0f)
        {
            OnFlyInputDown();
            if(flyEnergy <= 2f && flyInputPressed)
            {                
                OnFlyInputUp();
                flyEnergy = -50f;
                flyInputPressed = false;    
            }
        }
        else if (Input.GetKeyUp(KeyCode.E) && flyEnergy > 11f)
        {
            OnFlyInputUp();
            flyInputPressed = true;
            if (flyEnergy < 100)
            {
                flyEnergy += Time.deltaTime * (flyRecovery / 2);
            }            
        }
        else
        {
            controller.Move(velocity * Time.deltaTime, directionalInput);
            if (flyEnergy < 100)
            {
                flyInputPressed = true;
                flyEnergy += Time.deltaTime * (flyRecovery / 2);
            }
        }        

        if (controller.collisions.above || controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0;
            }
        }

        if (flyEnergy >= 0 || flyEnergy <= 100)
        {
            flyEnergyBar.value = flyEnergy;            
        }
    }

    public void SetDirectionalInput (Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        if (controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {                
                if(directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                //not jumping against max slope
                {
                    velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
                    velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
                }
            }
            else
            {
                velocity.y = maxJumpVelocity;
            }
            
        }
        
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    void OnFlyInputDown()
    {        
        float dirY = flySpeed * Time.deltaTime;
        float dirX = Input.GetAxis("Horizontal") * Time.deltaTime * flySpeed;
        flyEnergy -= Time.deltaTime * flyTime;        
        if(flyEnergy > 0)
        {
            controller.Move(transform.TransformDirection(new Vector2(dirX, dirY)), directionalInput);
        }        
    }

    void OnFlyInputUp()
    {
        velocity.y = 0;
    }

    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;

        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, 
            (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }

    public bool canAttack()
    {
        return GetComponent<PlayerAnimations>().IsGrounded();
    }

    public float RangedAttackOrder()
    {
        float energySpent = GetComponent<PlayerAttack>().RangedAttack();
        flyEnergy -= energySpent;
        return energySpent;
    }

    public void IncrementFlyTime()
    {
        flyTime -= 20f;
        flyRecovery += 10f;
    }
}
