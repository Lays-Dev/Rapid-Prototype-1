using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // singleton

    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Combo Settings")]
    public float comboTimeWindow = 0.5f; // seconds to chain kills

    private int score = 0;
    private int comboMultiplier = 1;
    private float lastKillTime = 0f;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        UpdateUI();
    }

    #region Enemy Kill
    public void AddEnemyKill(int columnNumber)
    {
        // Check combo timing
        if (Time.time - lastKillTime <= comboTimeWindow)
        {
            comboMultiplier = 2; // double points for quick consecutive kills
        }
        else
        {
            comboMultiplier = 1; // reset combo
        }

        lastKillTime = Time.time;

        int points = 10 * columnNumber * comboMultiplier;
        AddPoints(points);
    }
    #endregion

    #region Enemy Projectile
    public void ShotEnemyProjectile()
    {
        AddPoints(100);
        Debug.Log("Player shot projectile. Score updated: " + score);
    }
    #endregion

    #region Player Damage
    public void PlayerLostHealth()
    {
        AddPoints(-100);
        Debug.Log("Player lost health. Score updated: " + score);
    }
    #endregion

    #region Core
    private void AddPoints(int amount)
    {
        score += amount;

        // Clamp to zero
        if (score < 0)
            score = 0;

        Debug.Log("Score updated: " + score);

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    // Optional getter if you need it elsewhere
    public int GetScore()
    {
        return score;
    }
    #endregion
}
