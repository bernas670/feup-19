using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MovementState
{
    private PlayerMovement player;

    public Falling(PlayerMovement movementScript)
    {
        player = movementScript;
    }

    public void update()
    {
        if (player.IsOnGround())
        {
            player.Land();
        }
    }
}
