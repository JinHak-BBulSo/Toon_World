using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : IPlayerState
{
    private PlayerController playerController;
    private int dashPower = 3;
    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
        playerController.playerState_ = PlayerController.PlayerState.DASH;
        Dash();
    }

    public void StateExit()
    {
        
    }

    public void StateFIxedUpdate()
    {
        
    }

    public void StateUpdate()
    {
        
    }

    private void Dash()
    {
        playerController.Rb.AddForce(new Vector2(playerController.Rb.velocity.x * dashPower, 0), ForceMode2D.Impulse);
    }
}
