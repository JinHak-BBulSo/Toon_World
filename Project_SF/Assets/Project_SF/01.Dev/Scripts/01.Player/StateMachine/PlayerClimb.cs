using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : IPlayerState
{
    private PlayerController playerController;
    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        player.playerState_ = PlayerController.PlayerState.CLIMB;
        Climb();
    }

    public void StateExit()
    {
        playerController.Rb.gravityScale = 1;
    }

    public void StateFIxedUpdate()
    {

    }

    public void StateUpdate()
    {
        if (playerController.isRightWall)
        {
            playerController.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(playerController.isLeftWall)
        {
            playerController.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Climb()
    {
        playerController.Rb.velocity = Vector2.zero;
        playerController.Rb.gravityScale = 0;
    }
}
