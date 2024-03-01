using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    void StateEnter(PlayerController player);
    void StateFIxedUpdate();
    void StateUpdate();
    void StateExit();
}
