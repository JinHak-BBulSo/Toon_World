using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSit : IPlayerState
{
    private PlayerController playerController;
    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        playerController.playerState_ = PlayerController.PlayerState.SIT;
    }

    public void StateExit()
    {
        
    }

    public void StateFIxedUpdate()
    {
        
    }

    public void StateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerController.ChangeState(PlayerController.PlayerState.IDLE);
            return;
        }
    }
}
