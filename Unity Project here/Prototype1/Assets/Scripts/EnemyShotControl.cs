using System.Collections.Generic;
using UnityEngine;

public class EnemyShotControl : MonoBehaviour
{
    [Header("Laser Settings")]
    // Prefab with EnemyLazer script
    public GameObject enemyBulletPrefab;
    // Organizes bullets in hierarchy
    public Transform bulletsParent; 
    // How often the game checks for shooting
    public float shootInterval = 1f; 
    // 10% chance for an enemy to shoot each interval
    public float shootProbability = 0.1f; 

    AudioManagerScript audioManager;
    private List<EnemyScript> enemies = new List<EnemyScript>();
    private float timer = 0f;

    void Start()
    {
        // Collect all enemies
        enemies.AddRange(GetComponentsInChildren<EnemyScript>());
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            timer = 0f;
            ShootLeftMostRow();
        }
    }

    void ShootLeftMostRow()
    {
        // Enemies are all destroyed
        if (enemies.Count == 0) return;
        
        float lowestX = float.MaxValue;
        // Find the lowest x value
        foreach (var e in enemies)
        {
            if (e == null) continue;

            if (e.transform.position.x < lowestX)
            lowestX = e.transform.position.x;
        }

        // Have eligible enemies shoot randomly
        foreach (var e in enemies)
        {
            if (e == null) continue;
            if (Mathf.Abs(e.transform.position.x - lowestX) < 0.01f)
            {
                if (Random.value < shootProbability)
                {
                    
                    SpawnBulletLeft(e.transform.position);
                    
                }
            }
        }
    }

    void SpawnBulletLeft(Vector3 position)
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, position, Quaternion.identity);

        if (bulletsParent != null)
        {
            bullet.transform.parent = bulletsParent;
        }
        // Play sound every time an enemy shoots
        audioManager.PlaySFX(audioManager.laser1);
    }

}
