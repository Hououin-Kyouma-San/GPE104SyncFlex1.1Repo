using UnityEngine;

public class PlayerController : Controller
{
    /*// Make teleport keycode accessible in component properties
    public KeyCode teleportKey;*/

    // Create variable to quit game
    public KeyCode quitKey;

    // Create variables for accessible movement keys
    public KeyCode upLocal;
    public KeyCode downLocal;
    public KeyCode leftLocal;
    public KeyCode rightLocal;
    public KeyCode rotateLeftLocal;
    public KeyCode rotateRightLocal;
    public KeyCode altRotateLeftLocal;
    public KeyCode altRotateRightLocal;

    // Create variables for accessible boost & braking keys
    public KeyCode afterburnersLocal;
    public KeyCode airbrakesLocal;
    public KeyCode altAfterburnersLocal;
    public KeyCode altAirbrakesLocal;

    // Create variables for accessible teleport keys
    public KeyCode teleportRandomGlobal;
    public KeyCode teleportUpGlobal;
    public KeyCode teleportDownGlobal;
    public KeyCode teleportLeftGlobal;
    public KeyCode teleportRightGlobal;

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
        // Make movement decisions

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

        if (Input.GetKey(rotateLeftLocal) || (Input.GetKey(altRotateLeftLocal)))
        {
            // Tell the pawn to rotate counterclockwise
            pawn.RotateLeft();
        }

        if (Input.GetKey(rotateRightLocal) || (Input.GetKey(altRotateRightLocal)))
        {
            // Tell the pawn to rotate clockwise
            pawn.RotateRight();
        }

        // Make boost and braking decisions

        if (Input.GetKeyDown(afterburnersLocal) || (Input.GetKey(altAfterburnersLocal)))
        {
            // Tell the pawn to engage afterburners
            pawn.Afterburners();
        }

        if (Input.GetKey(airbrakesLocal) || (Input.GetKey(altAirbrakesLocal)))
        {
            // Tell the pawn to engage airbrakes
            pawn.Airbrakes();
        }

        else if (Input.GetKeyUp(airbrakesLocal) || (Input.GetKeyUp(altAirbrakesLocal)))
        {
            // Tell the pawn to release airbrakes
            pawn.BrakeRelease();
        }

        // Make teleporting decisions

        if (Input.GetKeyDown(teleportRandomGlobal))
        {
            // Tell the pawn to teleport up
            pawn.TeleportRandom();
        }

        if (Input.GetKeyDown(teleportUpGlobal))
        {
            // Tell the pawn to teleport up
            pawn.TeleportUp();
        }

        if (Input.GetKeyDown(teleportDownGlobal))
        {
            // Tell the pawn to teleport down
            pawn.TeleportDown();
        }

        if (Input.GetKeyDown(teleportLeftGlobal))
        {
            // Tell the pawn to teleport left
            pawn.TeleportLeft();
        }

        if (Input.GetKeyDown(teleportRightGlobal))
        {
            // Tell the pawn to teleport right
            pawn.TeleportRight();
        }
    }
}
