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
        Debug.Log("Shoot Input RSeceived!");

        // Instantiate bullet
        GameObject bullet = Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);

        // Give bullet its velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.right * bulletSpeed;
        }

        // Assign damage to the bullet's script
        ProjectileBullet bulletScript = bullet.GetComponent<ProjectileBullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = damage;
        }
       
    }
}
