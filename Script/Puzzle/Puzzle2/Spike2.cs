using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Spike2 : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GetDamage getDamage;
    [SerializeField] Pillar pillar;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player") && pillar.CanTakeDamage == true && player.isImmortal == false)
        {
            player.health -= 1;
            if(player.GetDamageSound.isPlaying == false && player.health > 0) 
            {
                player.GetDamageSound.Play();
                getDamage.getDamageAnimation();
            }
            player.isCameraLocked = false;
            player.WaitForCanPause();
            pillar.DelayOpen();
            player.KnockBackAnimation();
            pillar.CanTakeDamage = false;
        }   
    }
}