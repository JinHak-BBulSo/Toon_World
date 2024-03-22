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
        
    }

    public void StateFIxedUpdate()
    {

    }

    public void StateUpdate()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            playerController.isLeftWall = false;
            playerController.isRightWall = false;
            playerController.Rb.gravityScale = 1;
        }
    }

    private void Climb()
    {
        playerController.Rb.velocity = Vector2.zero;
        playerController.Rb.gravityScale = 0;
    }
}
