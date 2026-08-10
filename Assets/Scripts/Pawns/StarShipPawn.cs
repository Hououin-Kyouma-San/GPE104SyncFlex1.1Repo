using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class StarShipPawn : Pawn
{
    private Transform tf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform;
        maxSpeed = moveSpeed + boostSpeed;
        baseSpeed = moveSpeed;

        //GetComponent<Health>().TakeDamage(10.0f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // General movement controls
    public override void MoveUp()
    {
        tf.position = tf.position + (tf.up * moveSpeed * Time.deltaTime);
    }

    public override void MoveDown()
    {
        tf.position = tf.position + (-tf.up * moveSpeed * Time.deltaTime);
    }

    public override void StrafeLeft()
    {
        tf.position = tf.position + (-tf.right * strafeSpeed * Time.deltaTime);
    }

    public override void StrafeRight()
    {
        tf.position = tf.position + (tf.right * strafeSpeed * Time.deltaTime);
    }

    public override void RotateLeft()
    {
        tf.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }

    public override void RotateRight()
    {
        tf.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
    }

    // Boost and braking controls

    public override void Afterburners()
    {
        // Create timer coroutine
        StartCoroutine(timer());
        IEnumerator timer()
        {
            // Set max boost speed
            moveSpeed = baseSpeed + boostSpeed;
            if (moveSpeed >= maxSpeed)
            {
                moveSpeed = maxSpeed;
            }

            // Set timer delay
            yield return new WaitForSeconds(15);

            // Prevent speed from going below baseline
            moveSpeed = boostSpeed - baseSpeed;
            if (moveSpeed <= baseSpeed)
            {
                moveSpeed = baseSpeed;
            }
        }
    }

    public override void Airbrakes()
    {
        // Sloooooowww dooooowwwnnnnn
        moveSpeed = moveSpeed - 7.5f * Time.deltaTime;
        if (moveSpeed <= 0)
        {
            moveSpeed = 0;
        }
    }

    public override void BrakeRelease()
    {
        moveSpeed = baseSpeed;
    }

    // Teleportation controls
    public override void TeleportRandom()
    {
        // Create random numbers ranges for positioning
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        // Create mew vector position for teleporting
        Vector3 newPosition = new Vector3(randomX, randomY, 0);
        tf.position = newPosition;
    }
    public override void TeleportUp()
    {
        // Get current X and Y positions
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        // Teleport up along Y axis
        Vector3 newPosition = new Vector3(xPos, yPos + (float)2.5);
        tf.position = newPosition;
    }

    public override void TeleportDown()
    {
        // Get current X and Y positions
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        // Teleport down along Y axis
        Vector3 newPosition = new Vector3(xPos, yPos - (float)2.5);
        tf.position = newPosition;
    }

    public override void TeleportLeft()
    {
        // Get current X and Y positions
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        // Teleport left along X axis
        Vector3 newPosition = new Vector3(xPos - (float)2.5, yPos);
        tf.position = newPosition;
    }

    public override void TeleportRight()
    {
        // Get current X and Y positions
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        // Teleport right along X axis
        Vector3 newPosition = new Vector3(xPos + (float)2.5, yPos);
        tf.position = newPosition;
    }
}