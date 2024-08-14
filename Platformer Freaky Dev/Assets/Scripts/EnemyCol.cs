using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCol : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    void Start()
    {
       boxCollider2D = GetComponent<BoxCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PlayerFeet"))
        {
            Debug.Log(this.name+ " " + collision.collider.name);
            if(this.CompareTag("EnemyDie"))
            {
                this.transform.parent.gameObject.SetActive(false);
                Score.Instance.score += 5;
                Score.Instance.UpdateScore();
                PlayerMove.Instance.EnemyKill();
            }
            else{
                PlayerMove.Instance.PlayerKill();
                Score.Instance.UpdateScore();
                Score.Instance.Over();
            }
        }
        else
        {
            if(collision.collider.CompareTag("PlayerBody"))
            {
                PlayerMove.Instance.PlayerKill();
                Score.Instance.UpdateScore();
                Score.Instance.Over();
            }
        }
    }
}
