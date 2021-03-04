using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uncrouching : MovementState
{
    private PlayerMovement player;

    public Uncrouching(PlayerMovement movementScript)
    {
        player = movementScript;
    }

    public void update()
    {
        if (player.CanStandUp())
        {
            player.StandUp();
        }
    }
}
