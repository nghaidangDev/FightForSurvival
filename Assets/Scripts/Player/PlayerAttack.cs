using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRadious;
    public LayerMask enemyMask;

    private float damaged;


    private void Start()
    {
        damaged = 20f;
    }

    public void Init(CharacterSO data)
    {
        damaged = data.damaged;
    }

    public void Attacking()
    {
        Collider2D[] enemyInRanged = Physics2D.OverlapCircleAll(attackPoint.position, attackRadious, enemyMask);

        foreach (var enemy in enemyInRanged)
        {
            enemy.GetComponent<Health>().TakeDamage(damaged);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadious);
    }
}
