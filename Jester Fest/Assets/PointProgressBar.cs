using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointProgressBar : MonoBehaviour
{
    public float maxPoints = 100f;
    public float minPoints = 0f;
    public float points = 50f;
    public float pointsLossRate = 1f; // Adjust this value to control how fast points are deducted.

    public Image progressBar;
    public Sprite progressSprite; // Sprite to associate with the progress bar.
    public string sceneToLoadOnZeroPoints = "GameOverScene";
    public string sceneToLoadOnMaxPoints = "WinScene";

    private float timer = 0f;

    void Start()
    {
        // Set the initial sprite for the progress bar
        progressBar.sprite = progressSprite;
    }

    void Update()
    {
        // Deduct points over time
        points -= pointsLossRate * Time.deltaTime;
        points = Mathf.Clamp(points, minPoints, maxPoints);

        // Update progress bar
        UpdateProgressBar();

        // Check if points reached 0 or 100
        if (points <= minPoints)
        {
            LoadScene(sceneToLoadOnZeroPoints);
        }
        else if (points >= maxPoints)
        {
            LoadScene(sceneToLoadOnMaxPoints);
        }

        // Update timer
        timer += Time.deltaTime;
    }

    void UpdateProgressBar()
    {
        float normalizedPoints = (points - minPoints) / (maxPoints - minPoints);
        progressBar.fillAmount = normalizedPoints;
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Function to add points
    public void AddPoints(float amount)
    {
        points += amount;
        points = Mathf.Clamp(points, minPoints, maxPoints);
        UpdateProgressBar();
    }

    // Function to get the current time
    public float GetTimer()
    {
        return timer;
    }
}
