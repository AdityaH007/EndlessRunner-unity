using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI startButton;
    public TextMeshProUGUI quitButton;

    public void StartGame()
    {
        // Load the game scene
        SceneManager.LoadScene("SampleScene");
    }

   

    public void QuitGame()
    {
        // Quit the game (works in standalone builds)
        Application.Quit();
    }
}
