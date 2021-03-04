using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MovementState
{
    private PlayerMovement player;

    public Jumping(PlayerMovement movementScript)
    {
        player = movementScript;
    }

    public void update()
    {
        if (player.IsFalling())
        {
            player.Fall();
        }
    }
}
