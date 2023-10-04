using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Enemy references")]
    [SerializeField] private Health enemyHealth;
    [SerializeField] private Animator enemyAnimator;
    private bool movingLeft;
    private float lastHealth;

    private void Start()
    {
        lastHealth = enemyHealth.currentHealth;
    }

    private void Awake()
    {
        initScale = enemy.localScale;        
    }
    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }            
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
            
        }        
    }

    private void OnDisable()
    {
        enemyAnimator.SetBool("moving", false);
    }

    private void DirectionChange()
    {
        enemyAnimator.SetBool("moving", false);

        idleTimer += Time.deltaTime;
        if(enemyHealth.currentHealth < lastHealth)
        {
            idleTimer = idleDuration;
            lastHealth = enemyHealth.currentHealth;
        }
        if(idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }        
    }

    private void MoveInDirection (int _direction)
    {
        idleTimer = 0;
        enemyAnimator.SetBool("moving", true);
        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
