using UnityEngine;

// Name the script this is in EnemyFormation
public class EnemyFormation : MonoBehaviour
{
    public float stepDistance = 0.2f;     // how far each step moves
    public float stepLeftDistance = 0.3f; // how far the formation drops
    
	// Create a layer for the games walls
	// Put all the walls in that layer with collisions
	// drag that layer into this walllayer slot in the inspector
	// LayerMask is a filter that can include multiple layers
	// When this code does a raycast, it will only detect colliders on this layer
	public LayerMask wallLayer; 

    public float maxStepTime = 0.8f; // slowest (many enemies alive)
    public float minStepTime = 0.05f; // fastest (last enemy)

    private float stepTimer;
    private float currentStepTime;

    private int verticalDirection = 1; // 1 = up, -1 = down
    private bool moveLeftNext = false;

    private int startingEnemyCount;

    void Start()
    {
        startingEnemyCount = transform.childCount;
        UpdateStepSpeed();
    }

    void Update()
    {
        stepTimer += Time.deltaTime;

        if (stepTimer >= currentStepTime)
        {
            Step();
            stepTimer = 0f;
        }
    }

    void Step()
    {
        if (moveLeftNext)
        {
            transform.position += Vector3.left * stepLeftDistance;
            moveLeftNext = false;
            verticalDirection *= -1;
        }
        else
        {
            transform.position += Vector3.up * verticalDirection * stepDistance;

            if (CheckWall())
            {
                moveLeftNext = true;
            }
        }
    }

    bool CheckWall()
    {
	// the citronian name can be replaced with any variable. For now it is the name of each enemy
	// Make sure each citronian game object has a transform value for this
	// The citronian game objects should be under a parent object
	// The parent object needs to be an empty game object
        foreach (Transform citronian in transform)
        {
            if (citronian == null) continue;

            RaycastHit2D hit = Physics2D.Raycast(
		// starts at the enemy
                citronian.position, 
		// shoots left or right
                Vector2.up * verticalDirection,
		// stops after stepDistance variable
                stepDistance,
		// Only hits colliders on the layers inside wallLayer slot
                wallLayer
            );

            if (hit.collider != null)
                return true;
        }

        return false;
    }

    public void UpdateStepSpeed()
    {
        int alive = transform.childCount;

        float t = (float)alive / startingEnemyCount;
        currentStepTime = Mathf.Lerp(minStepTime, maxStepTime, t);
    }
}
