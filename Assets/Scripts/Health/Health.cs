using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth;

    public float maxHealth;

    public Image healthBar;

    // Variable for the AudioClip (sound file!)
    public AudioClip damageSoundEffect;

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

    // Healing functions
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
        // Gets currentHealth and adds an amount, returning new currentHealth value
        currentHealth += amount;

        // Gets currentHealth and prevents it from exceeding maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateFillAmount();
    }

    // Damage functions
    public void TakeDamage(float amount)
    {
        if (damageSoundEffect !=null)
        {
            // Play back our sound effect
            AudioSource.PlayClipAtPoint(damageSoundEffect, transform.position);
        }

        // Gets currentHealth and subtracts an amount, returning new currentHealth value
        currentHealth -= amount;

        // Gets currentHealth and prevents it from falling below zero
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateFillAmount();

        // Checks if currentHealth is less than or equal to zero
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

    public void UpdateFillAmount()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
}
