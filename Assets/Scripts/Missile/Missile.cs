using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        // Randomizes missile rotation
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360);
    }
}