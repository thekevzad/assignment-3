using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float changeDirectionInterval = 2f; // Interval to change direction
    public float maxRange = 5f; // Maximum range of movement
    public Transform chaser; // Assign the chasing object in the inspector
    private float timer;
    private Vector3 randomDirection;

    void Start()
    {
        ChangeRandomDirection(); // Initial random direction
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeDirectionInterval)
        {
            ChangeRandomDirection(); // Change direction at intervals
            timer = 0f;
        }

        if (chaser != null) // Check if chaser is assigned
        {
            // Calculate direction away from the chaser
            Vector3 direction = (transform.position - chaser.position).normalized;

            // Move away from the chaser
            Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

            // Clamp movement within maxRange
            newPosition.x = Mathf.Clamp(newPosition.x, -maxRange, maxRange);
            newPosition.z = Mathf.Clamp(newPosition.z, -maxRange, maxRange);

            // Move the object
            transform.position = newPosition;

            // Rotate to face the movement direction
            transform.rotation = Quaternion.LookRotation(-direction);
        }
        else
        {
            // Move in the random direction
            Vector3 newPosition = transform.position + randomDirection * speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -maxRange, maxRange); // Clamping movement within maxRange
            newPosition.z = Mathf.Clamp(newPosition.z, -maxRange, maxRange); // Clamping movement within maxRange
            transform.position = newPosition;
        }
    }

    void ChangeRandomDirection()
    {
        // Generate a new random direction
        randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
    }
}
