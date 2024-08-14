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
        Debug.Log(col.transform.parent.gameObject.name + " "+ PlayerMove.Instance.isGrounded + " " + !PlayerMove.Instance.isWalking);
        if(col.transform.parent.gameObject.CompareTag("Player") &&PlayerMove.Instance.isGrounded && !PlayerMove.Instance.isWalking)
        {
            PlayerMove.Instance.PipeTrasnport(target);
        }
    }
}
