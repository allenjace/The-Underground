using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;  // To keep track of the pause state
    public string pauseMenuSceneName = "PauseMenu";  // The name of the pause menu scene
    private string currentGameSceneName;  // To store the name of the current game scene
    void Update()
    {
        // Check for the ESC key press to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        currentGameSceneName = SceneManager.GetActiveScene().name;  // Store the current game scene name
        SceneManager.LoadSceneAsync(pauseMenuSceneName, LoadSceneMode.Additive);  // Load the pause menu scene additively
        Time.timeScale = 0f;  // Freeze the game time
    }

    public void ResumeGame()
    {
        isPaused = false;
        SceneManager.UnloadSceneAsync(pauseMenuSceneName);
        Time.timeScale = 1f;  
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;  // Ensure the game time is running before switching scenes
        SceneManager.LoadScene("MainMenu");  // Replace with your main menu scene name
    }

    public void ExitGame()
    {
        Application.Quit();  // Quit the application
    }
}
