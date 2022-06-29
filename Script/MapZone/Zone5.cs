using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone5 : MonoBehaviour
{
    [SerializeField] PlayerController Player;

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.CurrentMapZone = "Castle 1";
        }
    }
}
