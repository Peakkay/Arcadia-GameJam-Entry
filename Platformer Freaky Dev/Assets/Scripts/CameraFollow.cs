using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position = player.transform.position + new Vector3(0,0,-10);
    }
}
