using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentLives;

    public float currentHealth;

    public float currentVolume;

    public float maxHealth;

    public Image healthBar;

    // Variable for the AudioClip (sound file!)
    public AudioClip damageSoundEffect;

    // Variable for the AudioClip (sound file!)
    public AudioClip deathSoundEffect;

    //public void SetVolume(float volumeAmount)
    //{
    //    AudioSource audioComponent = GetComponent<AudioSource>(); 
        
    //    audioComponent.volume = volumeAmount;
    //} Testing

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
                if (deathSoundEffect != null)
                {
                    // Play back our sound effect
                    Death.PlayClip2D(deathSoundEffect, 1);
                }

                // Activates death function and triggers conditions
                deathComponent.Die();

                // Checks for health and a minimum of one life
                if (currentHealth <= 0 && currentLives >= 1)
                {
                    // Resets health after respawning and subtracts one life
                    SetHealth(maxHealth);
                    currentLives = currentLives - 1;
                }

                // Activates if there are no health or lives
                else
                {
                    // Disables the gameObject containing the component
                    gameObject.SetActive(false);
                }
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
