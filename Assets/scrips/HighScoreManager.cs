using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    // Event that will be triggered when the high score changes
    public static event System.Action<int> OnHighScoreChanged;

    // Get the current high score
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    // Set a new high score if the provided score is higher
    public static void SetHighScore(int newScore)
    {
        int currentHighScore = GetHighScore();

        if (newScore > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, newScore);
            PlayerPrefs.Save(); // Save the changes

            // Trigger the event to notify other scripts about the change
            OnHighScoreChanged?.Invoke(newScore);
        }
    }
}
