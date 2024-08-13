using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;

    float speed = 3f;
    bool alive = true;
    int i=1;
    float lt = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if(Time.time - lt > 1)
        {
            i*=-1;
            lt = Time.time;
        }
        
       if(alive)
            rb.velocity =new Vector2(speed*i*0,0);
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(rb);
        alive = false;
    }
}
