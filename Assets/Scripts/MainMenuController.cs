using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
        // Load saved settings on app start
        GameSettings.Load();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("moondisaster");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void QuitGame()
    {
        Application.Quit(); // works in build, not in editor
    }
}