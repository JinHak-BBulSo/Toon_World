using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public Animator Animator {  get { return animator; } }

    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    public Rigidbody2D Rb { get { return rb; } }

    public float jumpInputTime = 0f;

    public enum PlayerState
    {
        NONE = -1,
        IDLE,
        MOVE,
        JUMP,
        SKILL1,
        SKILL2,
        SKILL3,
        DIE
    }

    public Status playerStatus_;
    public IPlayerState currentState_ = new PlayerIdle();
    public PlayerState playerState_ = PlayerState.NONE;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
    }

    private void Start()
    {
        InitPlayer();
    }
    void Update()
    {
        currentState_.StateUpdate();

        if (playerState_ != PlayerState.JUMP)
        {
            if (Input.GetKey(KeyCode.W))
            {
                jumpInputTime += Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                ChangeState(new PlayerJump());
            }
        }
    }

    void FixedUpdate()
    {
        currentState_.StateFIxedUpdate();
    }
    public void ChangeState(IPlayerState newState)
    {
        currentState_.StateExit();
        currentState_ = newState;
        currentState_.StateEnter(this);
    }
    public void InitPlayer()
    {
        currentState_.StateEnter(this);
        playerStatus_.speed = speed;
        //playerStatus_ = GetComponent<Status>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            if (collision.contacts[0].normal.y > 0.7)
            {
                rb.velocity = Vector2.zero;
                ChangeState(new PlayerIdle());
            }
        }
    }
}
