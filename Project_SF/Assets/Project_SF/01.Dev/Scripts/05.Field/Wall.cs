using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if(player != null)
            {
                if (!player.isGround)
                {
                    player.jumpCount = 0;
                    player.Rb.velocity = Vector2.zero;
                    if (collision.contacts[0].normal.x < 0)
                    {
                        player.isLeftWall = true;
                    }
                    else if (collision.contacts[0].normal.x > 0)
                    {
                        player.isRightWall = true;
                    }

                    player.ChangeState(PlayerController.PlayerState.CLIMB);
                }
                else
                {
                    player.ChangeState(PlayerController.PlayerState.IDLE);
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.isLeftWall = false;
                player.isRightWall = false;
            }
        }
    }
}
