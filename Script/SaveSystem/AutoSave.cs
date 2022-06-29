using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class AutoSave : MonoBehaviour
{
    [SerializeField] GameObject SaveArea;
    [SerializeField] SavedManager savedManager;
    [SerializeField] PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(playerController.ReadyToSave == false)
            {
                playerController.ReadyToSave = true; //for debug in case immediately save after load game
                Destroy(SaveArea); 
            }
            else if(playerController.ReadyToSave == true)
            {
                savedManager.Save();
                Destroy(SaveArea); 
            }  
        }   
    }
}