using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : IPlayerState
{
    private PlayerController playerController;
    private int rollPower = 3;
    private float rollTime = 0;
    private float dashContinue = 0.5f;

    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        Roll();
    }

    public void StateExit()
    {
        rollTime = 0;
    }

    public void StateFIxedUpdate()
    {

    }

    public void StateUpdate()
    {
        rollTime += Time.deltaTime;
        if (rollTime > dashContinue)
        {
            playerController.ChangeState(PlayerController.PlayerState.IDLE);
        }
    }

    private void Roll()
    {
        rollTime = 0;
        playerController.dashAble = false;
        playerController.playerState_ = PlayerController.PlayerState.ROLL;
        int x = 0;
        if (playerController.transform.rotation.y == 0)
        {
            x = -1;
        }
        else if (playerController.transform.rotation.y != 0)
        {
            x = 1;
        }

        playerController.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Roll", false);
    }
}