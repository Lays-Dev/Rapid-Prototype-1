using UnityEngine;

// Create an enemy prefab
// Attach this script to it
// add a collider
// add a sprite
// place the enemy into the scene

public class EnemyScript : MonoBehaviour
{
    public bool canShoot;
    public int rowIndex;
    public int columnIndex;

    public GameObject laserPrefab;  // assign EnemyLazer prefab here
    public Transform firePoint;     // empty child transform for bullet spawn
    public float fireCooldown = 2f;

    private float fireTimer;
    private EnemyFormation enemyFormation;

    void Start()
    {
        enemyFormation = GetComponentInParent<EnemyFormation>();
        fireTimer = Random.Range(0f, fireCooldown); // stagger shots
    }

    void Update()
    {
        if (canShoot)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0f)
            {
                Shoot();
                fireTimer = fireCooldown;
            }
        }
    }

    void Shoot()
    {
        if (laserPrefab != null && firePoint != null)
        {
            Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
        }
    }

    public void Die()
    {
        enemyFormation.UpdateRowShooters();
        enemyFormation.UpdateStepSpeed();
        Destroy(gameObject);
    }
}


