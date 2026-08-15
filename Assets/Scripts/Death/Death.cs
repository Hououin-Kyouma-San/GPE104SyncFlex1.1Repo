using UnityEngine;

public abstract class Death : MonoBehaviour
{
    // Creates new 2D audio spawner
    public static AudioSource PlayClip2D(AudioClip clip, float volume)
    {
        // Create new AudioSource
        GameObject audioObject = new GameObject("2DAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Define clip parameter
        audioSource.clip = clip;

        // Define volume parameter
        audioSource.volume = 1.0f;

        audioSource.Play();

        // Destroys source of audio after playing
        Object.Destroy(audioObject, clip.length);

        return audioSource;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Die();
}
