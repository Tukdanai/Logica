using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class AutoSaveChapter3 : MonoBehaviour
{
    [SerializeField] GameObject SaveArea;
    [SerializeField] SavedManager savedManager;
    [SerializeField] PlayerController playerController;

    void Update()
    {
        if(playerController.canSaveInChapter3 == false) SaveArea.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerController.canSaveInChapter3 = false;
            savedManager.Save();
            Destroy(SaveArea); 
        }   
    }
}
