using UnityEngine;

// Create an enemy prefab
// Attach this script to it
// add a collider
// add a sprite
// place the enemy into the scene

public class EnemyScript : MonoBehaviour
{
    public void Die()
    {
        EnemyFormation formation = GetComponentInParent<EnemyFormation>();

       if (formation != null)
        {
            formation.UpdateStepSpeed();
        }

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}

