using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth { get; private set; }



    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damaged)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damaged, 0, startingHealth);

        if (currentHealth > 0)
        {
            //
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;

            PlayerController playerController = GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.currentState = PlayerState.Dying;
            }

            Enemy enemy = GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.currentState = EnemyStates.Dying;
                enemy.enabled = false;
                gameObject.SetActive(false);
            }
        }
    }
}
