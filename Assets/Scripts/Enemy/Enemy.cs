using System.Collections;
using UnityEngine;

public enum EnemyStates
{
    Idle,
    Walking,
    Attacking,
    Dying
}

public class Enemy : MonoBehaviour
{
    public EnemyStates currentState;
    public EnemyPatrol enemyPatrol;
    public EnemyAttack enemyAttack;

    private Animator anim;
    private bool waiting = false;

    private void Start()
    {
        currentState = EnemyStates.Walking;
        anim = GetComponent<Animator>();

        if (enemyPatrol == null)
        {
            Debug.LogError("EnemyPatrol is not assigned.");
        }

        if (enemyAttack == null)
        {
            Debug.LogError("EnemyAttack is not assigned.");
        }
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyStates.Idle:
                HandleIdle();
                break;
            case EnemyStates.Walking:
                HandleWalking();
                break;
            case EnemyStates.Attacking:
                HandleAttacking();
                break;
            case EnemyStates.Dying:
                HandleDying();
                break;
        }

        SetAnimation();
    }

    private void HandleDying()
    {

    }

    private void HandleAttacking()
    {
        enemyAttack.StatesAttack();

        if (enemyAttack.PlayerInSight() == false)
        {
            currentState = EnemyStates.Walking;
        }
    }

    private void HandleWalking()
    {
        enemyPatrol.DiractionAndMove();

        if (enemyAttack.PlayerInSight())
        {
            currentState = EnemyStates.Attacking;
        } 
    }

    private void HandleIdle()
    {

    }

    private void SetAnimation()
    {

    }
}
