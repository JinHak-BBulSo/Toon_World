using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : IPlayerState
{
    private PlayerController playerController;
    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        Attack();
    }

    public void StateExit()
    {
        playerController.attackAble = true;
    }

    public void StateFIxedUpdate()
    {
        
    }

    public void StateUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerController.Rb.velocity = new Vector2(-1 * playerController.playerStatus_.speed, playerController.Rb.velocity.y);
            playerController.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerController.Rb.velocity = new Vector2(playerController.playerStatus_.speed, playerController.Rb.velocity.y);
            playerController.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        playerController.ChangeState(PlayerController.PlayerState.IDLE);
    }

    private void Attack()
    {
        playerController.attackAble = false;
        playerController.playerState_ = PlayerController.PlayerState.ATTACK;
        playerController.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Attack", true);
        playerController.Gun.Fire();
    }
}
