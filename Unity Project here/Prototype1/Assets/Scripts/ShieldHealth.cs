using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    private int maxHealth = 16;   
    private int currentHealth;

    [SerializeField] private Sprite[] shieldSprites; 
    // Index 0 = full (16)
    // Index 1 = damaged (12)
    // Index 2 = heavy damage (8)
    // Index 3 = critical (4)

    private SpriteRenderer spriteRenderer;


    void Awake()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateShieldVisual(); // set starting sprite
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
        //int damageTaken = maxHealth - currentHealth;

        // 16 / 3 ≈ 5.33 → thresholds
        int spriteIndex;

        if (currentHealth > 10)       // 16–11
            spriteIndex = 0;
        else if (currentHealth > 5)   // 10–6
            spriteIndex = 1;
        else                          // 5–1
            spriteIndex = 2;

        spriteRenderer.sprite = shieldSprites[spriteIndex];
    }



    private void OnTriggerEnter2D(Collider2D other)
{
    // Check if the object hitting the shield is an enemy projectile
    if (other.CompareTag("EnemyLaser")) 
    {
        TakeDamage(1); 
        // Destroy the bullet so it doesn't pass through
        Destroy(other.gameObject);
    }
}

}
