using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrap : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Camera checks where you are in the world
        Vector3 ScreenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Get the sides of the screen
        float rightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

        float topSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        // If player is moving through left side of the screen
        if (ScreenPos.x <= 0)
        {
            transform.position = new Vector2(rightSideOfScreenInWorld, transform.position.y);
        }

        else if (ScreenPos.x >= Screen.width)
        {
            transform.position = new Vector2(leftSideOfScreenInWorld, transform.position.y);
        }

        else if (ScreenPos.y <= 0)
        {
            transform.position = new Vector2(transform.position.x, topSideOfScreenInWorld);
        }

        else if (ScreenPos.y >= Screen.height)
        {
            transform.position = new Vector2(transform.position.x, bottomSideOfScreenInWorld); ;
        }
    }
}