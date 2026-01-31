using UnityEngine;

public class StaffAttack : MonoBehaviour
{

    // This line of code is a reference to the projectilePrefab that may not be in engine yet
    [SerializeField] private GameObject projectilePrefab;
    // [SerializeField] makes private variables visible in the Unity Inspector

    [SerializeField] private Transform Enemy;

    [SerializeField] private float shootRate;
    [SerializeField] private float projectileMoveSpeed;
    private float shootTimer;

    private void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0f)
        {
            shootTimer = shootRate;
            ProjectileScript projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<ProjectileScript>();
            projectile.InitializeProjectile(Enemy, projectileMoveSpeed);

        }
    }
    
}
