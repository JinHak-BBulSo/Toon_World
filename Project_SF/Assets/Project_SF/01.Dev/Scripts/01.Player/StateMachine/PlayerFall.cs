using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : IPlayerState
{
    private PlayerController playerController;
    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        playerController.playerState_ = PlayerController.PlayerState.FALL;
        Fall();
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
            playerController.Animator.SetBool("isLeft", true);
            playerController.Animator.SetBool("isRight", false);
            playerController.Rb.velocity = Vector2.left * playerController.playerStatus_.speed + new Vector2(0, playerController.Rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerController.Animator.SetBool("isLeft", false);
            playerController.Animator.SetBool("isRight", true);
            playerController.Rb.velocity = Vector2.right * playerController.playerStatus_.speed + new Vector2(0, playerController.Rb.velocity.y);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (playerController.Rb.velocity.x > 0)
            {
                playerController.Animator.SetBool("isLeft", false);
                playerController.Animator.SetBool("isRight", true);
            }
            else if (playerController.Rb.velocity.x < 0)
            {
                playerController.Animator.SetBool("isLeft", true);
                playerController.Animator.SetBool("isRight", false);
            }
            else
            {
                playerController.Animator.SetBool("isLeft", false);
                playerController.Animator.SetBool("isRight", false);
            }
        }
    }

    private void Fall()
    {

    }
}
