using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Moving,
    Attacking,
    Dying
}

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;
    public UIManager uIManager;

    [SerializeField] private float speed;
    [SerializeField] private float attackRadiusRange;

    private Animator anim;
    private Rigidbody2D rb;
    private PlayerAttack playerAttack;

    private bool isAttacking;
    private bool isAttackPerformed;

    Vector2 moveDirection;
    Vector2 lastMoveDirection;

    public Transform attackCheck;
    public LayerMask enemyLayer;

    private void Start()
    {
        currentState = PlayerState.Idle;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                HandleIdle();
                break;
            case PlayerState.Moving:
                HandleMoving();
                break;
            case PlayerState.Attacking:
                HandleAttacking();
                break;
            case PlayerState.Dying:
                HandleDying();
                break;
        }

        SetAnimation();
    }

    private void HandleDying()
    {
        // Xử lý trạng thái Dying 
        uIManager.UIGameOver();
    }

    private void HandleAttacking()
    {
        if (!isAttackPerformed)
        {
            Debug.Log("Attacking");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerAttack.Attacking();
            }

            isAttackPerformed = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentState = PlayerState.Idle;
            isAttackPerformed = false;
        }
    }

    private void HandleMoving()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        if (moveDirection.x != 0 && moveDirection.y == 0)
        {
            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
        }
        else if (moveDirection.x == 0 && moveDirection.y != 0)
        {
            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
        }

        if (moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection;
        }

        if (moveDirection == Vector2.zero)
        {
            currentState = PlayerState.Idle;
        }
    }

    private void HandleIdle()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            currentState = PlayerState.Moving;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = PlayerState.Attacking;
            isAttackPerformed = false; // Reset trạng thái tấn công khi vào trạng thái Attacking
        }
    }

    private void SetAnimation()
    {
        if (currentState == PlayerState.Moving)
        {
            anim.SetFloat("Horizontal", moveDirection.x);
            anim.SetFloat("Vertical", moveDirection.y);
        }

        anim.SetFloat("Speed", moveDirection.sqrMagnitude);
        anim.SetBool("isAttack", currentState == PlayerState.Attacking);
        anim.SetBool("isDead", currentState == PlayerState.Dying);
    }
}
