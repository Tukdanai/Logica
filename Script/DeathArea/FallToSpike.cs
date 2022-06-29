using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallToSpike : MonoBehaviour
{
    [SerializeField] AudioSource Fall;
    [SerializeField] PlayerController player;
    private bool canFall;

    void Start()
    {
        canFall = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(canFall == true && Fall.isPlaying == false) Fall.Play();
            canFall = false;
            player.health = 0;
        }   
    }
}
