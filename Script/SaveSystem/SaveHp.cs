using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class SaveHp : MonoBehaviour
{
    [SerializeField] SavedManager savedManager;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            savedManager.SaveHPandTime();
        }   
    }
}