using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using TMPro;

public class SavedManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] PlayerController playerController;
    [SerializeField] Inventory inventory;
    [SerializeField] QuickSlotsPanel quickSlotsPanel;
    private string persistentPath1 = "";
    private string persistentPath2 = "";
    private string persistentPath3 = "";
    [SerializeField] GameObject SavingUI;
    [SerializeField] GameObject animation1;
    [SerializeField] GameObject animation2;
    [SerializeField] GameObject animation3;
    [SerializeField] GameObject animation4;
    [SerializeField] GameObject Heart1;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;
    [SerializeField] GameObject Heart4;
    [SerializeField] GameObject Heart5;

    void Start()
    {
        SetPath();
        SavingUI.SetActive(false);
        animation1.SetActive(false);
        animation2.SetActive(false);
        animation3.SetActive(false);
        animation4.SetActive(false);
    }

    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Z))
        {
            Save();
        }
        /*if(Input.GetKeyDown(KeyCode.X))
        {
            Load();
        }*/
    }

    private void SetPath()
    {
        persistentPath1 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData1.json";
        persistentPath2 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData2.json";
        persistentPath3 = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SavedData3.json";
    }

    private SavedData CreateSavedGame()
    {
        SavedData savedData = new SavedData();

        //Save save slot number.
        savedData.saveSlot = playerController.autoSaveSlot;

        //Save player health.
        savedData.playerHealth = playerController.health;

        //Save player sword.
        savedData.isPlayerHaveSword = playerController.IsHaveSword;

        //Save player position.
        savedData.playerPositionX = Player.transform.position.x;
        savedData.playerPositionY = Player.transform.position.y;

        //Save player chapter location.
        savedData.saveChapter = playerController.CurrentChapter;

        //Save player map location.
        savedData.saveLocation = playerController.CurrentMapZone;

        //Save Real World Time from Device.
        savedData.saveDateTime = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyy <br> hh:mm tt");

        //Save player Played Time.
        savedData.playedTime = playerController.playedTime;

        //Save player inventory.
        savedData.MyItems = inventory.items;
        
        //Save player QuickSlots.
        savedData.MyQuickSlotItems = quickSlotsPanel.quickSlotItems;

        //Save last page seen in Help System.
        savedData.lastOpenedPage = playerController.currentHelpPage;

        //Save player wrong answer count in Logic Gate Boss
        savedData.wrongAnswerInLogicBoss = playerController.LogicWrongCount;

        //Save player wrong answer count in Boolean Expression Boss
        savedData.wrongAnswerInBooleanBoss = playerController.BooleanWrongCount;

        //Save player wrong answer count in JK Flip-Flop Boss
        savedData.wrongAnswerInJKBoss = playerController.JKWrongCount;

        //Save canSaveInChapter3 state
        savedData.canSaveChapter3 = playerController.canSaveInChapter3;
        
        return savedData;
    }

    public void Save()
    {
        SavedData savedData = CreateSavedGame();
        string savePath = "";

        if(playerController.autoSaveSlot == 1)
        {
            savePath = persistentPath1;
        }
        else if(playerController.autoSaveSlot == 2)
        {
            savePath = persistentPath2;
        }
        else if(playerController.autoSaveSlot == 3)
        {
            savePath = persistentPath3;
        }
        
        Debug.Log("Saving Data at " + savePath);
        StartCoroutine(SavingAnimation());
        
        string json = JsonUtility.ToJson(savedData);

        StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        writer.Close();

        SetCurrentPlayingSlot(playerController.autoSaveSlot);
        playerController.ReadyToSave = true; //for debug in case immediately save after load game
    }

    public void SaveWrongCount()
    {
        string json = "";
        string SaveFilePath = "";

        if(playerController.autoSaveSlot == 1)
        {
            SaveFilePath = persistentPath1;
            StreamReader reader = new StreamReader(persistentPath1);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(playerController.autoSaveSlot == 2)
        {
            SaveFilePath = persistentPath2;
            StreamReader reader = new StreamReader(persistentPath2);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(playerController.autoSaveSlot == 3)
        {
            SaveFilePath = persistentPath3;
            StreamReader reader = new StreamReader(persistentPath3);
            json = reader.ReadToEnd();
            reader.Close();
        }
        
        SavedData savedData = JsonUtility.FromJson<SavedData>(json);

        //Save player map location.
        savedData.saveLocation = playerController.CurrentMapZone;

        //Save Real World Time from Device.
        savedData.saveDateTime = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyy <br> hh:mm tt");

        //Save player Played Time.
        savedData.playedTime = playerController.playedTime;

        //Save last page seen in Help System.
        savedData.lastOpenedPage = playerController.currentHelpPage;

        //Save player wrong answer count in Logic Gate Boss
        savedData.wrongAnswerInLogicBoss = playerController.LogicWrongCount;

        //Save player wrong answer count in Boolean Expression Boss
        savedData.wrongAnswerInBooleanBoss = playerController.BooleanWrongCount;

        //Save player wrong answer count in JK Flip-Flop Boss
        savedData.wrongAnswerInJKBoss = playerController.JKWrongCount;

        //Save canSaveInChapter3 state
        savedData.canSaveChapter3 = playerController.canSaveInChapter3;
        
        Debug.Log("Saving Data at " + SaveFilePath);
        
        json = JsonUtility.ToJson(savedData);

        StreamWriter writer = new StreamWriter(SaveFilePath);
        writer.Write(json);
        writer.Close();

        SetCurrentPlayingSlot(playerController.autoSaveSlot);
        playerController.ReadyToSave = true; //for debug in case immediately save after load game
    }

    public void SaveHPandTime()
    {
        string json = "";
        string SaveFilePath = "";

        if(playerController.autoSaveSlot == 1)
        {
            SaveFilePath = persistentPath1;
            StreamReader reader = new StreamReader(persistentPath1);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(playerController.autoSaveSlot == 2)
        {
            SaveFilePath = persistentPath2;
            StreamReader reader = new StreamReader(persistentPath2);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(playerController.autoSaveSlot == 3)
        {
            SaveFilePath = persistentPath3;
            StreamReader reader = new StreamReader(persistentPath3);
            json = reader.ReadToEnd();
            reader.Close();
        }
        
        SavedData savedData = JsonUtility.FromJson<SavedData>(json);

        //Save player health.
        savedData.playerHealth = playerController.health;

        //Save player map location.
        savedData.saveLocation = playerController.CurrentMapZone;

        //Save Real World Time from Device.
        savedData.saveDateTime = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyy <br> hh:mm tt");

        //Save player Played Time.
        savedData.playedTime = playerController.playedTime;

        //Save last page seen in Help System.
        savedData.lastOpenedPage = playerController.currentHelpPage;

        //Save player wrong answer count in Logic Gate Boss
        savedData.wrongAnswerInLogicBoss = playerController.LogicWrongCount;

        //Save player wrong answer count in Boolean Expression Boss
        savedData.wrongAnswerInBooleanBoss = playerController.BooleanWrongCount;

        //Save player wrong answer count in JK Flip-Flop Boss
        savedData.wrongAnswerInJKBoss = playerController.JKWrongCount;

        //Save JK Boss current HP
        if(playerController.JKBossHP < 5) savedData.HPofJKBoss = playerController.JKBossHP;

        //Save canSaveInChapter3 state
        savedData.canSaveChapter3 = playerController.canSaveInChapter3;
        
        Debug.Log("Saving Data at " + SaveFilePath);
        
        json = JsonUtility.ToJson(savedData);

        StreamWriter writer = new StreamWriter(SaveFilePath);
        writer.Write(json);
        writer.Close();

        SetCurrentPlayingSlot(playerController.autoSaveSlot);
        playerController.ReadyToSave = true; //for debug in case immediately save after load game
    }

    public IEnumerator SavingAnimation()
    {
        SavingUI.SetActive(true);
        animation1.SetActive(true);
        animation2.SetActive(true);
        animation3.SetActive(false);
        animation4.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        animation3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animation4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animation3.SetActive(false);
        animation4.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        animation3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        animation4.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SavingUI.SetActive(false);
    }

    public void Load()
    {   
        string json = "";
        string SaveFilePath = "";

        if(playerController.autoSaveSlot == 1)
        {
            SaveFilePath = persistentPath1;
            StreamReader reader = new StreamReader(persistentPath1);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(playerController.autoSaveSlot == 2)
        {
            SaveFilePath = persistentPath2;
            StreamReader reader = new StreamReader(persistentPath2);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(playerController.autoSaveSlot == 3)
        {
            SaveFilePath = persistentPath3;
            StreamReader reader = new StreamReader(persistentPath3);
            json = reader.ReadToEnd();
            reader.Close();
        }
        
        SavedData savedData = JsonUtility.FromJson<SavedData>(json);

        playerController.ReadyToSave = false; //for debug in case immediately save after load game

        if(savedData.saveChapter == "Chapter1_1")
        {
            //Load player health.
            playerController.health = savedData.playerHealth;
            if(playerController.health > 5) playerController.health = 5;
            //Load health UI.
            LoadHealthUI();

            //Load player position.
            Player.transform.position = new Vector2(savedData.playerPositionX, savedData.playerPositionY);

            //Load player Played Time.
            playerController.playedTime = savedData.playedTime;

            //Load last page seen in Help System.
            playerController.currentHelpPage = savedData.lastOpenedPage;

            LoadInventory(savedData);
            LoadQuickSlots(savedData);
        }
        else if(savedData.saveChapter == "Chapter2_1")
        {
            savedData.LoadScene = true;

            json = JsonUtility.ToJson(savedData);
            StreamWriter writer = new StreamWriter(SaveFilePath);
            writer.Write(json);
            writer.Close();

            //Load player current chapter.
            SceneManager.LoadScene("Chapter2_1");
        }
        else if(savedData.saveChapter == "Chapter3_0")
        {
            savedData.LoadScene = true;
            savedData.playerHealth = 5;
            savedData.HPofJKBoss = 5;

            json = JsonUtility.ToJson(savedData);
            StreamWriter writer = new StreamWriter(SaveFilePath);
            writer.Write(json);
            writer.Close();

            //Load player current chapter.
            SceneManager.LoadScene("Chapter3_0");
        }
    }

    public void LoadIfAnotherScene()
    {
        string json = "";
        string SaveFilePath = "";

        if(playerController.autoSaveSlot == 1)
        {
            SaveFilePath = persistentPath1;
            StreamReader reader = new StreamReader(persistentPath1);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(playerController.autoSaveSlot == 2)
        {
            SaveFilePath = persistentPath2;
            StreamReader reader = new StreamReader(persistentPath2);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(playerController.autoSaveSlot == 3)
        {
            SaveFilePath = persistentPath3;
            StreamReader reader = new StreamReader(persistentPath3);
            json = reader.ReadToEnd();
            reader.Close();
        }
        
        SavedData savedData = JsonUtility.FromJson<SavedData>(json);

        playerController.ReadyToSave = false; //for debug in case immediately save after load game

        //Load player health.
        playerController.health = savedData.playerHealth;
        if(playerController.health > 5) playerController.health = 5;
        //Load health UI.
        LoadHealthUI();

        //Load player position.
        Player.transform.position = new Vector2(savedData.playerPositionX, savedData.playerPositionY);

        //Load player Played Time.
        playerController.playedTime = savedData.playedTime;

        //Load last page seen in Help System.
        playerController.currentHelpPage = savedData.lastOpenedPage;

        //Load player wrong answer count in Logic Gate Boss
        playerController.LogicWrongCount = savedData.wrongAnswerInLogicBoss;

        //Load player wrong answer count in Boolean Expression Boss
        playerController.BooleanWrongCount = savedData.wrongAnswerInBooleanBoss;

        //Load player wrong answer count in JK Flip-Flop
        playerController.JKWrongCount = savedData.wrongAnswerInJKBoss;

        //Load JK Boss current HP
        if(savedData.HPofJKBoss < 5 && savedData.HPofJKBoss > 0) playerController.JKBossHP = savedData.HPofJKBoss;

        //Load canSaveInChapter3 state
        playerController.canSaveInChapter3 = savedData.canSaveChapter3;

        LoadInventory(savedData);
        LoadQuickSlots(savedData);

        savedData.LoadScene = false;

        json = JsonUtility.ToJson(savedData);
        StreamWriter writer = new StreamWriter(SaveFilePath);
        writer.Write(json);
        writer.Close();
    }

    public void LoadAfterPassScene()
    {
        int currentSlot = 0;

        if(File.Exists(persistentPath1))
        {
            string json1 = "";
            StreamReader reader1 = new StreamReader(persistentPath1);
            json1 = reader1.ReadToEnd();
            reader1.Close();
            SavedData savedData1 = JsonUtility.FromJson<SavedData>(json1);
            if(savedData1.isCurrentPlayingSlot == true) currentSlot = 1;
        }

        if(File.Exists(persistentPath2))
        {
            string json2 = "";
            StreamReader reader2 = new StreamReader(persistentPath2);
            json2 = reader2.ReadToEnd();
            reader2.Close();
            SavedData savedData2 = JsonUtility.FromJson<SavedData>(json2);
            if(savedData2.isCurrentPlayingSlot == true) currentSlot = 2;
        }

        if(File.Exists(persistentPath3))
        {
            string json3 = "";
            StreamReader reader3 = new StreamReader(persistentPath3);
            json3 = reader3.ReadToEnd();
            reader3.Close();
            SavedData savedData3 = JsonUtility.FromJson<SavedData>(json3);
            if(savedData3.isCurrentPlayingSlot == true) currentSlot = 3;
        }
        
        string json = "";

        if(currentSlot == 1)
        {
            StreamReader reader = new StreamReader(persistentPath1);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(currentSlot == 2)
        {
            StreamReader reader = new StreamReader(persistentPath2);
            json = reader.ReadToEnd();
            reader.Close();
        }
        else if(currentSlot == 3)
        {
            StreamReader reader = new StreamReader(persistentPath3);
            json = reader.ReadToEnd();
            reader.Close();
        }
        
        SavedData savedData = JsonUtility.FromJson<SavedData>(json);

        playerController.ReadyToSave = true;

        //Load player health.
        playerController.health = savedData.playerHealth;
        if(playerController.health > 5) playerController.health = 5;
        //Load health UI.
        LoadHealthUI();

        //Load Current Playing Saved Slot Number.
        playerController.autoSaveSlot = savedData.saveSlot;

        //Load player Played Time.
        playerController.playedTime = savedData.playedTime;

        //Load last page seen in Help System.
        playerController.currentHelpPage = savedData.lastOpenedPage;

        //Load player wrong answer count in Logic Gate Boss
        playerController.LogicWrongCount = savedData.wrongAnswerInLogicBoss;

        //Load player wrong answer count in Boolean Expression Boss
        playerController.BooleanWrongCount = savedData.wrongAnswerInBooleanBoss;

        //Load player wrong answer count in JK Flip-Flop
        playerController.JKWrongCount = savedData.wrongAnswerInJKBoss;

        //Load JK Boss current HP
        if(savedData.HPofJKBoss < 5 && savedData.HPofJKBoss > 0) playerController.JKBossHP = savedData.HPofJKBoss;

        //Load canSaveInChapter3 state
        playerController.canSaveInChapter3 = savedData.canSaveChapter3;

        LoadInventory(savedData);
        LoadQuickSlots(savedData);
    }

    private void LoadInventory(SavedData savedData)
    {
        //Clear inventory.
        for(int i = 0; i < inventory.itemSlots.Length; i++)
        {
            inventory.itemSlots[i].Item = null;
            inventory.itemSlots[i].Amount = 0;
            inventory.itemSlots[i].UpdateAmount();
        }
        
        //Load player inventory.
        inventory.items = savedData.MyItems;

        //Load player inventory UI.
        for(int i = 0; i < inventory.itemSlots.Length; i++)
        {
            for(int j = 0; j < savedData.MyItems.Count; j++)
            {
                if(inventory.itemSlots[i].Item == null && IsItemSlotsDupItem(savedData.MyItems[j]) == false)
                {
                    inventory.itemSlots[i].Item = savedData.MyItems[j];
                    inventory.itemSlots[i].Amount = 1;
                    inventory.itemSlots[i].UpdateAmount();
                }
                else if(inventory.itemSlots[i].Item == savedData.MyItems[j])
                {
                    inventory.itemSlots[i].Amount++;
                    inventory.itemSlots[i].UpdateAmount();
                }     
            }
        }
    }

    private void LoadQuickSlots(SavedData savedData)
    {
        //Clear QuickSlots.
        for(int i = 0; i < quickSlotsPanel.quickSlots.Length; i++)
        {
            quickSlotsPanel.quickSlots[i].Item = null;
            quickSlotsPanel.quickSlots[i].Amount = 0;
            quickSlotsPanel.quickSlots[i].UpdateAmount();
        }
        
        //Load player QuickSlots.
        quickSlotsPanel.quickSlotItems = savedData.MyQuickSlotItems;

        //Load player QuiuckSlots UI.
        for(int i = 0; i < quickSlotsPanel.quickSlots.Length; i++)
        {
            for(int j = 0; j < savedData.MyQuickSlotItems.Count; j++)
            {
                if(quickSlotsPanel.quickSlots[i].Item == null && IsQuickSlotsDupItem(savedData.MyQuickSlotItems[j]) == false)
                {
                    quickSlotsPanel.quickSlots[i].Item = savedData.MyQuickSlotItems[j];
                    quickSlotsPanel.quickSlots[i].Amount = 1;
                    quickSlotsPanel.quickSlots[i].UpdateAmount();
                }
                else if(quickSlotsPanel.quickSlots[i].Item == savedData.MyQuickSlotItems[j])
                {
                    quickSlotsPanel.quickSlots[i].Amount++;
                    quickSlotsPanel.quickSlots[i].UpdateAmount();
                }     
            }
        }
    }

    private bool IsItemSlotsDupItem(Item item) //for check if an item is same as items in itemSlots.
    {
        for(int i = 0; i < inventory.itemSlots.Length; i++)
        {
            if(inventory.itemSlots[i].Item == item)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsQuickSlotsDupItem(Item item) //for check if an item is same as items in QuickSlots.
    {
        for(int i = 0; i < quickSlotsPanel.quickSlots.Length; i++)
        {
            if(quickSlotsPanel.quickSlots[i].Item == item)
            {
                return true;
            }
        }
        return false;
    }

    private void SetCurrentPlayingSlot(int slotNum)
    {
        if(File.Exists(persistentPath1))
        {
            string json1 = "";
            StreamReader reader1 = new StreamReader(persistentPath1);
            json1 = reader1.ReadToEnd();
            reader1.Close();

            SavedData savedData1 = JsonUtility.FromJson<SavedData>(json1);

            if(slotNum == 1) savedData1.isCurrentPlayingSlot = true;
            else savedData1.isCurrentPlayingSlot = false;
            
            json1 = JsonUtility.ToJson(savedData1);
            StreamWriter writer1 = new StreamWriter(persistentPath1);
            writer1.Write(json1);
            writer1.Close();
        }

        if(File.Exists(persistentPath2))
        {
            string json2 = "";
            StreamReader reader2 = new StreamReader(persistentPath2);
            json2 = reader2.ReadToEnd();
            reader2.Close();

            SavedData savedData2 = JsonUtility.FromJson<SavedData>(json2);

            if(slotNum == 2) savedData2.isCurrentPlayingSlot = true;
            else savedData2.isCurrentPlayingSlot = false;
            
            json2 = JsonUtility.ToJson(savedData2);
            StreamWriter writer2 = new StreamWriter(persistentPath2);
            writer2.Write(json2);
            writer2.Close();
        }

        if(File.Exists(persistentPath3))
        {
            string json3 = "";
            StreamReader reader3 = new StreamReader(persistentPath3);
            json3 = reader3.ReadToEnd();
            reader3.Close();

            SavedData savedData3 = JsonUtility.FromJson<SavedData>(json3);

            if(slotNum == 3) savedData3.isCurrentPlayingSlot = true;
            else savedData3.isCurrentPlayingSlot = false;
            
            json3 = JsonUtility.ToJson(savedData3);
            StreamWriter writer3 = new StreamWriter(persistentPath3);
            writer3.Write(json3);
            writer3.Close();
        }
    }

    public void LoadHealthUI()
    {
        if(playerController.health == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
        else if(playerController.health == 2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
        else if(playerController.health == 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(false);
            Heart5.SetActive(false);
        }
        else if(playerController.health == 4)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
            Heart5.SetActive(false);
        }
        else if(playerController.health == 5)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
            Heart4.SetActive(true);
            Heart5.SetActive(true);
        }
    }
}