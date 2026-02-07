using UnityEngine;

public class ProjectileBullet : MonoBehaviour
{
    [HideInInspector]
    public float damage = 1f;
    AudioManagerScript audioManager;

    public float lifetime = 5f; // auto-destroy after 5 seconds

    void Start()
    {
        Destroy(gameObject, lifetime); // auto-destroy if it misses everything
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for EnemyHealth
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {

            audioManager.PlayQuietSFX(audioManager.damage);
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        // Check for SheildHealth 
        ShieldHealth shield = other.GetComponent<ShieldHealth>();
        if (shield != null)
        {
            shield.TakeDamage(Mathf.RoundToInt(damage));
            Destroy(gameObject);
            return;
        }

        // Destroy on walls
        if (other.gameObject.layer == LayerMask.NameToLayer("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
