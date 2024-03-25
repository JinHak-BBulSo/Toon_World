using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : IPlayerState
{
    private PlayerController playerController;
    private int dashPower = 3;
    private float dashTime = 0;
    private float dashContinue = 0.5f;

    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        Dash();
    }

    public void StateExit()
    {
        dashTime = 0;
        playerController.playerStatus_.invincibility = false;
    }

    public void StateFIxedUpdate()
    {
        
    }

    public void StateUpdate()
    {
        dashTime += Time.deltaTime;
        if(dashTime > dashContinue)
        {
            playerController.ChangeState(PlayerController.PlayerState.IDLE);
        }
    }

    private void Dash()
    {
        dashTime = 0;
        playerController.dashAble = false;
        playerController.playerStatus_.invincibility = true;
        playerController.playerState_ = PlayerController.PlayerState.DASH;

        int x = 0;
        if (playerController.transform.rotation.y == 0)
        {
            x = -1;
        }
        else if (playerController.transform.rotation.y != 0)
        {
            x = 1;
        }

        playerController.Rb.AddForce(new Vector2(x * dashPower, 0), ForceMode2D.Impulse);

        playerController.DelayCall(playerController.playerStatus_.dashCooltime, DashCoolTime);
    }

    private void DashCoolTime()
    {
        playerController.dashAble = true;
    }
}
