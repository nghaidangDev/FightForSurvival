using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public EnemyBase enemyBase;
    public float distanceBetween;

    private float distance;

    private void Update()
    {
        ChasePLayer();
    }

    public void ChasePLayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = transform.position - player.transform.position;
        direction.Normalize();
        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyBase.speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angel);
        }
    }
}
