using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    void Update()
    {
        // Converts from world coordinates to viewport coordinates in 0 -> 1 range, independent of aspect ratio
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 moveAdjustment = Vector3.zero;
        // Checks if object is out of range and wraps to corresponding opposite position
        if (viewportPosition.x < 0)
        {
            moveAdjustment.x += 1;
        }
        else if (viewportPosition.x > 1)
        {
            moveAdjustment.x -= 1;
        }
        else if (viewportPosition.y < 0)
        {
            moveAdjustment.y += 1;
        }
        else if (viewportPosition.y > 1)
        {
            moveAdjustment.y -= 1;
        }
        // Converts from viewport coordinates back into world coordinates, applying transform to object
        transform.position = Camera.main.ViewportToWorldPoint(viewportPosition + moveAdjustment);
    }
}