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
        // Multiply movement speed on start by a fraction
        tf = transform;
        moveSpeed = moveSpeed * 0.1;
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

        // Control up movement and multiply by deltaTime (makes indepentent of framerate)
        if (Input.GetKey(KeyCode.W))
        {
            tf.position = tf.position + Vector3.up * (float)moveSpeed * Time.deltaTime;
        }

        // Control down movement and multiply by deltaTime (makes indepentent of framerate)
        if (Input.GetKey(KeyCode.S))
        {
            tf.position = tf.position + Vector3.down * (float)moveSpeed * Time.deltaTime;
        }

        // Closes game on GetKeyDown
        if (Input.GetKey(quitKey))
        {
            Application.Quit();
        }
    }
}
