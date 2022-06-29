using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK2Gate2 : MonoBehaviour
{
    [SerializeField] GameObject Gate2;
    [SerializeField] PlayerController player;
    public bool activate;
    public string number;
    public bool correct;
    public bool readyPress;
    public bool getAttacked;

    void Start()
    {
        activate = false;
        getAttacked = false;
    }

    void Update()
    {
        if(getAttacked == true && readyPress == true) 
        {
            activate = true;
            readyPress = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("ExCarrotSword"))
        {
            if(player.attack == true && readyPress == true) getAttacked = true;
        }   
    }
}
