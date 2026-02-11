using UnityEngine;
 // Dictionary code requires this namespace
using System.Collections.Generic;
using UnityEngine.SceneManagement; // Needed to change scenes

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
        //Debug.Log("Enemy count requested");
        //startingEnemyCount = transform.childCount;
        startingEnemyCount = transform.childCount;
        UpdateStepSpeed();
        UpdateRowShooters();
    }


private int GetAliveEnemyCount()
{
    int alive = transform.childCount;

    if (alive <= 0)
    {
        SceneManager.LoadScene("PrologueScreen");
        Time.timeScale = 0f;
    }

    return alive;
}

   // private int GetAliveEnemyCount()
    //{
       // Debug.Log("Enemy count requested");
        //startingEnemyCount = transform.childCount;

       // if (startingEnemyCount <= 0)
        //{
            // Replace with win screen
          //  SceneManager.LoadScene("WinScreen");

            // Enable a UI panel instructions if we go this route
            // GameObject.Find("DeathScreenPanel").SetActive(true);
        
            // Stop enemy movement
          //  Time.timeScale = 0f;
      //  }
       // return startingEnemyCount;
  //  }

    void Update()
    {
        stepTimer += Time.deltaTime;

        if (stepTimer >= currentStepTime)
        {
            Step();
            stepTimer = 0f;
        }

        GetAliveEnemyCount();
    }

    void Step()
    {
        UpdateStepSpeed();
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
        UpdateRowShooters();
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
        //Debug.Log("Returning enemy count for speed update");
        int alive = transform.childCount;

        float t = (float)alive / startingEnemyCount;
        currentStepTime = Mathf.Lerp(minStepTime, maxStepTime, t);
        //Debug.Log("New speeed assigned : " + currentStepTime);
    }

    public void UpdateRowShooters()
    {
        // key = row index, value = left-most enemy in that row
        Dictionary<int, Transform> leftMostByRow = new Dictionary<int, Transform>();

        foreach (Transform enemy in transform)
        {
            if (enemy == null) continue;

            EnemyScript es = enemy.GetComponent<EnemyScript>();
            if (es == null) continue;

            int row = es.rowIndex;

            if (!leftMostByRow.ContainsKey(row))
            {
                leftMostByRow[row] = enemy;
            }
            else
            {
                EnemyScript currentLeft = leftMostByRow[row].GetComponent<EnemyScript>();
                if (es.columnIndex < currentLeft.columnIndex)
                {
                    leftMostByRow[row] = enemy;
                }
            }
        }

        // Disable all shooters
        foreach (Transform enemy in transform)
        {
            EnemyScript es = enemy.GetComponent<EnemyScript>();
            if (es != null) es.canShoot = false;
        }

        // Enable left-most shooters
        foreach (Transform enemy in leftMostByRow.Values)
        {
            EnemyScript es = enemy.GetComponent<EnemyScript>();
            if (es != null) es.canShoot = true;
        }
    }
}