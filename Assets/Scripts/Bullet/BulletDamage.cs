using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damageValue;

    public float despawnTime;

    public bool destroyOnImpact;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damageValue);
            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }
        }
    }
}
