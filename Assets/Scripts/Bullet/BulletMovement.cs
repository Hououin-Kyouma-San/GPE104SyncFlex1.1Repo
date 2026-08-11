using System.Collections;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed;

    private Transform tf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
            tf.position = tf.position + (tf.up * speed * Time.deltaTime);
    }
}
