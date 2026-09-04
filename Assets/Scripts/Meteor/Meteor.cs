using Unity.VisualScripting;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidBody;
    private Health _meteorHealth;
    public Sprite[] sprites;
    internal float maxSize = 1.5f;
    internal float size = 1.0f;
    internal float minSize = 0.5f;
    internal float speed = 50.0f;
    public float speedMultiplier;
    public float maxLifetime = 30.0f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _meteorHealth = GetComponent<Health>();
    }
    void Start()
    {
        // Checks array of sprites and chooses randomly from array
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

        // Randomizes meteor rotation and scale
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360);
        this.transform.localScale = Vector3.one * this.size;

        // Calculates both mass and heatlh based on size
        _rigidBody.mass = this.size;
        _meteorHealth.maxHealth = this.size * 100.0f;
        _meteorHealth.currentHealth = this.size * 100.0f;
    }
    public void SetTrajectory(Vector2 direction)
    {
        _rigidBody.AddForce(direction * this.speed * speedMultiplier);
        Destroy(this.gameObject, this.maxLifetime);
    }
}