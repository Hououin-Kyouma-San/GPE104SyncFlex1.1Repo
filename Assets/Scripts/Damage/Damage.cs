using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount;

    public bool instantKill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Damage gameObject with health component on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        Pawn starship = collision.gameObject.GetComponent<Pawn>();

        // Checks for health and if the movement speed is greater than or equal to default
        if (health != null && starship.moveSpeed >= starship.baseSpeed)
        {
            // Will kill instantly at all speeds if true
            if (instantKill)
            {
                // Create timer coroutine
                StartCoroutine(timer());
                IEnumerator timer()
                {
                    // Set timer delay
                    yield return new WaitForSeconds(0.25f);

                    if (health != null)
                    {
                        health.TakeDamage(health.currentHealth);
                    }
                }

            }
            // Will cause damage if movement speed is default or higher
            else
            {
                // Create timer coroutine
                StartCoroutine(timer());
                IEnumerator timer()
                {
                    // Set timer delay
                    yield return new WaitForSeconds(0.25f);

                    if (health != null)
                    {
                        health.TakeDamage(damageAmount);
                    }
                }
            }
        }

        if (health != null)
        {
            // Starship will explode when impacting at max speed, regardless of instant kill boolean
            if (starship.moveSpeed == starship.maxSpeed)
            {
                // Create timer coroutine
                StartCoroutine(timer());
                IEnumerator timer()
                {
                    // Set timer delay
                    yield return new WaitForSeconds(0.25f);
                    
                    if (health != null)
                    {
                        health.TakeDamage(health.maxHealth);
                    }
                }
            }

            Debug.Log("The GameObject of the other object is named: " + collision.gameObject.name);
        }
    }
        

    //Damage gameObject with health component on trigger, follows tutorial
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            if (instantKill)
            {
                health.TakeDamage(health.currentHealth);

                Destroy(gameObject);
            }
            else
            {
                health.TakeDamage(damageAmount);
            }
        }

        Debug.Log("The GameObject of the other object is named: " + collision.gameObject.name);
    }
}
