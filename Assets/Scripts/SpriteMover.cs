using UnityEngine;

public class SpriteMover : MonoBehaviour
{
    // Make variables for movement and speed
    private Transform tf;
    public double moveSpeed;

    // Make variables for random teleportation within set values
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Make teleport keycode accessible in component properties
    public KeyCode teleportKey;

    // Create variable to quit game
    public KeyCode quitKey;

    void Start()
    {
        // Multiply movement speed on start by a fraction and multiply by deltaTime (makes indepentent of framerate)
        tf = transform;
        moveSpeed = moveSpeed * 0.1 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(teleportKey))
        {
            // Create random numbers ranges for positioning
            float randomX = Random.Range (minX, maxX);
            float randomY = Random.Range (minY, maxY);

            // Create mew vector position for teleporting
            Vector3 newPosition = new Vector3(randomX, randomY, 0);
            tf.position = newPosition;
        }

        // Controls up movement
        if (Input.GetKey(KeyCode.W))
        {
            tf.position = tf.position + Vector3.up * (float)moveSpeed;
        }

        // Controls down movement
        if (Input.GetKey(KeyCode.S))
        {
            tf.position = tf.position + Vector3.down * (float)moveSpeed;
        }

        // Closes game on GetKeyDown
        if (Input.GetKey(quitKey))
        {
            Application.Quit();
        }
    }
}
