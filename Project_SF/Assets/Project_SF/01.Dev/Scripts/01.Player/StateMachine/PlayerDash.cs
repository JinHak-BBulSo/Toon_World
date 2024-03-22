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
        playerController.playerState_ = PlayerController.PlayerState.DASH;
        playerController.Rb.AddForce(new Vector2(playerController.Rb.velocity.x * dashPower, 0), ForceMode2D.Impulse);
        playerController.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Roll", false);

        playerController.DelayCall(playerController.playerStatus_.dashCooltime, DashCoolTime);
    }

    private void DashCoolTime()
    {
        playerController.dashAble = true;
    }
}
