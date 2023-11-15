using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;

    void OnEnable()
    {
        // Subscribe to the OnHighScoreChanged event
        HighScoreManager.OnHighScoreChanged += UpdateHighScoreText;
    }

    void OnDisable()
    {
        // Unsubscribe when the script is disabled or destroyed
        HighScoreManager.OnHighScoreChanged -= UpdateHighScoreText;
    }

    void Start()
    {
        UpdateHighScoreText();
    }

    void UpdateHighScoreText(int newHighScore = 0)
    {
        // Use the provided newHighScore value or get it from the manager
        int highScore = (newHighScore != 0) ? newHighScore : HighScoreManager.GetHighScore();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
