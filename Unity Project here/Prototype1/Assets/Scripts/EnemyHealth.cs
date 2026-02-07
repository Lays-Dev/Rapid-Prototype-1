using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 1f;

    // Called by projectiles
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        //Debug.Log(gameObject.name + " took damage. Health: " + health);

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Get the EnemyScript attached to this enemy to access its columnIndex for scoring
        EnemyScript enemyScript = GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            // Get the column number
            // Columns are 0-indexed, so we add 1 for scoring
            int columnNumber = enemyScript.columnIndex + 1;

            // Add score
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddEnemyKill(columnNumber);
            }
            else
            {
                Debug.LogWarning("ScoreManager not found in scene!");
            }
            enemyScript.Die();
        }
        else
        {
            // Fallback: just destroy if no EnemyScript
            Destroy(gameObject);
        }
    }
}

