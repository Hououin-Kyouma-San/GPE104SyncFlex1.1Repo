using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Create methods for movement and rotation speeds
    public float moveSpeed;
    public float strafeSpeed;
    public float rotateSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void MoveUp();

    public abstract void MoveDown();

    public abstract void StrafeLeft();

    public abstract void StrafeRight();

    public abstract void RotateLeft();

    public abstract void RotateRight();
}
