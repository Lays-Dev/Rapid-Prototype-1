using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // This line is the Instance property in ScoreManager class for Unity
    public static ScoreManager Instance;

    public int Score { get; private set; }

    [Header("Combo Settings")]
    public float comboTimeWindow = 0.5f;
    private float lastKillTime;
    private bool comboActive;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // ================= ENEMY KILL =================
    public void AddEnemyKill(int columnNumber)
    {
        int basePoints = 10 * columnNumber;

        // Check combo
        if (Time.time - lastKillTime <= comboTimeWindow)
        {
            basePoints *= 2;
            comboActive = true;
        }
        else
        {
            comboActive = false;
        }

        lastKillTime = Time.time;

        AddScore(basePoints);
    }

    // ================= PLAYER DAMAGE =================
    public void PlayerLostHealth()
    {
        AddScore(-100);
    }

    // ================= PROJECTILE BONUS =================
    public void ShotEnemyProjectile()
    {
        AddScore(100);
    }

    // ================= CORE ADD =================
    private void AddScore(int amount)
    {
        Score += amount;
        Score = Mathf.Max(Score, 0); // never below 0

        ScoreUI.Instance.UpdateScore(Score, comboActive);
    }
}
