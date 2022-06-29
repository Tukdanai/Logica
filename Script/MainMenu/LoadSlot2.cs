using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using TMPro;

public class LoadSlot2 : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Button slot2Button;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject loadSlotGameObject;
    [SerializeField] GameObject Player;
    [SerializeField] SavedManager savedManager;
    [SerializeField] GameObject SaveInfo;
    [SerializeField] protected TextMeshProUGUI SavedTime;
    [SerializeField] protected TextMeshProUGUI PlayedTime;
    [SerializeField] protected TextMeshProUGUI SaveLocation;
    [SerializeField] protected TextMeshProUGUI EmptySlot;
    [SerializeField] AudioSource Click;
    private string SaveFile = "";
    private string SaveFile1 = "";
    private string SaveFile2 = "";
    private string SaveFile3 = "";
    private string FormattedTime;
    private int seconds;
    private int minutes;
    private int hours;
    [SerializeField] GameObject LoadScene;

    void Start()
    {
        SaveFile = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData2.json";
        EmptySlot.enabled = false;
        SaveInfo.SetActive(false);

        if(File.Exists(SaveFile))
        {
            //Load save slot infomation.
            string json = "";
            StreamReader reader = new StreamReader(SaveFile);
            json = reader.ReadToEnd();
            reader.Close();
            SavedData savedData = JsonUtility.FromJson<SavedData>(json);
            SavedTime.text = savedData.saveDateTime;

            seconds = (int)(savedData.playedTime % 60);
            minutes = (int)(savedData.playedTime / 60) % 60;
            hours = (int)(savedData.playedTime / 3600) % 24;

            FormattedTime = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
            PlayedTime.text = FormattedTime;

            SaveLocation.text = savedData.saveLocation;
            if(SaveLocation.text == "") //set New Game Location.
            {
                SaveLocation.text = "Forest 1";
            }
        }
    }

    void Update()
    {
        if(File.Exists(SaveFile))
        {
            EmptySlot.enabled = false;
            SaveInfo.SetActive(true);
        }
        else if(!File.Exists(SaveFile))
        {
            SaveInfo.SetActive(false);
            EmptySlot.enabled = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Click.Play();
        if(File.Exists(SaveFile))
        {
            SetCurrentPlayingSlot();
            playerController.autoSaveSlot = 2;
            loadSlotGameObject.SetActive(false);
            Player.SetActive(true);
            savedManager.Load();
            LoadScene.SetActive(true);
        }
    }

    private void SetCurrentPlayingSlot()
    {
        SaveFile1 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData1.json";
        SaveFile2 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData2.json";
        SaveFile3 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData3.json";

        if(File.Exists(SaveFile1))
        {
            string json1 = "";
            StreamReader reader1 = new StreamReader(SaveFile1);
            json1 = reader1.ReadToEnd();
            reader1.Close();
            SavedData savedData1 = JsonUtility.FromJson<SavedData>(json1);
            
            savedData1.isCurrentPlayingSlot = false;

            json1 = JsonUtility.ToJson(savedData1);
            StreamWriter writer1 = new StreamWriter(SaveFile1);
            writer1.Write(json1);
            writer1.Close();
        }
            
        if(File.Exists(SaveFile2))
        {
            string json2 = "";
            StreamReader reader2 = new StreamReader(SaveFile2);
            json2 = reader2.ReadToEnd();
            reader2.Close();
            SavedData savedData2 = JsonUtility.FromJson<SavedData>(json2);

            savedData2.isCurrentPlayingSlot = true;

            json2 = JsonUtility.ToJson(savedData2);
            StreamWriter writer2 = new StreamWriter(SaveFile2);
            writer2.Write(json2);
            writer2.Close();
        }

        if(File.Exists(SaveFile3))
        {
            string json3 = "";
            StreamReader reader3 = new StreamReader(SaveFile3);
            json3 = reader3.ReadToEnd();
            reader3.Close();
            SavedData savedData3 = JsonUtility.FromJson<SavedData>(json3);

            savedData3.isCurrentPlayingSlot = false;

            json3 = JsonUtility.ToJson(savedData3);
            StreamWriter writer3 = new StreamWriter(SaveFile3);
            writer3.Write(json3);
            writer3.Close();
        }
    }
}
