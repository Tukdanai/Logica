using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSteps : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] AudioSource LeafFootSteps1;
    [SerializeField] AudioSource LeafFootSteps2;
    private int selectedSound;

    void Start()
    {
        selectedSound = 1;
    }

    void Update()
    {
        if(Input.GetAxis("Horizontal") == 0 || player.isGrounded == false)
        {
            selectedSound = 1;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(player.isGrounded == true && Input.GetAxis("Horizontal") != 0 && LeafFootSteps1.isPlaying == false && LeafFootSteps2.isPlaying == false && player.canMove == true)
            {
                if(selectedSound == 1) 
                {
                    LeafFootSteps1.volume = Random.Range(0.35f,0.6f);
                    LeafFootSteps1.pitch = Random.Range(0.8f,1.3f);
                    LeafFootSteps1.Play();
                    selectedSound = 2;
                }
                else if(selectedSound == 2) 
                {
                    LeafFootSteps2.volume = Random.Range(0.55f,0.8f);
                    LeafFootSteps2.pitch = Random.Range(0.8f,1.3f);
                    LeafFootSteps2.Play();
                    selectedSound = 1;
                }
            }
        }   
    }
}
