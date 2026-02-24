using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { MainMenu, Playing, Paused, GameOver }

    public GameState CurrentState { get; private set; }

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Listen for scene changes so we can set the correct state automatically
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        // Clean up event subscription when object is destroyed
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Runs every time a new scene loads
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
            SetState(GameState.MainMenu);
        else if (scene.name == "Game")
            SetState(GameState.Playing);
    }

    void Update()
    {
        // Only allow pausing while in the Game scene / Playing or Paused state
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentState == GameState.Playing) PauseGame();
            else if (CurrentState == GameState.Paused) ResumeGame();
        }
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;

        // Control time based on state
        Time.timeScale = (newState == GameState.Paused || newState == GameState.GameOver) ? 0f : 1f;

        Debug.Log("State changed to: " + newState);

        OnGameStateChanged?.Invoke(newState);
    }

    public void PauseGame() => SetState(GameState.Paused);
    public void ResumeGame() => SetState(GameState.Playing);

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
}
