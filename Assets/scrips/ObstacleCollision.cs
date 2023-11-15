using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;

    public TextMeshProUGUI finalDistanceText;
    public TextMeshProUGUI finalCoinsText;

    void OnTriggerEnter(Collider other)
    {
        // Disable the collider and player movement
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;

        // Stop counting the distance
        FindObjectOfType<LevelDistance>().StopCounting();

        // Play the collision animation
        charModel.GetComponent<Animator>().Play("mixamo_com");

        // Calculate distance covered and coins collected
        float distanceCovered = CalculateDistanceCovered();
        int coinsCollected = CollactableControl.coinCount;

        UpdateHighScore(distanceCovered);

        // Display final distance and coins
        DisplayFinalStats(distanceCovered, coinsCollected);

        // Start the coroutine for waiting and returning to the main menu
        StartCoroutine(ReturnToMainMenu());
    }

    void DisplayFinalStats(float distance, int coins)
    {
        // Set the text values
        finalDistanceText.text = "Final Distance: " + distance.ToString("F2") + " meters";
        finalCoinsText.text = "Final Coins: " + coins.ToString();
    }

    IEnumerator ReturnToMainMenu()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(10f);

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    float CalculateDistanceCovered()
    {
        // Use the value stored in LevelDistance script
        return FindObjectOfType<LevelDistance>().disRun;
    }


    void UpdateHighScore(float distance)
    {
        int currentScore = Mathf.RoundToInt(distance);
        HighScoreManager.SetHighScore(currentScore);
    }
}
