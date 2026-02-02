using UnityEngine;

public class Projectile2 : MonoBehaviour
{

    public GameObject ProjectilePrefab;
    public Transform firePoint;
    public float damage = 1f;

    public float bulletSpeed = 20f;

    void OnAttack()
    {
        Debug.Log("Attack Input Received!");
        Shoot();
    }

    void Shoot()
    {
        Debug.Log("Shoot Input Received!");
        if (ProjectilePrefab != null && firePoint != null)
        {
            
            GameObject bullet = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = firePoint.right * bulletSpeed;
        }
       
    }

    void Update()
    {
        // Tells the projectile to move right at bulletspeed every frame
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object hit has a health script
        SheildHealth Enemy = other.GetComponent<SheildHealth>();
        
        if (Enemy != null)
        {
            Enemy.TakeDamage(damage);
            Destroy(gameObject); // Destroy projectile on hit
        }
    }

}
