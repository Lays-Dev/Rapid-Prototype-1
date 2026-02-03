using UnityEngine;

public class ProjectileEnd : MonoBehaviour
{
    // Auto-destroys if it misses everything to save performance
    void Start() => Destroy(gameObject, 5f); 

    void OnTriggerEnter2D(Collider2D other)
    {
        // Only destroy if it hits a wall or enemy
        if (other.gameObject.layer == LayerMask.NameToLayer("Wall") || 
        other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject); // 'gameObject' here refers to the bullet instance
        }
    }
}

