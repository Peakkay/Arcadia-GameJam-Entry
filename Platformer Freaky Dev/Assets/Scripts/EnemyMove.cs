using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D rb;

    float ct = 0;
    int i = 1, spd = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - ct > 1)
        {
            i*=-1;
            ct = Time.time;
        }
        rb.velocity = new Vector2(spd*i, 0);
    }
}
