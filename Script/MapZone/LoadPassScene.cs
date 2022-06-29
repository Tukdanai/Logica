using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class LoadPassScene : MonoBehaviour
{
    [SerializeField] GameObject LoadArea;
    [SerializeField] SavedManager savedManager;
    [SerializeField] PlayerController playerController;
    private string SaveFilePath = "";
    private string persistentPath1 = "";
    private string persistentPath2 = "";
    private string persistentPath3 = "";
    private int currentSlot;

    void Start()
    {
        SaveFilePath = "";
        persistentPath1 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData1.json";
        persistentPath2 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData2.json";
        persistentPath3 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData3.json";
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            currentSlot = CheckCurrentPlayingSlot();
            if(currentSlot == 1) SaveFilePath = persistentPath1;
            else if(currentSlot == 2) SaveFilePath = persistentPath2;
            else if(currentSlot == 3) SaveFilePath = persistentPath3;

            if(SaveFilePath != "" && playerController.isLoadFromMainMenu != true)
            {
                savedManager.LoadAfterPassScene();
                playerController.isLoadFromMainMenu = false;    
                playerController.ReadyToSave = true;  
                Destroy(LoadArea);         
            }
        }   
    }

    private int CheckCurrentPlayingSlot()
    {
        if(File.Exists(persistentPath1))
        {
            string json1 = "";
            StreamReader reader1 = new StreamReader(persistentPath1);
            json1 = reader1.ReadToEnd();
            reader1.Close();
            SavedData savedData1 = JsonUtility.FromJson<SavedData>(json1);
            if(savedData1.LoadScene == false && savedData1.isCurrentPlayingSlot == true) 
            {
                playerController.autoSaveSlot = 1;
                return 1;
            }
        }

        if(File.Exists(persistentPath2))
        {
            string json2 = "";
            StreamReader reader2 = new StreamReader(persistentPath2);
            json2 = reader2.ReadToEnd();
            reader2.Close();
            SavedData savedData2 = JsonUtility.FromJson<SavedData>(json2);
            if(savedData2.LoadScene == false && savedData2.isCurrentPlayingSlot == true) 
            {
                playerController.autoSaveSlot = 2;
                return 2;
            }
        }

        if(File.Exists(persistentPath3))
        {
            string json3 = "";
            StreamReader reader3 = new StreamReader(persistentPath3);
            json3 = reader3.ReadToEnd();
            reader3.Close();
            SavedData savedData3 = JsonUtility.FromJson<SavedData>(json3);
            if(savedData3.LoadScene == false && savedData3.isCurrentPlayingSlot == true) 
            {
                playerController.autoSaveSlot = 3;
                return 3;
            }
        }
        return 0;
    }
}
