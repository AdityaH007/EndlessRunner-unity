using UnityEngine;
using UnityEngine.UI;

public class MainMenu1 : MonoBehaviour
{
    public InputField playerNameInput;

    public void StartGame()
    {
        // Store the entered player name (you can save it in PlayerPrefs or a player data manager)
        string playerName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);

        // Start the game or load the next scene
        // Example: SceneManager.LoadScene("GameScene");
    }
}
