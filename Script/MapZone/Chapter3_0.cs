using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3_0 : MonoBehaviour
{
    [SerializeField] PlayerController Player;

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.CurrentChapter = "Chapter3_0";
        }
    }
}
