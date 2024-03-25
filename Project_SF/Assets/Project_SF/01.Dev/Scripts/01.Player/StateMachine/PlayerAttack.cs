using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : IPlayerState
{
    private PlayerController playerController;
    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        playerController.playerState_ = PlayerController.PlayerState.ATTACK;
        Attack();
    }

    public void StateExit()
    {

    }

    public void StateFIxedUpdate()
    {
        
    }

    public void StateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerController.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerController.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Attack()
    {
        playerController.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Attack", true);
        playerController.Gun.Fire();

        if(playerController.isLeftWall || playerController.isRightWall)
        {
            playerController.ChangeState(PlayerController.PlayerState.CLIMB);
        }
        else
        {
            playerController.ChangeState(PlayerController.PlayerState.IDLE);
        }
    }
}
