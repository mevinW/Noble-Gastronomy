using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveCooldown = 2f;
    public float moveSpeed = 5f;

    public float xMax = 10f; // Set your desired x limit
    public float yMax = 5f;  // Set your desired y limit
    public float xMin = 1.5f; // Set your desired x limit
    public float yMin = 1.5f;  // Set your desired y limit

    private Vector2 currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        ChooseNewDirection();
    }

    // Move the dragon in the current direction
    private void MoveDragon()
    {
        rb.velocity = currentDirection * moveSpeed;
    }

    // Choose a new random direction
    private void ChooseNewDirection()
    {
        currentDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    // Choose a new direction periodically
    private void FixedUpdate()
    {
        MoveDragon();

        moveCooldown -= Time.fixedDeltaTime;
        if (moveCooldown <= 0f)
        {
            ChooseNewDirection();
            moveCooldown = 2f; // Reset the cooldown
        }
    }
}
