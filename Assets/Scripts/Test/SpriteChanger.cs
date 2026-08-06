using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    // Declare our SpriteRenderer component
    public SpriteRenderer theRenderer;

    // Declare a variable for a custom color
    public Color customColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theRenderer = GetComponent<SpriteRenderer>();
        // Access the "color" property of the SpriteRenderer component and change its value to green
        if (theRenderer != null)
        {
            theRenderer.color = customColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
