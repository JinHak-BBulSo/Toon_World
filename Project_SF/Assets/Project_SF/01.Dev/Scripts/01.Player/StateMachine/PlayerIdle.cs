using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : IPlayerState
{
    private PlayerController playerController;

    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        playerController.playerState_ = PlayerController.PlayerState.IDLE;
        playerController.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Idle", true);
    }

    public void StateExit()
    {

    }

    public void StateFIxedUpdate()
    {

    }

    public void StateUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerController.Rb.velocity = Vector2.zero;
            playerController.ChangeState(PlayerController.PlayerState.SIT);
            return;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            playerController.ChangeState(PlayerController.PlayerState.MOVE);
            return;
        }
    }
}
