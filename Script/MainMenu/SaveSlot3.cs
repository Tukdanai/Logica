using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using TMPro;

public class SaveSlot3 : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Button slot3Button;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject saveSlotGameObject;
    [SerializeField] GameObject Player;
    [SerializeField] SavedManager savedManager;
    [SerializeField] GameObject SaveInfo;
    [SerializeField] protected TextMeshProUGUI SavedTime;
    [SerializeField] protected TextMeshProUGUI PlayedTime;
    [SerializeField] protected TextMeshProUGUI SaveLocation;
    [SerializeField] protected TextMeshProUGUI EmptySlot;
    [SerializeField] AudioSource Click;
    private string SaveFile = "";
    private string FormattedTime;
    private int seconds;
    private int minutes;
    private int hours;
    [SerializeField] GameObject LoadScene;

    void Start()
    {
        SaveFile = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData3.json";
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
        playerController.autoSaveSlot = 3;
        if(File.Exists(SaveFile))
        {
            File.Delete(SaveFile);
        }        
        saveSlotGameObject.SetActive(false);
        Player.SetActive(true);
        playerController.ReadyToSave = true;
        savedManager.LoadHealthUI();
        playerController.currentHelpPage = 1;
        LoadScene.SetActive(true);
    }
}
