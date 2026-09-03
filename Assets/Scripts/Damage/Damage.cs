using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damageAmount;
    public bool instantKill;
    public bool destroyOnImpact;

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

        if (health != null && starship != null)
        {
            // Checks for health, and checks if movement speed is less or at max speed
            if (health != null && starship.moveSpeed <= starship.maxSpeed)
            {
                // Will kill instantly at all speeds if true
                if (instantKill)
                {
                    // Create timer coroutine
                    StartCoroutine(timer());
                    IEnumerator timer()
                    {
                        // Set timer delay
                        yield return new WaitForSeconds(0.125f);

                        if (health != null)
                        {
                            health.TakeDamage(health.currentHealth);
                        }
                    }
                }
                // Checks for health, and causes damage *only* if movement speed is default or higher
                else if (health != null && starship.moveSpeed >= starship.baseSpeed)
                {
                    // Create timer coroutine
                    StartCoroutine(timer());
                    IEnumerator timer()
                    {
                        // Set timer delay
                        yield return new WaitForSeconds(0.125f);

                        // Checks if under max speed, and deals damage based on damage variable
                        if (starship.moveSpeed < starship.maxSpeed)
                        {
                            health.TakeDamage(damageAmount);
                        }

                        // Checks for max speed, and instantly kills if true (doesn't use instantKill)
                        else if (starship.moveSpeed == starship.maxSpeed)
                        {
                            health.TakeDamage(health.currentHealth);
                        }
                    }
                }
            }
        }

        else if (health != null)
        {
            health.TakeDamage(damageAmount);
            if (destroyOnImpact)
            {
                Destroy(gameObject);
            }
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