using UnityEngine;

public class SpriteScaler : MonoBehaviour
{
    private Transform tf;

    public double moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform;
        moveSpeed = moveSpeed * 0.1;
    }

    // Update is called once per frame
    void Update()
    {
        // Controls up movement
        if (Input.GetKey(KeyCode.W))
        {
            tf.position = tf.position + Vector3.up * (float)moveSpeed * Time.deltaTime;
        }
        // Controls down movement
        if (Input.GetKey(KeyCode.S))
        {
            tf.position = tf.position + Vector3.down * (float)moveSpeed * Time.deltaTime;
        }
    }
}