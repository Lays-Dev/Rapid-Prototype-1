using UnityEngine;

public class Projectile2 : MonoBehaviour
{

    public GameObject ProjectilePrefab;
    public Transform firePoint;

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

}
