using UnityEngine;
using UnityEngine.SocialPlatforms;

public class StarShipPawn : Pawn
{
    private Transform tf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
