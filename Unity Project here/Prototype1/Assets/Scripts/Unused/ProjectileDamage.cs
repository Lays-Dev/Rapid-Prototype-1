using UnityEngine;

// This script wont work until the class name is changed
public class Projectile : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SheildHealth enemy = other.GetComponent<SheildHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
