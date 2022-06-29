using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSteps : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] AudioSource StoneFootSteps;

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(player.isGrounded == true && Input.GetAxis("Horizontal") != 0 && StoneFootSteps.isPlaying == false && player.canMove == true)
            {
                StoneFootSteps.volume = Random.Range(0.35f,0.55f);
                StoneFootSteps.pitch = Random.Range(0.8f,1.2f);
                StoneFootSteps.Play();
            }
        }   
    }
}
