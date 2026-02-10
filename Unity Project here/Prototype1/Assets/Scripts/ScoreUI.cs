using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject comboText; // optional

    private void Awake()
    {
        Instance = this;
        UpdateScore(ScoreManager.Instance.GetScore(), false);
       
    }

    public void UpdateScore(int score, bool combo)
    {
        scoreText.text = $"Score: {score}";

    }
}
