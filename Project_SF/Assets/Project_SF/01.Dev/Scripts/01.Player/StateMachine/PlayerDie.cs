using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : IPlayerState
{
    private PlayerController playerController;
    public void StateEnter(PlayerController player)
    {
        this.playerController = player;
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

    private void Die()
    {

    }
}
