using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBeam : MonoBehaviour
{
    [SerializeField] PlayerController player;
    public bool canDamage;

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("HIT");
            if(player.isImmortal == false && canDamage == true) 
            {
                player.health = 0;
                player.KnockBackFromMonster(transform.rotation.eulerAngles.y);
                canDamage = false;
            }
        }
    }
}
