using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static Win Instance;
    public bool Finish = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.parent.CompareTag("Player"))
        {
            Score.Instance.Over();
            Finish = true;
        }
    }
}
