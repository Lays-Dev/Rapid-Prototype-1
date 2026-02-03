using UnityEngine;

public class ProjectileBullet : MonoBehaviour
{
    [HideInInspector]
    public float damage = 1f;

    public float lifetime = 5f; // auto-destroy after 5 seconds

    void Start()
    {
        Destroy(gameObject, lifetime); // auto-destroy if it misses everything
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for EnemyHealth
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        // Check for SheildHealth (if you still use it for something)
        SheildHealth shield = other.GetComponent<SheildHealth>();
        if (shield != null)
        {
            shield.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        // Optional: destroy on walls
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
