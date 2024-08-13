using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    [SerializeField] public Vector3 target;
    private BoxCollider2D boxCollider2D;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") &&PlayerMove.Instance.isGrounded && !PlayerMove.Instance.isWalking)
        {
            PlayerMove.Instance.PipeTrasnport(target);
        }
    }
}
