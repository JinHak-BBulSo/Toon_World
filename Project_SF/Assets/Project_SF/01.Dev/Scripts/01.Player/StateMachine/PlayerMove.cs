using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : IPlayerState
{
    private PlayerController playerController;
    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        playerController.playerState_ = PlayerController.PlayerState.MOVE;
        playerController.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Run", true);
    }

    public void StateExit()
    {
        
    }

    public void StateFIxedUpdate()
    {
        
    }

    public void StateUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerController.Rb.velocity = Vector2.zero;
            playerController.ChangeState(PlayerController.PlayerState.SIT);
            return;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerController.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerController.Rb.velocity = Vector2.left * playerController.playerStatus_.speed + new Vector2(0, playerController.Rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerController.transform.rotation = Quaternion.Euler(0, 180, 0);
            playerController.Rb.velocity = Vector2.right * playerController.playerStatus_.speed + new Vector2(0, playerController.Rb.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerController.Rb.velocity = Vector2.zero;
            playerController.ChangeState(PlayerController.PlayerState.IDLE);
        }
    }
}
