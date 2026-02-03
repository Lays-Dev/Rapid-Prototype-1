using UnityEngine;
using UnityEngine.SceneManagement; // Needed to change scenes

public class EnemyWin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            // Trigger game over
            GameOver();
        }
    }

    void GameOver()
    {
        //Load the death screen
        SceneManager.LoadScene("DeathScreen");

        // Enable a UI panel instructions if we go this route
        // GameObject.Find("DeathScreenPanel").SetActive(true);
        
        // Stop enemy movement
        Time.timeScale = 0f;
    }
}
