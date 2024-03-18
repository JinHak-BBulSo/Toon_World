using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : IPlayerState
{
    private PlayerController playerController;
    private float jumpPower = 0;
    private float jumpTime = 0;

    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        playerController.playerState_ = PlayerController.PlayerState.JUMP;
        jumpPower = 6.5f;
        Jump();
    }

    public void StateExit()
    {
        jumpTime = 0;
        playerController.PlayerSpine.skeletonDataAsset.defaultMix = 0.2f;
    }

    public void StateFIxedUpdate()
    {

    }

    public void StateUpdate()
    {
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
            if(playerController.Rb.velocity.x > 0)
            {

            }
            else if(playerController.Rb.velocity.x < 0)
            {

            }
            else
            {

            }
        }

        jumpTime += Time.deltaTime;
        if(jumpTime > 0.8f)
        {
            playerController.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Jump", true);
        }
    }

    public void Jump()
    {
        playerController.PlayerSpine.AnimationState.ClearTrack(0);
        playerController.PlayerSpine.skeletonDataAsset.defaultMix = 0;

        playerController.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Jump_Start", false);
        playerController.Rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}
