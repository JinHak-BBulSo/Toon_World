using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SkeletonAnimation playerSpine;
    public SkeletonAnimation PlayerSpine {  get { return playerSpine; } }
    private Animator animator;
    public Animator Animator {  get { return animator; } }

    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    public Rigidbody2D Rb { get { return rb; } }

    public Vector2 jumpDir = Vector2.zero;
    public int jumpCount = 0;

    //KJH. 충돌 관련 변수
    public bool isGround = false;
    public bool isRightWall = false;
    public bool isLeftWall = false;

    //KJH. 대쉬
    public bool dashAble = true;

    [SerializeField]
    private Gun gun;
    public Gun Gun { get { return gun; } }

    public enum PlayerState
    {
        NONE = -1,
        IDLE,
        MOVE,
        JUMP,
        FALL,
        DASH,
        SIT,
        ROLL,
        CLIMB,
        ATTACK,
        SKILL1,
        SKILL2,
        SKILL3,
        HIT,
        DIE,
    }

    public Status playerStatus_;
    public IPlayerState currentState_ = new PlayerIdle();
    public PlayerState playerState_ = PlayerState.NONE;
    private Dictionary<PlayerState, IPlayerState> playerStateDic = new Dictionary<PlayerState, IPlayerState>();

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerSpine = GetComponent<SkeletonAnimation>();

        playerStateDic.Add(PlayerState.IDLE, new PlayerIdle());
        playerStateDic.Add(PlayerState.JUMP, new PlayerJump());
        playerStateDic.Add(PlayerState.FALL, new PlayerFall());
        playerStateDic.Add(PlayerState.MOVE, new PlayerMove());
        playerStateDic.Add(PlayerState.DASH, new PlayerDash());
        playerStateDic.Add(PlayerState.ROLL, new PlayerRoll());
        playerStateDic.Add(PlayerState.CLIMB, new PlayerClimb());
        playerStateDic.Add(PlayerState.SIT, new PlayerSit());
        playerStateDic.Add(PlayerState.DIE, new PlayerDie());
        playerStateDic.Add(PlayerState.ATTACK, new PlayerAttack());
    }

    private void Start()
    {
        InitPlayer();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z) && gun.fireAble)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && isLeftWall)
            {

            }
            else if (Input.GetKey(KeyCode.RightArrow) && isRightWall)
            {

            }
            else
            {
                ChangeState(PlayerState.ATTACK);
            }
        }

        if (jumpCount < playerStatus_.maxJumpCount)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCount++;
                if(playerState_ == PlayerState.CLIMB)
                {
                    if (isRightWall)
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        jumpDir = new Vector2(-1, 1);
                    }
                    else if (isLeftWall)
                    {
                        transform.rotation = Quaternion.Euler(0, -180, 0);
                        jumpDir = new Vector2(1, 1);
                    }
                }
                else
                {
                    jumpDir = new Vector2(0, 1);
                }
                ChangeState(PlayerState.JUMP);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && playerState_ != PlayerState.DASH && playerState_ != PlayerState.ROLL)
        {
            if (dashAble)
            {
                ChangeState(PlayerState.DASH);
            }
            else
            {
                ChangeState(PlayerState.ROLL);
            }
        }

        if (rb.velocity.y < 0 && playerState_ != PlayerState.FALL && !isRightWall && !isLeftWall)
        {
            ChangeState(PlayerState.FALL);
        }

        if(playerStatus_.hp <= 0)
        {
            ChangeState(PlayerState.DIE);
        }

        currentState_.StateUpdate();
    }

    void FixedUpdate()
    {
        currentState_.StateFIxedUpdate();
    }
    public void ChangeState(PlayerState newState)
    {
        currentState_.StateExit();
        currentState_ = playerStateDic[newState];
        currentState_.StateEnter(this);
    }
    public void InitPlayer()
    {
        currentState_.StateEnter(this);
        speed = 5f;
        playerStatus_.speed = speed;
        isGround = true;
        dashAble = true;

        playerStatus_.invincibility = false;
        //playerStatus_ = GetComponent<Status>();
    }

    public void DelayCall(float time, Action func)
    {
        StartCoroutine(DelayedCall(time, func));
    }
    IEnumerator DelayedCall(float time, Action func)
    {
        yield return new WaitForSeconds(time);
        func.Invoke();
    }
}
