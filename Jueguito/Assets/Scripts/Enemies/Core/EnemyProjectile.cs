using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifeTime;
    private Animator anim;
    private BoxCollider2D coll;
    private bool swapScale;
    private bool hit;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();        
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifeTime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;  
        if(lifeTime > resetTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        base.OnTriggerEnter2D(collision);
        coll.enabled = false;

        if (anim != null)
        {
            anim.SetTrigger("explode"); //When the object is a fireball explode it
        }
        else
        {
            gameObject.SetActive(false); //When this hits any object deactivate
        }

    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
