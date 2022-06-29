using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JKFloor : MonoBehaviour
{
    public bool IsCollided;
    public bool activate;

    void Start()
    {
        IsCollided = false;
        activate = false;
    }

    void Update()
    {
        if(IsCollided == true) activate = true;
        else if(IsCollided == false) activate = false;
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            IsCollided = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        IsCollided = false;
    }
}
