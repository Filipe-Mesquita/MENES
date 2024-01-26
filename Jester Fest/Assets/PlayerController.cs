using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust this to control the player's movement speed

    public KeyCode upKey = KeyCode.W;     // Configure the keys for movement
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

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

        // You can also use Rigidbody2D for more accurate physics-based movement
        // Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // rb.MovePosition(rb.position + movement);
    }
}
