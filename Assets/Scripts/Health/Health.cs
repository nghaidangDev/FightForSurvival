using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private PlayerController playerController;
    public float startingHealth = 100f;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damaged)
    {
        startingHealth -= damaged;

        if (startingHealth <= 0)
        {
            playerController.currentState = PlayerState.Dying;
        }
    }
}
