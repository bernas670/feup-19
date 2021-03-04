using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouching : MovementState
{
    private PlayerMovement player;

    public Crouching(PlayerMovement movementScript)
    {
        player = movementScript;
    }

    public void update()
    {
        if (Input.GetButtonUp("Crouch") && player.CanStandUp())
        {
            player.StandUp();
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            player.Uncrouch();
        }
    }
}
