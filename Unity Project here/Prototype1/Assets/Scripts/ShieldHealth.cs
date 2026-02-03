using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    private int maxHealth = 16;   
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage = 1)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " took damage. Remaining: " + currentHealth);

        // Update visual based on damage
        UpdateShieldVisual();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateShieldVisual()
    {
        // Change sprite based on remaining health here
        // 4 sprites for 16/12/8/4 hits left
    }
}
