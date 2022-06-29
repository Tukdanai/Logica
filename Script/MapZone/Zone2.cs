using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone2 : MonoBehaviour
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
            if(Forest.isPlaying == true) Forest.Pause();
            if(Cave.isPlaying == false) Cave.Play();
            playBGM = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player.CurrentMapZone = "Forest 2";
            playBGM = true;
        }
    }
}
