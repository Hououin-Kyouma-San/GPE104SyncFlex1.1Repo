using UnityEngine;

// Adding TextMeshPro library to script
using TMPro;

public class TextChanger : MonoBehaviour
{
    public TextMeshProUGUI textRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Make script print key input on screen
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                textRenderer.text = textRenderer.text + "A";
            }

            else
            {
                textRenderer.text = textRenderer.text + "a";
            }
        }
    }
}