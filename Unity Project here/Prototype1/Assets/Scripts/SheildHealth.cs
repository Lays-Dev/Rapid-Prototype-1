using UnityEngine;

public class SheildHealth : MonoBehaviour
{
    public float health = 100f;

    // Method called by the projectile
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Debug.Log(gameObject.name + " took damage. Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death effects here
        Destroy(gameObject);
    }
}
