using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRay : EnemyDamage
{
    private BoxCollider2D coll;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
    }    

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        DisableCollider();
    }

    public void EnableCollider()
    {
        coll.enabled = true;
    }

    public void DisableCollider()
    {
        coll.enabled = false;
    }
}
