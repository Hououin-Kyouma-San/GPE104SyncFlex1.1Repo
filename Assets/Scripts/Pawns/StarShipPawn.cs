using System.Collections;
using UnityEngine;

public class StarShipPawn : Pawn
{
    private Rigidbody2D _rigidBody;
    private Transform tf;
    private Shooter shooter;

    private void Awake()
    {
        // Sets playerPawn in GameManager, gets RigidBody2D physics, and divides control values
        GameManager.instance.playerPawn = this;
        _rigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = moveSpeed * 0.1f;
        baseSpeed = baseSpeed * 0.1f;
        boostSpeed = boostSpeed * 0.1f;
        strafeSpeed = strafeSpeed * 0.1f;
        rotateSpeed = rotateSpeed * 0.025f;
    }
    void Start()
    {
        tf = transform;
        maxSpeed = moveSpeed + boostSpeed;
        baseSpeed = moveSpeed;
        shooter = GetComponent<Shooter>();
    }

    // Forward and reverse controls
    public override void MoveUp()
    {
        _rigidBody.AddForce(this.transform.up * this.moveSpeed);
    }
    public override void MoveDown()
    {
        _rigidBody.AddForce(-this.transform.up * this.moveSpeed);
    }

    // Strafe controls
    public override void StrafeLeft()
    {
        _rigidBody.AddForce(-this.transform.right * this.strafeSpeed);
    }
    public override void StrafeRight()
    {
        _rigidBody.AddForce(this.transform.right * this.strafeSpeed);
    }

    // Rotation controls
    public override void RotateLeft()
    {
        //tf.Rotate(0.0f, 0.0f, rotateSpeed * Time.deltaTime);
        _rigidBody.AddTorque(rotateSpeed);
    }
    public override void RotateRight()
    {
        //tf.Rotate(0.0f, 0.0f, -rotateSpeed * Time.deltaTime);
        _rigidBody.AddTorque(-rotateSpeed);
    }

    // Boost controls
    public override void Afterburners()
    {
        if (this == isActiveAndEnabled)
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
                yield return new WaitForSeconds(5.0f);

                // Prevent speed from going below baseline
                moveSpeed = boostSpeed - baseSpeed;
                if (moveSpeed <= baseSpeed)
                {
                    moveSpeed = baseSpeed;
                }
            }
        }
    }

    // Braking controls
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
        Vector3 newPosition = new Vector3(randomX, randomY, 0.0f);
        tf.position = newPosition;
    }
    public override void TeleportUp()
    {
        // Get current X and Y positions
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        // Teleport up along Y axis
        Vector3 newPosition = new Vector3(xPos, yPos + (float)2.5f);
        tf.position = newPosition;
    }
    public override void TeleportDown()
    {
        // Get current X and Y positions
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        // Teleport down along Y axis
        Vector3 newPosition = new Vector3(xPos, yPos - (float)2.5f);
        tf.position = newPosition;
    }
    public override void TeleportLeft()
    {
        // Get current X and Y positions
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        // Teleport left along X axis
        Vector3 newPosition = new Vector3(xPos - (float)2.5f, yPos);
        tf.position = newPosition;
    }
    public override void TeleportRight()
    {
        // Get current X and Y positions
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        // Teleport right along X axis
        Vector3 newPosition = new Vector3(xPos + (float)2.5f, yPos);
        tf.position = newPosition;
    }

    public override void Shoot()
    {
        {
            if (shooter != null)
            {
                shooter.Shoot();

                Debug.Log("Shooting");
            }
        }
    }
}