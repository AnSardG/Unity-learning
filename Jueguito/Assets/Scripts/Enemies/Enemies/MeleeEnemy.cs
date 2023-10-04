using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxColl;

    [Header("Player Parameters")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }
    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight() && cooldownTimer >= attackCooldown)
        {         
            cooldownTimer = 0;
            anim.SetTrigger("meleeAttack");
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxColl.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColl.bounds.size.x * range, boxColl.bounds.size.y, boxColl.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColl.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColl.bounds.size.x * range, boxColl.bounds.size.y, boxColl.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
