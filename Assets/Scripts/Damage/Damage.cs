using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float damageAmount;
    public float damageDelay;
    public bool instantKill;
    public bool destroyOnImpact;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        Pawn starship = collision.gameObject.GetComponent<Pawn>();

        if (health != null && starship != null)
        {
            if (health != null && starship.moveSpeed >= starship.baseSpeed)
            {
                // Create timer coroutine
                StartCoroutine(timer());
                IEnumerator timer()
                {
                    // Set timer delay
                    yield return new WaitForSeconds(damageDelay);

                    if (starship.moveSpeed < starship.maxSpeed)
                    {
                        health.TakeDamage(damageAmount);
                    }

                    else if (starship.moveSpeed == starship.maxSpeed)
                    {
                        health.TakeDamage(health.currentHealth);
                    }

                    if (destroyOnImpact)
                    {
                        Destroy(gameObject);
                    }
                }
            }

            else if (health != null && starship == null)
            {
                // Create timer coroutine
                StartCoroutine(timer());
                IEnumerator timer()
                {
                    // Set timer delay
                    yield return new WaitForSeconds(damageDelay);

                    if (health != null)
                    {
                        health.TakeDamage(damageAmount);
                    }

                    if (destroyOnImpact)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

        // Will kill instantly if true
        if (health != null || starship != null)
        {
            if (instantKill)
            {
                // Create timer coroutine
                StartCoroutine(timer());
                IEnumerator timer()
                {
                    // Set timer delay
                    yield return new WaitForSeconds(damageDelay);

                    if (health != null || starship != null)
                    {
                        health.TakeDamage(health.currentHealth);
                    }

                    if (destroyOnImpact)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}