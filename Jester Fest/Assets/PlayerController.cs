using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust this to control the player's movement speed

    public KeyCode upKey = KeyCode.W;     // Configure the keys for movement
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get input values for movement
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Input.GetKey(leftKey))
            horizontalInput -= 1f;
        if (Input.GetKey(rightKey))
            horizontalInput += 1f;
        if (Input.GetKey(downKey))
            verticalInput -= 1f;
        if (Input.GetKey(upKey))
            verticalInput += 1f;

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized * moveSpeed * Time.deltaTime;

        // Update position
        transform.Translate(movement);

        // Update Animator parameters
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Speed", movement.magnitude);

        // Flip the sprite based on the movement direction
        if (movement != Vector3.zero)
        {
            spriteRenderer.flipX = (horizontalInput < 0);
        }
    }
}
