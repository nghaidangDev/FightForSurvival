using System;
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
    [SerializeField] private float speed;

    private Animator anim;
    private Rigidbody2D rb;

    Vector2 moveDirection;

    private void Start()
    {
        currentState = PlayerState.Idle;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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

    }

    private void HandleAttacking()
    {

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


        if (moveDirection.x == 0 && moveDirection.y == 0)
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

/*        if (Input.GetMouseButton(0))
        {
            currentState = PlayerState.Attacking;
        }*/
    }

    private void SetAnimation()
    {
        anim.SetFloat("Horizontal", moveDirection.x);
        anim.SetFloat("Vertical", moveDirection.y);

        anim.SetFloat("Speed", moveDirection.sqrMagnitude);
    }
}
