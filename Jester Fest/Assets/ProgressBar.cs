using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    public SpriteRenderer progressBarFill;
    public float maxPoints = 100f;
    public float currentPoints = 50f;
    public float pointsLossRate = 1f;

    void Update()
    {
        // Decrease points over time
        currentPoints -= pointsLossRate * Time.deltaTime;

        // Clamp points to be within the range [0, maxPoints]
        currentPoints = Mathf.Clamp(currentPoints, 0f, maxPoints);

        // Update the fill amount of the progress bar
        float fillAmount = currentPoints / maxPoints;
        progressBarFill.transform.localScale = new Vector3(fillAmount, 1f, 1f);

        // Check if points are less than or equal to 0 or greater than or equal to 100
        if (currentPoints <= 0f)
        {
            // Load a scene when points reach 0
            SceneManager.LoadScene("YourGameOverScene");
        }
        else if (currentPoints >= maxPoints)
        {
            // Load a scene when points reach 100
            SceneManager.LoadScene("YourVictoryScene");
        }
    }
}

