using UnityEngine;

public class Projectile2 : MonoBehaviour
{

    public GameObject ProjectilePrefab;
    public Transform firePoint;
    public Transform alternateFirePoint;
    public float damage = 1f;

    public float bulletSpeed = 20f;

    // Time between shots
    public float fireCooldown = 0.5f;
    private float lastFireTime = 0f;

    // Powered shot
    public bool poweredShot = false;

    AudioManagerScript audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    void OnAttack()
    {
        //Debug.Log("Attack Input Received!");
        audioManager.PlaySFX(audioManager.attack);
        Shoot();
    }

    void Shoot()
    {
        Debug.Log("Shoot Input RSeceived!");

        // Check cooldown
        if (Time.time < lastFireTime + fireCooldown)
        {
            // Still in cooldown
            return; 
        }

        lastFireTime = Time.time;

        if (poweredShot && alternateFirePoint != null)
        {
            // Powered shot fires two bullets
            SpawnBullet(firePoint);
            SpawnBullet(alternateFirePoint);
        }
        else
        {
            // Normal 
            SpawnBullet(firePoint);
        }
    
    }
    
    void SpawnBullet(Transform spawnPoint)
    {
        // Instantiate bullet
        GameObject bullet = Instantiate(ProjectilePrefab, spawnPoint.position, spawnPoint.rotation);
        
        // Give bullet its velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = spawnPoint.right * bulletSpeed;
        }

        // Assign damage to the bullet's script
        ProjectileBullet bulletScript = bullet.GetComponent<ProjectileBullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = damage;
        } 
    }
}
