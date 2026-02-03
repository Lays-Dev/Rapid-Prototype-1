using UnityEngine;

// This script wont work until the class name is changed
public class Projectile : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ShieldHealth enemy = other.GetComponent<ShieldHealth>();


        if (enemy != null)
        {
            // Convet float to int with (Mathf.RoundToInt(damage));
            enemy.TakeDamage(Mathf.RoundToInt(damage));
            // Despawn the projectile
            Destroy(gameObject);
        }
    }
}
