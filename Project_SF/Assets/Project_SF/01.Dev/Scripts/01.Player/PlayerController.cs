using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float h, v;
    Animator animator;

    [SerializeField]
    private FixedJoystick joystick;
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //KeyMove();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    //KJH. 테스트용 키보드 무빙
    private void KeyMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h > 0)
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
        }
        else if (h < 0)
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", true);
        }
        
        if (v > 0)
        {
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", true);
        }
        else if (v < 0)
        {
            animator.SetBool("isDown", true);
            animator.SetBool("isUp", false);
        }

        if(h == 0)
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
        }

        if(v == 0)
        {
            animator.SetBool("isUp", false);
            animator.SetBool("isDown", false);
        }
    }

    //KJH. 실조작용 스마트폰 조이스틱 무빙
    public void PlayerMove()
    {
        Vector3 direction = Vector3.up * joystick.Vertical + Vector3.right * joystick.Horizontal;
        h = direction.x;
        v = direction.y;

        if (Mathf.Abs(h) > Mathf.Abs(v))
        {
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);
            if (h > 0)
            {
                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
            }
            else if (h < 0)
            {
                animator.SetBool("isRight", false);
                animator.SetBool("isLeft", true);
            }
        }
        else
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            if (v > 0)
            {
                animator.SetBool("isDown", false);
                animator.SetBool("isUp", true);
            }
            else if (v < 0)
            {
                animator.SetBool("isDown", true);
                animator.SetBool("isUp", false);
            }
        }
        if (h == 0)
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
        }

        if (v == 0)
        {
            animator.SetBool("isDown", false);
            animator.SetBool("isUp", false);
        }

        //Debug.Log(direction);
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        transform.position += direction * speed * Time.fixedDeltaTime;
    }
}
