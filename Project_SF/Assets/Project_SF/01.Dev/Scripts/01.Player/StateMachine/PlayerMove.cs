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
            //hDir = -1f;
            playerController.Animator.SetBool("isLeft", true);
            playerController.Animator.SetBool("isRight", false);
            playerController.Rb.velocity = Vector2.left * playerController.playerStatus_.speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //hDir = 1f;
            playerController.Animator.SetBool("isLeft", false);
            playerController.Animator.SetBool("isRight", true);
            playerController.Rb.velocity = Vector2.right * playerController.playerStatus_.speed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            //hDir = 0f;
            playerController.Animator.SetBool("isLeft", false);
            playerController.Animator.SetBool("isRight", false);
            playerController.Rb.velocity = Vector2.zero;
            playerController.ChangeState(PlayerController.PlayerState.IDLE);
        }
    }
}
