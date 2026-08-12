using UnityEngine;

public class DeathMeteor : Death
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance.meteors != null)
        {
            GameManager.instance.meteors.Add(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Die()
    {
        if (GameManager.instance.meteors != null)
        {
            GameManager.instance.meteors.Remove(this);
        }

        Destroy(gameObject);
    }
}
