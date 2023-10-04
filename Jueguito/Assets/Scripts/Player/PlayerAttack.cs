using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{        
    [Header ("Melee attack")]
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [Header("Energy management")]
    [SerializeField] private Slider energyBar;
    [SerializeField] private float attackEnergy;
    [Header("Attack Cooldowns")]
    [SerializeField] private float meleeAttackCooldown;
    [SerializeField] private float rangedAttackCooldown;
    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxColl;
    [Header("Enemy Parameters")]
    [SerializeField] private LayerMask enemyLayer;
    [Header("Fireball management")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private PlayerMovement playerMovement;
    private SpriteRenderer sr;
    private Vector3 firePosition;
    private float scaleX;
    private float meleeCooldownTimer = Mathf.Infinity;
    private float rangedCooldownTimer = Mathf.Infinity;

    //References
    private Health enemyHealth;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && meleeCooldownTimer > meleeAttackCooldown && playerMovement.canAttack()){
            MeleeAttack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && rangedCooldownTimer > rangedAttackCooldown && playerMovement.canAttack() && energyBar.value > attackEnergy)
        {
            playerMovement.RangedAttackOrder();
        }
        meleeCooldownTimer += Time.deltaTime;
        rangedCooldownTimer += Time.deltaTime;
    }

    private void MeleeAttack()
    {
        anim.SetTrigger("meleeAttack");
        meleeCooldownTimer = 0;
    }
    public float RangedAttack()
    {
        int fireballPosition = FindFireball();
        anim.SetTrigger("rangedAttack");
        rangedCooldownTimer = 0;
        firePosition = firePoint.position;
        scaleX = transform.localScale.x;
        if (sr.flipX)
        {
            firePosition.x = firePosition.x - 3f;
            scaleX = -scaleX;
        }
        fireballs[fireballPosition].transform.position = firePosition;       
        fireballs[fireballPosition].GetComponent<Projectile>().SetDirection(Mathf.Sign(scaleX));
        return attackEnergy;
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

    private void DamageEnemy()
    {
        if (EnemyInSight())
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    private bool EnemyInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxColl.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColl.bounds.size.x * range, boxColl.bounds.size.y, boxColl.bounds.size.z),
            0, Vector2.left, 0, enemyLayer);

        if (hit.collider != null)
        {
            enemyHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxColl.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxColl.bounds.size.x * range, boxColl.bounds.size.y, boxColl.bounds.size.z));
    }
}
