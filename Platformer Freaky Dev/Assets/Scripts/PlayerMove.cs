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
    Rigidbody2D rb;
    BoxCollider2D cd;
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
        cd = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        isWalking = false;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
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
        if(Input.GetAxis("Horizontal") > 0 && isFacingRight && isWalking && isGrounded)
        {
            Flip();
        }
        if(Input.GetAxis("Horizontal") < 0 && !isFacingRight && isWalking && isGrounded)
        {
            Flip();
        }
        timer += Time.deltaTime;
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isWalking", isWalking);
    }

    void FixedUpdate()
    {
        if(rb.velocity.y == 0)
        {
            isGrounded = true;
            Debug.Log("Ground");
        }
        if(rb.velocity.x == 0)
        {
            isWalking = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("EnemyKill"))
        {
            EnemyKill();
        }
        if(collision.collider.CompareTag("EnemyDie"))
        {
            PlayerKill();
        }
        if(collision.collider.CompareTag("Pipe"))
        {
            
        }
        if(collision.collider.CompareTag("Coin"))
        {
            CoinCollect();
        }
    }

    public void PlayerKill()
    {
        Debug.Log("Player Killed");
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
    }
    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x*(-1),transform.localScale.y,transform.localScale.z);
    }
}
