using UnityEngine;
using UnityEngine.UIElements;

public abstract class Pawn : MonoBehaviour
{
    // Create methods for movement and rotation speeds
    public float moveSpeed;
    public float strafeSpeed;
    public float rotateSpeed;

    // Create methods for controlling speed boosts
    internal float maxSpeed;
    internal float baseSpeed;
    public float boostSpeed;

    // Make variables for random teleportation within set values
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Movement
    public abstract void MoveUp();

    public abstract void MoveDown();

    public abstract void StrafeLeft();

    public abstract void StrafeRight();

    public abstract void RotateLeft();

    public abstract void RotateRight();

    // Boost and braking
    public abstract void Afterburners();

    public abstract void Airbrakes();

    public abstract void BrakeRelease();

    // Teleport
    public abstract void TeleportRandom();
   
    public abstract void TeleportUp();

    public abstract void TeleportDown();

    public abstract void TeleportLeft();

    public abstract void TeleportRight();
}
