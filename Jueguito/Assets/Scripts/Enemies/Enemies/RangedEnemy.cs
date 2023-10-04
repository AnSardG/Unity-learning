using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxColl;
    [SerializeField] private float colliderHeight;

    [Header("Ranged Attack")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    [Header("Player Parameters")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("rangedAttack");
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }

    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        int fireballPosition = FindFireball();
        fireballs[fireballPosition].transform.position = firePoint.position;
        fireballs[fireballPosition].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxColl.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColl.bounds.size.x * range, boxColl.bounds.size.y * colliderHeight, boxColl.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColl.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColl.bounds.size.x * range, boxColl.bounds.size.y * colliderHeight, boxColl.bounds.size.z));
    }
}
