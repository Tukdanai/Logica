using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionBeam : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GetDamage getDamage;
    [SerializeField] AudioSource PlayerGetDamage;
    public bool canDamage;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(player.isImmortal == false && player.health > 0 && canDamage == true) 
            {
                canDamage = false;
                player.health -= 2;
                if(player.health > 0) 
                {
                    PlayerGetDamage.Play();
                    getDamage.getDamageAnimation();
                }
                player.KnockBackFromMonster(transform.rotation.eulerAngles.y);
            }
        }
    }
}
