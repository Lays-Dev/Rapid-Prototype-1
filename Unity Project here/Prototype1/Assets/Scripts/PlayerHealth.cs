using UnityEngine;
using UnityEngine.SceneManagement; // for Death scene

public class PlayerHealth : MonoBehaviour
{
    // Current hits the player can take
    public int maxHealth = 4; 
    private int currentHealth;

    [SerializeField] private HeartContainer heartUI;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)

    {
        //Debug.Log("Player hit! Health: " + currentHealth);
        
        currentHealth = Mathf.Max(currentHealth - damageAmount, 0);

        // Remove the heart that was just lost
        heartUI.RemoveHeart(currentHealth-1);

        ScoreManager.Instance.PlayerLostHealth();

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    

    void Die()
    {
        Debug.Log("Player Died!");
        // Load the death scene
        SceneManager.LoadScene("LoseScreen"); 

        // Or trigger a UI panel
        // GameObject.Find("DeathPanel").SetActive(true);
        // Time.timeScale = 0f;
    }
}
