using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject comboText; // optional

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScore(int score, bool combo)
    {
        scoreText.text = $"Score: {score}";

        if (comboText != null)
            comboText.SetActive(combo);
    }
}
