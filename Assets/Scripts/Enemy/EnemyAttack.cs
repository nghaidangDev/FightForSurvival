using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    public EnemyBase enemyBase;

    private float cooldownTimer;

    private Animator anim;
    private Health playerHealth;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        cooldownTimer = attackCooldown;
    }


    public void StatesAttack()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight() && cooldownTimer >= attackCooldown)
        {
            Attack();
            Debug.Log("Attack");
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0f; // Reset cooldown timer after attack
        anim.SetBool("Walk", false);
    }

    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance
            , new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            playerHealth = hit.transform.GetComponent<Health>();
        }
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance
            , new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight() && playerHealth != null)
        {
            playerHealth.TakeDamage(enemyBase.attack);
        }
    }
}
