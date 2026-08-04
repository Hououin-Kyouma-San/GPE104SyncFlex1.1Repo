using UnityEngine;

public class PlayerController : Controller
{
    // Make teleport keycode accessible in component properties
    public KeyCode teleportKey;

    // Create variable to quit game
    public KeyCode quitKey;

    // Create variables for accessible movement keys
    public KeyCode upLocal;
    public KeyCode downLocal;
    public KeyCode leftLocal;
    public KeyCode rightLocal;
    public KeyCode rotateleftLocal;
    public KeyCode rotaterightLocal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }

    public void MakeDecisions()
    {
        if (Input.GetKey(upLocal))
        {
            // Tell the pawn to move up
            pawn.MoveUp();
        }

        if (Input.GetKey(downLocal))
        {
            // Tell the pawn to move down
            pawn.MoveDown();
        }

        if (Input.GetKey(leftLocal))
        {
            // Tell the pawn to strafe left
            pawn.StrafeLeft();
        }

        if (Input.GetKey(rightLocal))
        {
            // Tell the pawn to strafe right
            pawn.StrafeRight();
        }

        if (Input.GetKey(rotateleftLocal))
        {
            // Tell the pawn to rotate counterclockwise
            pawn.RotateLeft();
        }

        if (Input.GetKey(rotaterightLocal))
        {
            // Tell the pawn to rotate clockwise
            pawn.RotateRight();
        }
    }
}
