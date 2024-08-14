using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using UnityEngine;
using UnityEngine.Analytics;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;
using System;
using Unity.VisualScripting;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    public Rigidbody2D rb;
    Animator anim;
    public bool gameover;
    public bool isGrounded;
    public bool isWalking;
    private bool isFacingRight;
    private float timer;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        speed = 5f;
        jumpSpeed = 10f;
        timer = 0f;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        isWalking = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if(!Win.Instance.Finish)
        {
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                isGrounded = false;
            }
            if(Input.GetAxis("Horizontal") != 0)
            {
                rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, rb.velocity.y);
                isWalking = true;
            }
            if(isFacingRight && rb.velocity.x > 0)
            {
                Flip();
            }
            if(!isFacingRight && rb.velocity.x < 0)
            {
                Flip();
            }
            timer += Time.deltaTime;
            anim.SetBool("isGrounded", isGrounded);
            anim.SetBool("isWalking", isWalking);
        }
        else{
            rb.velocity = Vector2.zero;
            anim.SetBool("isGrounded", false);
            anim.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        if(rb.velocity.y == 0)
        {
            isGrounded = true;
        }
        if(rb.velocity.x == 0)
        {
            isWalking = false;
        }
    }

    public void PlayerKill()
    {
        Debug.Log("Player Killed");
        this.gameObject.SetActive(false);
    }

    public void PipeTrasnport(UnityEngine.Vector3 target)
    {
        Debug.Log("Pipe Accessed");
        transform.position = target;
    }

    public void EnemyKill()
    {
        Debug.Log("Enemy Killed");
    }

    public void CoinCollect()
    {
        Debug.Log("Coin Collected");
        Score.Instance.score += 1;
        Score.Instance.UpdateScore();
    }
    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x*(-1),transform.localScale.y,transform.localScale.z);
    }

}
