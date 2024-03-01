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
        playerController.Animator.SetBool("isLeft", false);
        playerController.Animator.SetBool("isRight", false);
    }

    public void StateExit()
    {

    }

    public void StateFIxedUpdate()
    {

    }

    public void StateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            playerController.ChangeState(new PlayerMove());
            return;
        }
    }
}
