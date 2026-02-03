using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 1f;

    // Called by projectiles
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log(gameObject.name + " took damage. Health: " + health);

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Notify the EnemyScript (which handles formation)
        EnemyScript enemyScript = GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            enemyScript.Die();
        }
        else
        {
            // Fallback: just destroy if no EnemyScript
            Destroy(gameObject);
        }
    }
}

