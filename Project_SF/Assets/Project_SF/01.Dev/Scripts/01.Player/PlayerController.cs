using Spine.Unity;
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

    public bool attackAble = false;
    public bool jumpAble = false;

    public enum PlayerState
    {
        NONE = -1,
        IDLE,
        MOVE,
        JUMP,
        FALL,
        DASH,
        SIT,
        TACKLE,
        ATTACK,
        SKILL1,
        SKILL2,
        SKILL3,
        DIE
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
        currentState_.StateUpdate();

        if(playerState_ != PlayerState.ATTACK && attackAble)
        {
            if (Input.GetKeyUp(KeyCode.Q))
            {
                ChangeState(PlayerState.ATTACK);
            }
        }

        if (playerState_ != PlayerState.JUMP && jumpAble)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                ChangeState(PlayerState.JUMP);
            }
        }

        if(playerState_ != PlayerState.DASH)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeState(PlayerState.DASH);
            }
        }

        if(rb.velocity.y < 0 && playerState_ != PlayerState.FALL)
        {
            ChangeState(PlayerState.FALL);
        }

        if(playerStatus_.hp <= 0)
        {
            ChangeState(PlayerState.DIE);
        }
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
        attackAble = true;
        jumpAble = true;
        //playerStatus_ = GetComponent<Status>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            if (collision.contacts[0].normal.y > 0.7)
            {
                rb.velocity = Vector2.zero;
                jumpAble = true;
                playerSpine.AnimationState.SetAnimation(0, "Animation/Jump_End", true);
                ChangeState(PlayerState.IDLE);
            }
        }
    }
}
