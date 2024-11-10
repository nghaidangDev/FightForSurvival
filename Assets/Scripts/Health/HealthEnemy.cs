using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    private Enemy enemy;
    public EnemyBase enemyBase;
    public float currentHealth;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        currentHealth = enemyBase.health;
    }

    public void TakeDamaged(float damaged)
    {
        currentHealth -= damaged;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            enemy.currentState = EnemyStates.Dying;
        }
    }
}
