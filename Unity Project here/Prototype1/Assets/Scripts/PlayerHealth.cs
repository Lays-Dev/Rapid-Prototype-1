using UnityEngine;
using UnityEngine.SceneManagement; // for Death scene

public class PlayerHealth : MonoBehaviour
{
    // Current hits the player can take
    public float maxHealth = 3f; 
    private float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Player hit! Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        // Load the death scene
        SceneManager.LoadScene("DeathScreen"); 

        // Or trigger a UI panel
        // GameObject.Find("DeathPanel").SetActive(true);
        // Time.timeScale = 0f;
    }
}
