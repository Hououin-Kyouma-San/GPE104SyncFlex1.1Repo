using UnityEngine;
using UnityEngine.UIElements;

public abstract class Pawn : MonoBehaviour
{
    // Create methods for movement and rotation speeds
    public float moveSpeed;
    public float strafeSpeed;
    public float rotateSpeed;

    // Make variables for random teleportation within set values
    public float minX1;
    public float maxX1;
    public float minY1;
    public float maxY1;

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

    // Teleport
    public abstract void TeleportUp();

    public abstract void TeleportDown();

    public abstract void TeleportLeft();

    public abstract void TeleportRight();
}
