using UnityEngine;

public class Health : MonoBehaviour
{
 public float currentHealth;

 public float maxHealth;

    // int - whole number values (positive, negative, and 0)
    // float - fractional number values
    // string - can store characters
    // bool - can store values of either true or false
    // char - can store a single character

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Get function that allows protected access to private values preventing them from being altered
    public float GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(float healthAmount)
    {
        currentHealth = healthAmount;
    }

    public void Heal(float amount)
    {
        // CurrentHealth variable looks for the currentHealth value, then adds an amount, then sets the new currentHealth to the new value
        currentHealth = currentHealth + amount;

        /* // Shorthand version that I don't quite get yet
        currentHealth += amount; */

        // Prevent health from exceeding maximum value
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        /* // Shorthand version that I can't easily explain
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); */
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            // Die
            Death deathComponent = GetComponent<Death>();

            if (deathComponent != null)
            {
                deathComponent.Die();
            }
        }
    }
}
