using UnityEngine;
using UnityEngine.SceneManagement; // Needed to change scenes

public class EnemyWin : MonoBehaviour
{
    private void Update()
    {
        

        // Check if they reach an X position to end the game
        if (transform.position.x <= -19f)
        {
            Debug.Log(gameObject.name + " x = " + transform.position.x);

            Debug.Log("Threshold reached! Triggering Game Over.");
            // Trigger game over
            GameOver();
        }
    }

    void GameOver()
    {
        //Load the death screen
        SceneManager.LoadScene("LoseScreen");

        // Enable a UI panel instructions if we go this route
        // GameObject.Find("DeathScreenPanel").SetActive(true);
        
        // Stop enemy movement
        Time.timeScale = 0f;
    }
}
