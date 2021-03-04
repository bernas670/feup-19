using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MovementState
{
    private PlayerMovement player;

    public Running(PlayerMovement movementScript)
    {
        player = movementScript;
    }

    public void update()
    {
        if (Input.GetButtonDown("Jump") && player.IsOnGround())
        {
            player.Jump();
        }
        else if (Input.GetButton("Crouch"))
        {
            player.Crouch();
        }
    }
}
