using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone8 : MonoBehaviour
{
    [SerializeField] PlayerController Player;

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.CurrentMapZone = "Another World";
        }
    }
}
