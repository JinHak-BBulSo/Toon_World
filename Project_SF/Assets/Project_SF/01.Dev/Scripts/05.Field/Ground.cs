using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Ground : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (collision.contacts[0].normal.y < -0.7)
            {
                player.Rb.velocity = Vector2.zero;
                player.jumpCount = 0;
                player.PlayerSpine.AnimationState.SetAnimation(0, "Animation/Jump_End", true);
                player.isGround = true;
                player.ChangeState(PlayerState.IDLE);
            }
        }
    }
}
