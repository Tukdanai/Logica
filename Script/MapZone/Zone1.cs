using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone1 : MonoBehaviour
{
    [SerializeField] PlayerController Player;
    [SerializeField] AudioSource MainMenu;
    [SerializeField] AudioSource Forest;
    [SerializeField] AudioSource Cave;
    private bool playBGM;

    void Start()
    {
        playBGM = false;
    }

    void Update()
    {
        if(playBGM == true)
        {
            if(MainMenu.isPlaying == true) MainMenu.Pause();
            if(Cave.isPlaying == true) Cave.Pause();
            if(Forest.isPlaying == false) Forest.Play();
            playBGM = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.CurrentMapZone = "Forest 1";
            playBGM = true;
        }
    }
}
