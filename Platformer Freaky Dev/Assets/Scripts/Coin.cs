using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.parent.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            PlayerMove.Instance.CoinCollect();
        }
    }
}
