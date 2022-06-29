using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK1Gate0 : MonoBehaviour
{
    [SerializeField] GameObject Gate0;
    public bool IsCollided;
    public bool activate;
    public string number;
    public bool correct;
    public bool readyPress;

    void Start()
    {
        IsCollided = false;
        activate = false;
        readyPress = true;
    }

    void Update()
    {
        if(IsCollided == true && Input.GetKeyDown(KeyCode.E) && readyPress == true) 
        {
            activate = true;
            readyPress = false;
        }
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
