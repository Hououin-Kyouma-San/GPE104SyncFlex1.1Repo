using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount;
    public float damageDelay;
    public bool instantKill;
    public bool destroyOnImpact;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        Pawn starship = collision.gameObject.GetComponent<Pawn>();

        // Checks if health exists and if starship exists
        if (health != null && starship != null)
        {
            // Checks if health exists and if speed is greater than or equal to baseSpeed
            if (health != null && starship.moveSpeed >= starship.baseSpeed)
            {
                // Creates timer coroutine
                StartCoroutine(timer());
                IEnumerator timer()
                {
                    yield return new WaitForSeconds(damageDelay);

                    // Checks if speed is less than maxSpeed
                    if (starship.moveSpeed < starship.maxSpeed)
                    {
                        health.TakeDamage(damageAmount);
                    }
                    // Checks if speed is equal to maxSpeed
                    else if (starship.moveSpeed == starship.maxSpeed)
                    {
                        health.TakeDamage(health.currentHealth);
                    }
                    // Checks if destroyOnImpact is true
                    if (destroyOnImpact)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
        // Checks if health exists and if starship doesn't
        if (health != null && starship == null)
        {
            // Creates timer coroutine
            StartCoroutine(timer());
            IEnumerator timer()
            {
                yield return new WaitForSeconds(damageDelay);

                // Checks if health exists and if starship doesn't
                if (health != null && starship == null)
                {
                    health.TakeDamage(damageAmount);
                }
                // Checks if destroyOnImpact is true
                if (destroyOnImpact)
                {
                    Destroy(gameObject);
                }
            }
        }
        // Checks if instantKill is true
        if (instantKill)
        {
            // Creates timer coroutine
            StartCoroutine(timer());
            IEnumerator timer()
            {
                yield return new WaitForSeconds(damageDelay);

                // Checks if health or starship exists
                if (health != null || starship != null)
                {
                    health.TakeDamage(health.currentHealth);
                }
                // Checks if destroyOnImpact is true
                if (destroyOnImpact)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}