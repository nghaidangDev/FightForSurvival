using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [SerializeField] private float idleDuration;

    [SerializeField] private Animator anim;

    public EnemyBase enemyBase;

    private float idleTimer;
    private bool movingLeft;
    Vector3 initScale;
    private void Awake()
    {
        initScale = enemy != null ? enemy.localScale : Vector3.one;
    }

    private void OnDisable()
    {
        if (anim != null)
        {
            anim.SetBool("Walk", false);
        }   
    }

    public void DiractionAndMove()
    {
        if (enemy == null || leftEdge == null || rightEdge == null) return;

        if (movingLeft)
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DiractionChange();
            }
        }
        else
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DiractionChange();
            }
        }
    }

    private void DiractionChange()
    {
        if (anim != null)
        {
            anim.SetBool("Walk", false);
        }

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        if (anim != null)
        {
            anim.SetBool("Walk", true);
        }

        if (enemy != null)
        {
            enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
            enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * enemyBase.speed, enemy.position.y, enemy.position.z);
        }
    }
}
