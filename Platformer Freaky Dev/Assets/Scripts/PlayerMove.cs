using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    Rigidbody2D rb;
    BoxCollider2D cd;
    Animator anim;
    public bool gameover;
    public bool isGrounded;
    public bool isWalking;
    private bool isFacingRight;
    private float timer = 0f;
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
        if((Input.GetAxis("Horizontal") != 0) && isGrounded)
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
            PipeTrasnport();
        }
        if(collision.collider.CompareTag("Coin"))
        {
            CoinCollect();
        }
    }

    void PlayerKill()
    {
        Debug.Log("Player Killed");
    }

    void PipeTrasnport()
    {
        Debug.Log("Pipe Accessed");
    }

    void EnemyKill()
    {
        Debug.Log("Enemy Killed");
    }

    void CoinCollect()
    {
        Debug.Log("Coin Collected");
    }
    protected void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x*(-1),transform.localScale.y,transform.localScale.z);
    }
}
