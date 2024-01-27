using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    public Sprite happySprite;
    public Sprite sadSprite;
    public Sprite normalSprite;

    public float sadThreshold = 20f; // Points threshold for sad sprite
    public float happyThreshold = 80f; // Points threshold for happy sprite

    public PointSliderController pointSliderController; // Reference to the PointSliderController script

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Make sure the PointSliderController script is attached to the same GameObject or another GameObject in the scene
        if (pointSliderController == null)
        {
            Debug.LogError("PointSliderController script not assigned!");
        }
    }

    void Update()
    {
        // Get the current points from the PointSliderController script
        float currentPoints = pointSliderController.GetCurrentPoints();

        // Change sprite based on points
        if (currentPoints < sadThreshold)
        {
            ChangeSprite(sadSprite);
        }
        else if (currentPoints > happyThreshold)
        {
            ChangeSprite(happySprite);
        }
        else
        {
            ChangeSprite(normalSprite);
        }
    }

    void ChangeSprite(Sprite newSprite)
    {
        // Change the sprite if it's different from the current one
        if (spriteRenderer.sprite != newSprite)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
