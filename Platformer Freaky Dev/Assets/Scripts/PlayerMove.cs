using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    Rigidbody2D rb;
    CapsuleCollider2D cd;
    Animation anim;
    public bool gameover;
    private bool isGrounded;
    private bool isFacingRight;
    private float timer;
    private float interval;
    void Start()
    {
        speed = 5f;
        jumpSpeed = 10f;
        timer = 0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && timer>interval)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            isGrounded = false;
            timer = 0f;
        }
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"),rb.velocity.y);
        if(rb.velocity.y == 0)
        {
            isGrounded = true;
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
    protected void flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x*(-1),transform.localScale.y,transform.localScale.z);
    }
}
