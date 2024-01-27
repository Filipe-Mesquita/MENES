using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointSliderController : MonoBehaviour
{
    public Slider pointsSlider;
    public float maxPoints = 100f;
    public float minPoints = 0f;
    public float pointsChangeRate = 1f; // Points decrease per second

    public AudioClip happyMusic;
    public AudioClip sadMusic;
    public AudioClip normalMusic;

    public float sadThreshold = 20f; // Points threshold for sad music
    public float happyThreshold = 80f; // Points threshold for happy music

    public float currentPoints = 50f; // Initial points
    private AudioSource audioSource;

    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

        // Initialize audio source with normal music
        audioSource.clip = normalMusic;
        audioSource.Play();

        UpdatePointsUI();
    }

    void Update()
    {
        // Update points based on time
        currentPoints -= pointsChangeRate * Time.deltaTime;

        // Clamp points between min and max values
        currentPoints = Mathf.Clamp(currentPoints, minPoints, maxPoints);

        // Update UI
        UpdatePointsUI(); 


        

        // Check if points reach 0 or 100 to load new scenes
        if (currentPoints <= minPoints)
        {
            LoadGameOverScene();
        }
        else if (currentPoints >= maxPoints - 3f)
        {
            LoadWinScene();
        }

        // Check points for music transitions
        UpdateMusic();
    }

    void UpdatePointsUI()
    {
        // Update the slider value based on current points
        pointsSlider.value = currentPoints / maxPoints;
    }

    void LoadGameOverScene()
    {
        // Replace "YourGameOverSceneName" with the actual name of your game over scene
        SceneManager.LoadScene("YourGameOverSceneName");
    }

    void LoadWinScene()
    {
        // Replace "YourWinSceneName" with the actual name of your win scene
        SceneManager.LoadScene("YourWinSceneName");
    }

    void UpdateMusic()
    {
        // Check points for music transitions
        if (currentPoints < sadThreshold)
        {
            SetMusicClip(sadMusic);
        }
        else if (currentPoints > happyThreshold)
        {
            SetMusicClip(happyMusic);
        }
        else
        {
            SetMusicClip(normalMusic);
        }
    }

    void SetMusicClip(AudioClip clip)
    {
        // Change the music clip if it's different from the current one
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    public void AddPoints(float amount)
    {
        // Add the specified amount of points
        currentPoints += amount;

        // Clamp points between min and max values
        currentPoints = Mathf.Clamp(currentPoints, minPoints, maxPoints);

        // Update UI
        UpdatePointsUI();
    }

    public float GetCurrentPoints()
    {
        return currentPoints;
    }
}
