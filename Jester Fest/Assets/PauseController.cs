using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField]
    private GameObject[] objectsToDeactivate;

    [SerializeField]
    private Canvas pauseOverlayCanvas;

    void Start()
    {
        // Start the game unpaused
        pauseOverlayCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        // Check for the pause key (you can change this to any key you prefer)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        // Toggle the pause state
        isPaused = !isPaused;

        // Pause or unpause the game based on the state
        Time.timeScale = isPaused ? 0 : 1;

        // Activate or deactivate specified objects
        foreach (var obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(!isPaused);
            }
        }

        // Free or lock the cursor based on the state
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;

        // Toggle the visibility of the pause overlay
        if (pauseOverlayCanvas != null)
        {
            pauseOverlayCanvas.gameObject.SetActive(isPaused);
        }
    }

    public void ResumeGame()
    {
        // Resume the game and activate the objects
        isPaused = false;
        Time.timeScale = 1;

        foreach (var obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Hide the pause overlay
        if (pauseOverlayCanvas != null)
        {
            pauseOverlayCanvas.gameObject.SetActive(false);
        }
    }

    public void GoToMainMenu()
    {
        // Load the main menu scene
        SceneManager.LoadScene("JFmenu"); // Replace "MainMenu" with the name of your main menu scene
    }
}
