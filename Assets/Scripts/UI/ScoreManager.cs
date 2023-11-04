using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int currentScore = 0;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
    }
}