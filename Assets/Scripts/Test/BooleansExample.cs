using UnityEngine;

public class BooleansExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (false)
        {
            Debug.Log("Expression is true"); // Hey Look!!! Unreachable code gets greyed out too!!! Nice!!!
        }
        else if (3 == 2)
        {
            Debug.Log("Two is equal to two");
        }
        else
        {
            Debug.Log("Two plus two equals five");
        }
    }

    // I still can't record audio, but IT installed the software I need to work
    // Update is called once per frame
    void Update()
    {
    Debug.Log("Updating..."); // This will repeat in the console!!!
    }
}
